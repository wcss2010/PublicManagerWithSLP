using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Threading;
using NPOI.HSSF.UserModel;
using System.Diagnostics;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using PublicManager.Modules.Module_A.PkgImporter;

namespace PublicManager
{
    public static class ExcelHelper
    {
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sheetName"></param>
        public static void ExportToExcel(this DataTable data, string sheetName)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Excel(2007-2013)|*.xlsx";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            
            ExportToExcel(fileDialog.FileName, data, sheetName);
        }

        /// <summary>
        /// 写Excel文件
        /// </summary>
        /// <param name="excelFile"></param>
        /// <param name="data"></param>
        /// <param name="sheetName"></param>
        public static void ExportToExcel(string excelFile, DataTable data, string sheetName)
        {
            try
            {
                data.TableName = sheetName;
                ExcelBuilder eb = new ExcelBuilder();
                eb.WorkBookObj = new XSSFWorkbook();
                eb.initStyles();
                eb.writeTheSheet(data);

                //处理研究目标和研究内容列表的宽度问题
                ISheet sheetObj = eb.WorkBookObj.GetSheetAt(0);
                sheetObj.SetColumnWidth(0, 60 * 256 + 200);
                sheetObj.SetColumnWidth(3, 60 * 256 + 200);
                sheetObj.SetColumnWidth(4, 60 * 256 + 200);

                eb.saveWorkbookToFile(excelFile);

                MessageBox.Show("导出数据成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GC.Collect();

                Process.Start(excelFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出Excel失败！Ex:" + ex.ToString());
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

            //研究目标
            cells.Add(projObj.WorkDest);

            //研究内容列表
            StringBuilder subjectNameBuilder = new StringBuilder();
            List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("ProjectID='" + projObj.ProjectID + "'").select("*").getList<Subject>(new Subject());
            if (subjectList != null)
            {
                foreach (Subject subObj in subjectList)
                {
                    subjectNameBuilder.AppendLine(subObj.SubjectName != null ? subObj.SubjectName : string.Empty);
                }
            }
            cells.Add(subjectNameBuilder.ToString());

            //保密等级
            cells.Add(getSecretLevelString(projObj.ProjectSecretLevel));

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
            cells.Add(getAddressString(projObj.TeamContactAddress));

            //责任单位名称
            cells.Add(projObj.UnitName);

            //责任单位常用名称
            cells.Add(projObj.UnitRealName);

            //责任单位通信地址
            cells.Add(getAddressString(projObj.UnitAddress));

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

        /// <summary>
        /// 创建Excel项目数据表
        /// </summary>
        /// <returns></returns>
        public static DataTable getProjectExcelDataTable()
        {
            DataTable dtBase = new DataTable();
            #region 创建列
            //生成列
            dtBase.Columns.Add("项目名称", typeof(string));
            dtBase.Columns.Add("项目主题", typeof(string));
            dtBase.Columns.Add("项目方向", typeof(string));
            dtBase.Columns.Add("研究目标", typeof(string));
            dtBase.Columns.Add("研究内容列表", typeof(string));
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
            #endregion

            return dtBase;
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
    }
}