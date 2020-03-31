using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTreeList.Nodes;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PublicManager.Modules.Module_A.PkgImporter.Forms
{
    public partial class ImporterForm : RibbonForm
    {
        private string logFilePath = string.Empty;

        /// <summary>
        /// 是否需要更新替换字典在改变替换列表中项目状态时
        /// </summary>
        private bool isNeedUpdateDict = true;

        /// <summary>
        /// 替换字典，用于表示哪些项目可以替换(Key=项目ID,Value=是否替换)
        /// </summary>
        private Dictionary<string, bool> replaceDict = new Dictionary<string, bool>();
        private string decompressDir;
        private string totalDir;
        private MainView mainView;
        private LoadingForm lf;
        private bool isImportAll;
        private SortedList<string, Catalog> catalogDict = new SortedList<string, Catalog>();

        public ImporterForm(MainView mv, bool isAll, string sourceDir, string destDir)
        {
            InitializeComponent();

            logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "战略先导汇总-" + DateTime.Now.ToString("yyyy_MM_dd") + "导入日志.log");
            
            initCatalogList();

            isImportAll = isAll;
            totalDir = sourceDir;
            decompressDir = destDir;
            mainView = mv;

            lf = new LoadingForm("正在加载申报数据包......");
            lf.Show();
            Application.DoEvents();

            try
            {
                //刷新子目录列表
                getFileTree(sourceDir);
            }
            finally
            {
                lf.Close();
            }
        }

        private void initCatalogList()
        {
            tlAll.Nodes.Clear();
            List<Catalog> catalogList = ConnectionManager.Context.table("Catalog").select("*").getList<Catalog>(new Catalog());
            foreach (Catalog catalogObj in catalogList)
            {
                catalogDict[catalogObj.CatalogNumber] = catalogObj;

                TreeNode tn = new TreeNode(catalogObj.CatalogName);
                tlAll.Nodes.Add(tn);
            }
        }

        public void getFileTree(string path)
        {
            try
            {
                //查找zip文件
                string[] filess = System.IO.Directory.GetFiles(path);
                foreach (string f in filess)
                {
                    if (f.EndsWith(".zip"))
                    {
                        if (isRightRequestZip(f))
                        {
                            //报告进度
                            lf.reportPKG(Path.GetFileNameWithoutExtension(f));

                            //创建节点
                            TreeNode tn = new TreeNode();
                            tn.Text = Path.GetFileNameWithoutExtension(f);
                            tn.Name = f;
                            tn.Checked = isImportAll;
                            tlTestA.Nodes.Add(tn);
                        }
                    }
                }

                //遍历目录
                string[] dirs = System.IO.Directory.GetDirectories(path);
                foreach (string s in dirs)
                {
                    //目录信息
                    System.IO.DirectoryInfo fi = new System.IO.DirectoryInfo(s);
                    string newPath = path + "/" + fi.Name;
                    getFileTree(newPath);
                }
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 是否为正确的申报包
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        private bool isRightRequestZip(string f)
        {
            bool rightPkg = true;

            List<string> fileList = null;
            try
            {
                fileList = ZipTool.getFileListInZip(f);
            }
            catch (Exception ex)
            {
                rightPkg = false;
                writeImportLog(logFilePath, "错误", "对不起，压缩文件(" + f + ")不是Zip包或已损环！请检查！");
            }

            if (rightPkg)
            {
                if (fileList != null)
                {
                    if (fileList.Count >= 2)
                    {
                        bool isHaveFiles = false;
                        bool isHaveStaticDB = false;
                        foreach (string ss in fileList)
                        {
                            if (ss != null)
                            {
                                if (ss.Trim().ToLower().StartsWith("files/"))
                                {
                                    isHaveFiles = true;
                                }
                                else if (ss.Trim().ToLower().Equals("static.db"))
                                {
                                    isHaveStaticDB = true;
                                }
                            }
                        }

                        //判断文件或目录是否存在
                        rightPkg = isHaveFiles && isHaveStaticDB;
                    }
                    else
                    {
                        rightPkg = false;
                        writeImportLog(logFilePath, "错误", "对不起，压缩文件(" + f + ")不是有效的申报包！请检查！");
                    }
                }
                else
                {
                    rightPkg = false;
                    writeImportLog(logFilePath, "错误", "对不起，压缩文件(" + f + ")没有获取到文件列表！请检查！");
                }
            }

            return rightPkg;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="level"></param>
        /// <param name="logTxt"></param>
        public static void writeImportLog(string logFile, string level, string logTxt)
        {
            System.IO.FileStream fs = null;
            System.IO.StreamWriter sw = null;
            try
            {
                fs = new System.IO.FileStream(logFile, System.IO.FileMode.Append);
                sw = new System.IO.StreamWriter(fs, System.Text.Encoding.Default);

                sw.WriteLine("(" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") + ",," + level + "):" + logTxt);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //需要替换的申报包列表
            List<string> importList = new List<string>();
            List<string> importFileNameList = new List<string>();

            #region 查的需要导入的路径
            foreach (TreeNode tn in tlTestA.Nodes)
            {
                //判断是否被选中
                if (tn.Checked)
                {
                    //读取目录名称中的项目编号
                    string projectNumber = tn.Text;

                    //判断是否需要替换
                    if (replaceDict.ContainsKey(projectNumber))
                    {
                        //需要替换

                        //判断是否替换这个项目
                        if (replaceDict[projectNumber])
                        {
                            //需要替换，添加到ImportList列表中
                            importList.Add(Path.Combine(tn.Name, ""));
                            importFileNameList.Add(tn.Text);
                        }
                        else
                        {
                            //不需要替换
                            continue;
                        }
                    }
                    else
                    {
                        //不需要替换
                        importList.Add(Path.Combine(tn.Name, ""));
                        importFileNameList.Add(tn.Text);
                    }
                }
            }
            #endregion

            //开始导入
            ProgressForm pf = new ProgressForm();
            pf.Show();
            pf.run(importList.Count, 0, new EventHandler(delegate(object senders, EventArgs ee)
            {
                //进度数值
                int progressVal = 0;
                int index = -1;
                //导入
                foreach (string zipFile in importList)
                {
                    try
                    {
                        progressVal++;
                        index++;
                        //申报文件名
                        string zipName = importFileNameList[index].ToString();
                        List<string> messageList = null;
                        pf.reportProgress(progressVal, zipName + "_开始解压");
                        bool returnContent = unZipFile(zipFile, zipName, out messageList);
                        if (returnContent)
                        {
                            //报告进度
                            pf.reportProgress(progressVal, zipName + "_开始导入");
                            BaseModuleMainFormWithNoUIConfig.writeLog("开始导入__" + zipName);

                            //导入数据库
                            new DBImporter().addOrReplaceProject(zipFile, zipName, Path.Combine(Path.Combine(decompressDir, zipName), "static.db"));

                            //报告进度
                            pf.reportProgress(progressVal, zipName + "_结束导入");
                            BaseModuleMainFormWithNoUIConfig.writeLog("结束导入__" + zipName);
                        }
                        pf.reportProgress(progressVal, zipName + "_结束解压");
                    }
                    catch (Exception ex)
                    {
                        BaseModuleMainFormWithNoUIConfig.writeLog(ex.ToString());
                    }
                }

                //检查是否已创建句柄，并调用委托执行UI方法
                if (pf.IsHandleCreated)
                {
                    pf.Invoke(new MethodInvoker(delegate()
                    {
                        try
                        {
                            //刷新Catalog列表
                            mainView.updateTreeViews();

                            //关闭进度窗口
                            pf.Close();

                            //关闭窗口
                            Close();
                        }
                        catch (Exception ex)
                        {
                            BaseModuleMainFormWithNoUIConfig.writeLog(ex.ToString());
                        }
                    }));
                }
                else
                {
                    //关闭窗口
                    Close();
                }
            }));            
        }

        /// <summary>
        /// 解压项目文件
        /// </summary>
        /// <param name="zipFile">ZIP文件</param>
        /// <param name="zipName">ZIP名称</param>
        /// <param name="outList">输入错误信息</param>
        /// <returns></returns>
        private bool unZipFile(string pkgZipFile, string zipName, out List<string> outList)
        {
            outList = new List<string>();
            //生成路径字段
            string unZipDir = System.IO.Path.Combine(decompressDir, zipName);
            //删除旧的目录
            try
            {
                Directory.Delete(unZipDir, true);
            }
            catch (Exception ex) { }
            //申报主文件夹创建
            Directory.CreateDirectory(unZipDir);

            BaseModuleMainFormWithNoUIConfig.writeLog("开始解析__" + zipName);
            
            //判断是否存在申报包
            if (pkgZipFile != null && pkgZipFile.EndsWith(".zip"))
            {
                BaseModuleMainFormWithNoUIConfig.writeLog("项目" + zipName + "的解包操作，开始ZIP文件解压");

                //解压这个包
                new ZipTool().UnZipFile(pkgZipFile, unZipDir, string.Empty, true);
                //校验文件信息
                string[] foldersValidata = MainConfig.Config.StringDict["报告验证_目录"].Split(',');
                int foldersLen = foldersValidata.Length;
                string[] filesValidata = MainConfig.Config.StringDict["报告验证_文件"].Split(',');
                int filesLen = filesValidata.Length;
                for (int i = 0; i < foldersLen; i++)
                {
                    if (!System.IO.Directory.Exists(Path.Combine(unZipDir, foldersValidata[i])))
                    {
                        BaseModuleMainFormWithNoUIConfig.writeLog("项目" + zipName + "的解包操作，" + foldersValidata[i] + "文件夹不存在");
                        outList.Add(foldersValidata[i] + "文件夹 不存在");
                    }
                }
                for (int i = 0; i < filesLen; i++)
                {
                    if (!File.Exists(Path.Combine(unZipDir, filesValidata[i])))
                    {
                        BaseModuleMainFormWithNoUIConfig.writeLog("项目" + zipName + "的解包操作，" + filesValidata[i] + "不存在");
                        outList.Add(filesValidata[i] + " 不存在");
                    }
                }
                BaseModuleMainFormWithNoUIConfig.writeLog("项目" + zipName + "的解包操作，结束ZIP文件解压");
            }
            else
            {
                BaseModuleMainFormWithNoUIConfig.writeLog("项目" + zipName + "没有找到ZIP文件");
                outList.Add("没有找到ZIP文件");
            }

            BaseModuleMainFormWithNoUIConfig.writeLog("结束解析__" + zipName);
            if (outList.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 刷新替换列表
        /// </summary>
        private void reloadReplaceList()
        {
            //锁定替换列表点击CheckBox时更新替换字典的功能
            isNeedUpdateDict = false;

            //清空替换列表
            tlErrorList.Nodes.Clear();
            //显示替换列表数
            foreach (KeyValuePair<string, bool> kvp in replaceDict)
            {
                //列表项
                TreeNode tn = new TreeNode(kvp.Key);
                tn.Checked = true;
                tlErrorList.Nodes.Add(tn);
            }

            //解锁替换列表点击CheckBox时更新替换字典的功能
            isNeedUpdateDict = true;
        }

        private void tlTestA_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<TreeNode> checkedList = getCheckedNodeList();

            //移除不需要选项
            List<string> delList = new List<string>();
            foreach (KeyValuePair<string, bool> kvp in replaceDict)
            {
                bool needRemove = true;

                foreach (TreeNode selected in checkedList)
                {
                    if (selected.Text == kvp.Key)
                    {
                        needRemove = false;
                        break;
                    }
                }

                if (needRemove)
                {
                    delList.Add(kvp.Key);
                }
            }
            foreach (string s in delList)
            {
                replaceDict.Remove(s);
            }

            //检查需要添加的选项
            foreach (TreeNode selected in checkedList)
            {
                //读取目录名称中的项目编号
                string catalogNumber = selected.Text;

                //判断这个项目是否被导入过
                if (catalogDict.ContainsKey(catalogNumber))
                {
                    replaceDict[catalogNumber] = true;
                }
            }

            //刷新替换列表
            reloadReplaceList();
        }

        /// <summary>
        /// 获得勾选节点列表
        /// </summary>
        /// <returns></returns>
        private List<TreeNode> getCheckedNodeList()
        {
            List<TreeNode> results = new List<TreeNode>();
            foreach (TreeNode tn in tlTestA.Nodes)
            {
                if (tn.Checked)
                {
                    results.Add(tn);
                }
            }
            return results;
        }

        private void tlTestA_AfterCheck(object sender, TreeViewEventArgs e)
        {
            List<TreeNode> checkedList = getCheckedNodeList();

            //移除不需要选项
            List<string> delList = new List<string>();
            foreach (KeyValuePair<string, bool> kvp in replaceDict)
            {
                bool needRemove = true;

                foreach (TreeNode selected in checkedList)
                {
                    if (selected.Text == kvp.Key)
                    {
                        needRemove = false;
                        break;
                    }
                }

                if (needRemove)
                {
                    delList.Add(kvp.Key);
                }
            }
            foreach (string s in delList)
            {
                replaceDict.Remove(s);
            }

            //检查需要添加的选项
            foreach (TreeNode selected in checkedList)
            {
                //读取目录名称中的项目编号
                string catalogNumber = selected.Text;

                //判断这个项目是否被导入过
                if (catalogDict.ContainsKey(catalogNumber))
                {
                    replaceDict[catalogNumber] = true;
                }
            }

            //刷新替换列表
            reloadReplaceList();
        }

        private void btnSelectAllOrUnSelectAll_Click(object sender, EventArgs e)
        {
            if (tlTestA.Nodes.Count >= 1)
            {
                bool nowValue = !tlTestA.Nodes[0].Checked;
                foreach (TreeNode tn in tlTestA.Nodes)
                {
                    tn.Checked = nowValue;
                }
            }
        }

        private void btnSelectNotInList_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in tlTestA.Nodes)
            {
                if (catalogDict.ContainsKey(tn.Text))
                {
                    tn.Checked = false;
                }
                else
                {
                    tn.Checked = true;
                }
            }
        }
    }
}