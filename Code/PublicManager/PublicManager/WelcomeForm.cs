using PublicManager.DB;
using PublicManager.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PublicManager
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();

            //初始化数据库
            PublicManager.DB.ConnectionManager.Open("main", "Data Source=" + System.IO.Path.Combine(Application.StartupPath, "static.db"));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Top = Screen.PrimaryScreen.Bounds.Height * 5;
            Modules.Module_A.ModuleMainForm form = new Modules.Module_A.ModuleMainForm();
            form.FormClosing += form_FormClosing;
            form.Show();
        }

        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}