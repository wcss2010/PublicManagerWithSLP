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
        public static string errorlogFilePath = string.Empty;

        private bool isLoading = false;

        /// <summary>
        /// 替换字典，用于表示哪些项目可以替换(Key=项目ID,Value=是否替换)
        /// </summary>
        private List<string> replaceList = new List<string>();

        private string decompressDir;
        private string totalDir;
        private MainView mainView;
        private LoadingForm lf;
        private bool isImportAll;
        private SortedList<string, Catalog> catalogDict = new SortedList<string, Catalog>();

        public ImporterForm(MainView mv, bool isAll, string sourceDir, string destDir)
        {
            InitializeComponent();

            errorlogFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "战略先导汇总-" + DateTime.Now.ToString("yyyy_MM_dd-HH-mm-ss") + "导入日志.log");
            
            initCatalogList();

            isImportAll = isAll;
            totalDir = sourceDir;
            decompressDir = destDir;
            mainView = mv;

            //正在刷新树停止更新替换列表
            isLoading = true;

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

            //刷新替换列表
            isLoading = false;
            reloadReplaceList();

            if (isAll)
            {
                btnSelectNotInList.Visible = false;
            }
            else
            {
                btnSelectNotInList.Visible = true;
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
                            tn.Checked = isNeedChecked(tn);
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

        private bool isNeedChecked(TreeNode tn)
        {
            if (isImportAll)
            {
                return isImportAll;
            }
            else
            {
                return !catalogDict.ContainsKey(tn.Text);
            }
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
                writeImportLog(errorlogFilePath, "错误", "对不起，压缩文件(" + f + ")不是Zip包或已损坏！请检查！");
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
                                if (ss.Trim().ToLower().StartsWith("files/") || ss.Trim().ToLower().StartsWith("files\\"))
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

                        if (rightPkg == false)
                        {
                            if (isHaveFiles == false)
                            {
                                rightPkg = false;
                                writeImportLog(errorlogFilePath, "错误", "对不起，压缩文件(" + f + ")内部的根目录下不存在Files目录！请检查！");
                            }
                            if (isHaveStaticDB == false)
                            {
                                rightPkg = false;
                                writeImportLog(errorlogFilePath, "错误", "对不起，压缩文件(" + f + ")内部的根目录下不存在Static.db文件！请检查！");
                            }
                        }
                    }
                    else
                    {
                        rightPkg = false;
                        writeImportLog(errorlogFilePath, "错误", "对不起，压缩文件(" + f + ")不是有效的申报包！请检查！");
                    }
                }
                else
                {
                    rightPkg = false;
                    writeImportLog(errorlogFilePath, "错误", "对不起，压缩文件(" + f + ")没有获取到文件列表！请检查！");
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
            //获得选择列表
            List<TreeNode> checkedList = getCheckedNodeList();

            //开始导入
            ProgressForm pf = new ProgressForm();
            pf.Show();
            pf.run(checkedList.Count, 0, new EventHandler(delegate(object senders, EventArgs ee)
            {
                //进度数值
                int progressVal = 0;

                //导入
                foreach (TreeNode currentNode in checkedList)
                {
                    //项目名称及文件路径
                    string zipName = currentNode.Text;
                    string zipFile = currentNode.Name;

                    try
                    {
                        progressVal++;
                        
                        pf.reportProgress(progressVal, zipName + "_开始解压");
                        bool returnContent = unZipFile(zipFile, zipName);

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
                        writeImportLog(errorlogFilePath, "错误", "对不起，压缩文件(" + zipFile + ")导入时出错！请检查！Ex:" + ex.ToString());
                    }
                }

                try
                {
                    System.Diagnostics.Process.Start(errorlogFilePath);
                }
                catch (Exception ex) { }

                try
                {
                    exportExcelTo(checkedList);
                }
                catch (Exception ex) { }

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

        private void exportExcelTo(List<TreeNode> checkedList)
        {
            if (isImportAll)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("需要将增量导入的项目导出到Excel吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataTable dtBase = ReporterModuleController.getProjectExcelDataTable();

                    foreach (TreeNode tnn in checkedList)
                    {
                        string catalogNumber = tnn.Text;
                        Project projObj = ConnectionManager.Context.table("Project").where("CatalogID in (select CatalogID from Catalog where CatalogNumber = '" + catalogNumber + "')").select("*").getItem<Project>(new Project());

                        //打印数据
                        ReporterModuleController.printProjectToDataTable(dtBase, projObj);
                    }

                    //导出Excel
                    ExcelHelper.ExportToExcel(dtBase, "项目列表");
                }
            }
        }

        /// <summary>
        /// 解压项目文件
        /// </summary>
        /// <param name="zipFile">ZIP文件</param>
        /// <param name="zipName">ZIP名称</param>
        /// <param name="outList">输入错误信息</param>
        /// <returns></returns>
        private bool unZipFile(string pkgZipFile, string zipName)
        {
            bool rightUnZip = true;

            //生成解压目录
            string unZipDir = Path.Combine(decompressDir, zipName);

            //测试目标目录是否可写
            try
            {
                //尝试删除目录
                if (Directory.Exists(unZipDir))
                {
                    Directory.Delete(unZipDir, true);
                }

                //尝试创建目录
                Directory.CreateDirectory(unZipDir);

                //尝试写入一个Test文件
                File.WriteAllText(Path.Combine(unZipDir, "test.txt"), "测试写入权限！");
            }
            catch (Exception ex)
            {
                rightUnZip = false;
                writeImportLog(errorlogFilePath, "错误", "对不起,压缩文件(" + pkgZipFile + ")的解压目录(" + unZipDir + ")中有文件正在使用或无写入权限！请检查！");
            }

            BaseModuleMainFormWithNoUIConfig.writeLog("开始解析__" + zipName);

            //判断前面的检查是否成功
            if (rightUnZip)
            {
                //判断是否存在申报包
                if (pkgZipFile != null && pkgZipFile.EndsWith(".zip") && File.Exists(pkgZipFile))
                {
                    BaseModuleMainFormWithNoUIConfig.writeLog("项目" + zipName + "的解包操作，开始ZIP文件解压");

                    try
                    {
                        //解压这个包
                        new ZipTool().UnZipFile(pkgZipFile, unZipDir, string.Empty, true);
                    }
                    catch (Exception ex)
                    {
                        rightUnZip = false;
                        writeImportLog(errorlogFilePath, "错误", "对不起,压缩文件(" + pkgZipFile + ")解压失败！请检查！");
                    }

                    //判断前面的检查是否成功
                    if (rightUnZip)
                    {
                        //判断解压是否成功
                        rightUnZip = Directory.Exists(Path.Combine(unZipDir, "Files")) && File.Exists(Path.Combine(unZipDir, "static.db"));
                        if (rightUnZip == false)
                        {
                            writeImportLog(errorlogFilePath, "错误", "对不起,压缩文件(" + pkgZipFile + ")解压失败！请检查！");
                        }

                        //判断前面的检查是否成功
                        if (rightUnZip)
                        {
                            //判断数据结构是否正确
                            rightUnZip = new DBImporter().isRightDB(Path.Combine(unZipDir, "static.db"));
                            if (rightUnZip == false)
                            {
                                writeImportLog(errorlogFilePath, "错误", "对不起,压缩文件(" + pkgZipFile + ")内的DB文件不是有效的数据结构！请检查！");
                            }
                        }
                    }

                    BaseModuleMainFormWithNoUIConfig.writeLog("项目" + zipName + "的解包操作，结束ZIP文件解压");
                }
                else
                {
                    rightUnZip = false;
                    writeImportLog(errorlogFilePath, "错误", "对不起,压缩文件(" + pkgZipFile + ")没有找到！请检查！");
                }
            }

            BaseModuleMainFormWithNoUIConfig.writeLog("结束解析__" + zipName);

            return rightUnZip;
        }

        /// <summary>
        /// 刷新替换列表
        /// </summary>
        private void reloadReplaceList()
        {
            if (isLoading)
            {
                return;
            }

            //清空替换列表
            tlErrorList.Nodes.Clear();

            //显示在列表中的项
            List<TreeNode> checkedList = getCheckedNodeList();
            foreach (TreeNode checkedNode in checkedList)
            {
                if (catalogDict.ContainsKey(checkedNode.Text))
                {
                    TreeNode tn = new TreeNode(checkedNode.Text);
                    tn.Checked = true;
                    tlErrorList.Nodes.Add(tn);
                }
            }
        }

        private void tlTestA_AfterSelect(object sender, TreeViewEventArgs e)
        {   
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
            if (e.Node.Checked)
            {
                e.Node.BackColor = Color.OrangeRed;
            }
            else
            {
                e.Node.BackColor = Color.Transparent;
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