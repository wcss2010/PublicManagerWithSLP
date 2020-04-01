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
    }
}