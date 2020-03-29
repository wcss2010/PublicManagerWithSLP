using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules.Module_A.PkgImporter.Forms
{
    public partial class LoadingForm : RibbonForm
    {
        int pkgCount;
        public LoadingForm(string titleStr)
        {
            InitializeComponent();

            lblTitle.Text = titleStr;
        }

        public void report(string cnt)
        {
            if (IsDisposed)
            {
                return;
            }

            lblContent.Text = cnt;
            Application.DoEvents();
        }

        public void reportPKG(string pkgName)
        {
            StringBuilder sb = new StringBuilder();
            pkgCount++;
            sb.Append("当前已经找到").Append(pkgCount).Append("个申报包！").AppendLine();
            sb.AppendLine("当前正在搜索:").Append(pkgName);

            report(sb.ToString());
        }
    }
}