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
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Top = Screen.PrimaryScreen.Bounds.Height * 5;
            Modules.ModuleWithUIConfig.ModuleMainForm form = new Modules.ModuleWithUIConfig.ModuleMainForm();
            form.FormClosing += form_FormClosing;
            form.Show();
        }

        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}