﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using System.IO;

namespace PublicManager.Modules.Module_A.PkgImporter
{
    public partial class ReporterModuleController : BaseModuleController
    {
        private string totalDir = "(未设置)";

        private string decompressDir = "(未设置)";
        private MainView tc;

        public ReporterModuleController()
        {
            InitializeComponent();
        }

        public override DevExpress.XtraBars.Ribbon.RibbonPage[] getTopBarPages()
        {
            return new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpMaster };
        }

        public override void start()
        {
            //显示详细页
            showDetailPage();

            //更新目录提示
            updateDirectoryHint();
        }

        /// <summary>
        /// 更新目录提示
        /// </summary>
        private void updateDirectoryHint()
        {
            if (MainConfig.Config.StringDict.ContainsKey("先导总目录"))
            {
                totalDir = MainConfig.Config.StringDict["先导总目录"];
            }

            if (MainConfig.Config.StringDict.ContainsKey("先导解压目录"))
            {
                decompressDir = MainConfig.Config.StringDict["先导解压目录"];
            }

            StatusLabelControl.Caption = "主目录:" + totalDir + ",解压目录:" + decompressDir;
        }

        /// <summary>
        /// 显示详细页
        /// </summary>
        private void showDetailPage()
        {
            DisplayControl.Controls.Clear();
            tc = new MainView();
            tc.Dock = DockStyle.Fill;
            DisplayControl.Controls.Add(tc);

            tc.updateTreeViews();
        }

        public override void stop()
        {

        }

        private void btnSetSourceDir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fbdFolderSelect.SelectedPath = totalDir == "(未设置)" ? string.Empty : totalDir;
            if (fbdFolderSelect.ShowDialog() == DialogResult.OK)
            {
                if (fbdFolderSelect.SelectedPath == MainConfig.Config.StringDict["先导解压目录"])
                {
                    MessageBox.Show("对不起，总目录和解压目录不能是一个目录！");
                }
                else
                {
                    totalDir = fbdFolderSelect.SelectedPath;

                    MainConfig.Config.StringDict["先导总目录"] = totalDir;
                    MainConfig.saveConfig();
                }

                updateDirectoryHint();
            }
        }

        private void btnSetDestDir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fbdFolderSelect.SelectedPath = decompressDir == "(未设置)" ? string.Empty : decompressDir;
            if (fbdFolderSelect.ShowDialog() == DialogResult.OK)
            {
                if (fbdFolderSelect.SelectedPath == MainConfig.Config.StringDict["先导总目录"])
                {
                    MessageBox.Show("对不起，总目录和解压目录不能是一个目录！");
                }
                else
                {
                    decompressDir = fbdFolderSelect.SelectedPath;

                    MainConfig.Config.StringDict["先导解压目录"] = decompressDir;
                    MainConfig.saveConfig();
                }

                updateDirectoryHint();
            }
        }

        private void btnImportAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ImporterForm ifm = new Forms.ImporterForm(tc, true, totalDir, decompressDir);
            ifm.ShowDialog();
        }

        private void btnImportWithSelected_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ImporterForm ifm = new Forms.ImporterForm(tc, false, totalDir, decompressDir);
            ifm.ShowDialog();
        }

        private void btnOpenMasterDir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(MainConfig.Config.StringDict["先导总目录"]);
            }
            catch (Exception ex) { }
        }

        private void btnOpenDecompressDir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(MainConfig.Config.StringDict["先导解压目录"]);
            }
            catch (Exception ex) { }
        }

        private void btnExportTo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Empty;
            sfd.Filter = "*.xlsx|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //输出的Excel路径
                    string excelFile = sfd.FileName;

                    //Excel数据
                    MemoryStream memoryStream = new MemoryStream();

                    //创建Workbook
                    NPOI.XSSF.UserModel.XSSFWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();

                    #region 设置Excel样式
                    //创建单元格设置对象(普通内容)
                    NPOI.SS.UserModel.ICellStyle cellStyleA = workbook.CreateCellStyle();
                    cellStyleA.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
                    cellStyleA.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                    cellStyleA.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleA.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleA.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleA.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleA.WrapText = true;

                    //创建单元格设置对象(普通内容)
                    NPOI.SS.UserModel.ICellStyle cellStyleB = workbook.CreateCellStyle();
                    cellStyleB.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    cellStyleB.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                    cellStyleB.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleB.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleB.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleB.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleB.WrapText = true;

                    //创建设置字体对象(内容字体)
                    NPOI.SS.UserModel.IFont fontA = workbook.CreateFont();
                    fontA.FontHeightInPoints = 16;//设置字体大小
                    fontA.FontName = "宋体";
                    cellStyleA.SetFont(fontA);

                    //创建设置字体对象(标题字体)
                    NPOI.SS.UserModel.IFont fontB = workbook.CreateFont();
                    fontB.FontHeightInPoints = 16;//设置字体大小
                    fontB.FontName = "宋体";
                    fontB.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                    cellStyleB.SetFont(fontB);
                    #endregion

                    //基本数据
                    DataTable dtBase = new DataTable();

                    #region 输出基本数据
                    //生成列
                    dtBase.Columns.Add("项目名称", typeof(string));
                    dtBase.Columns.Add("项目主题", typeof(string));
                    dtBase.Columns.Add("项目方向", typeof(string));
                    dtBase.Columns.Add("保密等级", typeof(string));
                    dtBase.Columns.Add("项目负责人", typeof(string));
                    dtBase.Columns.Add("项目负责人_性别", typeof(string));
                    dtBase.Columns.Add("项目负责人_出生年月", typeof(string));
                    dtBase.Columns.Add("项目负责人_职务职称", typeof(string));
                    dtBase.Columns.Add("项目负责人_座机", typeof(string));
                    dtBase.Columns.Add("项目负责人_手机", typeof(string));
                    dtBase.Columns.Add("项目组_联系人", typeof(string));
                    dtBase.Columns.Add("项目组联系人性  别", typeof(string));
                    dtBase.Columns.Add("项目组联系人出生年月", typeof(string));
                    dtBase.Columns.Add("项目组联系人职务职称", typeof(string));
                    dtBase.Columns.Add("项目组联系人座  机", typeof(string));
                    dtBase.Columns.Add("项目组联系人手  机", typeof(string));
                    dtBase.Columns.Add("项目组联系人通信地址", typeof(string));
                    dtBase.Columns.Add("责任单位名称", typeof(string));
                    dtBase.Columns.Add("责任单位常用名称", typeof(string));
                    dtBase.Columns.Add("责任单位通信地址", typeof(string));
                    dtBase.Columns.Add("责任单位所属大单位", typeof(string));
                    dtBase.Columns.Add("责任单位联系人", typeof(string));
                    dtBase.Columns.Add("责任单位联系人职务", typeof(string));
                    dtBase.Columns.Add("责任单位联系人电话", typeof(string));
                    dtBase.Columns.Add("总时间", typeof(string));
                    dtBase.Columns.Add("总经费", typeof(string));
                    dtBase.Columns.Add("申报日期", typeof(string));

                    List<Catalog> catalogList = ConnectionManager.Context.table("Catalog").select("*").getList<Catalog>(new Catalog());

                    //生成内容
                    foreach (Catalog c in catalogList)
                    {
                        //项目信息
                        Project p = ConnectionManager.Context.table("Project").where("CatalogID = '" + c.CatalogID + "'").select("*").getItem<Project>(new Project());

                        //打印项目数据
                        printProjectToDataTable(dtBase, p);
                    }
                    #endregion

                    //写入基本数据
                    writeSheet(workbook, cellStyleA, cellStyleB, dtBase);

                    #region 输出文件并打开文件
                    //输出到流
                    workbook.Write(memoryStream);

                    //写Excel文件
                    File.WriteAllBytes(excelFile, memoryStream.ToArray());

                    //显示提示
                    MessageBox.Show("导出完成！路径：" + excelFile, "提示");

                    //打开Excel文件
                    System.Diagnostics.Process.Start(excelFile);
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("对不起，导出失败！Ex:" + ex.ToString());
                }
            }
        }

        public static object getSecretLevelString(string secretStr)
        {
            if (secretStr != null)
            {
                if (secretStr.StartsWith("公开"))
                {
                    return "公开";
                }
                else if (secretStr.StartsWith("内部"))
                {
                    return "内部★注意保管";
                }
                else if (secretStr.StartsWith("秘密"))
                {
                    return secretStr.Replace(MainConfig.rowFlag, "★") + "年";
                }
                else if (secretStr.StartsWith("机密"))
                {
                    return secretStr.Replace(MainConfig.rowFlag, "★") + "年";
                }
                else
                {
                    return "公开";
                }
            }
            else
            {
                return "公开";
            }
        }

        public static object getAddressString(string sourceAddress)
        {
            return sourceAddress != null ? sourceAddress.Replace(MainConfig.cellFlag, string.Empty) : string.Empty;
        }

        private void btnExportWordAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainConfig.Config.StringDict.ContainsKey("先导解压目录"))
            {
                string decompressDir = MainConfig.Config.StringDict["先导解压目录"];

                if (fbdFolderSelect.ShowDialog() == DialogResult.OK)
                {
                    List<Catalog> catalogList = ConnectionManager.Context.table("Catalog").select("*").getList<Catalog>(new Catalog());
                    //生成内容
                    foreach (Catalog c in catalogList)
                    {
                        //项目信息
                        Project p = ConnectionManager.Context.table("Project").where("CatalogID = '" + c.CatalogID + "'").select("*").getItem<Project>(new Project());

                        string wordFile = Path.Combine(decompressDir, Path.Combine(c.CatalogNumber, "战略先导计划.doc"));
                        if (File.Exists(wordFile))
                        {
                            try
                            {
                                string destWordFile = Path.Combine(fbdFolderSelect.SelectedPath, p.ProjectName + "-" + p.UnitName + "-" + p.ProjectMasterName + ".doc");

                                File.Copy(wordFile, destWordFile, true);
                            }
                            catch (Exception ex)
                            {
                                System.Console.WriteLine(ex.ToString());
                            }
                        }
                    }

                    MessageBox.Show("导出完成！");
                }
            }
        }

        /// <summary>
        /// 打印项目数据
        /// </summary>
        /// <param name="dtData"></param>
        /// <param name="projObj"></param>
        public static void printProjectToDataTable(DataTable dtData, Project projObj)
        {
            if (dtData == null || projObj == null || string.IsNullOrEmpty(projObj.ProjectName) || string.IsNullOrEmpty(projObj.ProjectMasterName) || string.IsNullOrEmpty(projObj.UnitName))
            {
                return;
            }

            List<object> cells = new List<object>();

            //项目名称
            cells.Add(projObj.ProjectName);

            //项目主题
            cells.Add(projObj.ProjectTopic);

            //项目方向
            cells.Add(projObj.ProjectDirection);

            //保密等级
            cells.Add(ReporterModuleController.getSecretLevelString(projObj.ProjectSecretLevel));

            //项目负责人
            cells.Add(projObj.ProjectMasterName);

            //项目负责人性  别
            cells.Add(projObj.ProjectMasterSex);

            //项目负责人出生年月
            cells.Add((projObj.ProjectMasterBirthday != null ? projObj.ProjectMasterBirthday : DateTime.Now).ToString("yyyy年MM月dd日"));

            //项目负责人职务职称
            cells.Add(projObj.ProjectMasterJob);

            //项目负责人座  机
            cells.Add(projObj.ProjectMasterTelephone);

            //项目负责人手  机
            cells.Add(projObj.ProjectMasterMobilephone);

            //项目组联系人
            cells.Add(projObj.TeamContactName);

            //项目组联系人性  别
            cells.Add(projObj.TeamContactSex);

            //项目组联系人出生年月
            cells.Add((projObj.TeamContactBirthday != null ? projObj.TeamContactBirthday : DateTime.Now).ToString("yyyy年MM月dd日"));

            //项目组联系人职务职称
            cells.Add(projObj.TeamContactJob);

            //项目组联系人座  机
            cells.Add(projObj.TeamContactTelephone);

            //项目组联系人手  机
            cells.Add(projObj.TeamContactMobilephone);

            //项目组联系人通信地址
            cells.Add(ReporterModuleController.getAddressString(projObj.TeamContactAddress));

            //责任单位名称
            cells.Add(projObj.UnitName);

            //责任单位常用名称
            cells.Add(projObj.UnitRealName);

            //责任单位通信地址
            cells.Add(ReporterModuleController.getAddressString(projObj.UnitAddress));

            //责任单位所属大单位
            cells.Add(projObj.UnitType2);

            //责任单位联系人
            cells.Add(projObj.UnitContact);

            //责任单位联系人职务
            cells.Add(projObj.UnitContactJob);

            //责任单位联系人电话
            cells.Add(projObj.UnitContactPhone);

            //总时间
            cells.Add(projObj.TotalTime);

            //总经费
            cells.Add(projObj.TotalMoney);

            //申报日期
            cells.Add((projObj.RequestTime != null ? projObj.RequestTime : DateTime.Now).ToString("yyyy年MM月dd日"));

            //添加进表格
            dtData.Rows.Add(cells.ToArray());
        }
    }
}