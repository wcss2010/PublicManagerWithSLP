using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PublicManager.DB.Entitys;
using System.IO;
using System.Diagnostics;
using PublicManager.DB;

namespace PublicManager.Modules.Editors
{
    public partial class ProjectEditor : XtraUserControl
    {
        private Project projectObj;
        public ProjectEditor()
        {
            InitializeComponent();
        }

        public void loadData(Project proj)
        {
            projectObj = proj;

            if (proj != null)
            {
                txtProjectName.Text = proj.ProjectName;
                txtProjectTopic.Text = proj.ProjectTopic;
                txtProjectDirection.Text = proj.ProjectDirection;

                if (proj.ProjectSecretLevel != null)
                {
                    string[] tttt = proj.ProjectSecretLevel.Split(new string[] { MainConfig.rowFlag }, StringSplitOptions.None);
                    if (tttt != null && tttt.Length >= 2)
                    {
                        cbxSecretLevel.SelectedItem = tttt[0];
                        txtSecretYears.Value = decimal.Parse(tttt[1]);
                        cbxSecretLevel_SelectedIndexChanged(cbxSecretLevel, new EventArgs());
                    }
                    else
                    {
                        cbxSecretLevel.SelectedItem = proj.ProjectSecretLevel;
                        txtSecretYears.Value = 0;
                        cbxSecretLevel_SelectedIndexChanged(cbxSecretLevel, new EventArgs());
                    }
                }
                else
                {
                    cbxSecretLevel.SelectedItem = "公开";
                }

                txtProjectMasterName.Text = proj.ProjectMasterName;
                txtDutyUnitName.Text = proj.UnitName;
                txtDutyUnitNormalName.Text = proj.UnitRealName;

                txtDutyUnitAddress.Text = proj.UnitAddress != null ? proj.UnitAddress.Replace(MainConfig.cellFlag, string.Empty) : string.Empty;

                txtDutyUnitContact.Text = proj.UnitContact;
                txtDutyUnitContactJob.Text = proj.UnitContactJob;
                txtDutyUnitContactTelephone.Text = proj.UnitContactPhone;
                txtTotalMoneys.Value = proj.TotalMoney;
                txtTotalTimes.Value = proj.TotalTime;
                txtRegisterDate.Value = proj.RequestTime;
                cbxDutyUnit2.SelectedItem = proj.UnitType2;
            }
        }

        private void cbxSecretLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSecretLevel.SelectedItem == "公开" || cbxSecretLevel.SelectedItem == "内部")
            {
                txtSecretYears.Enabled = false;
                txtSecretYears.Value = 0;
            }
            else
            {
                txtSecretYears.Enabled = true;
            }
        }

        private void btnOpenWord_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainConfig.Config.StringDict.ContainsKey("先导解压目录"))
                {
                    string decompressDir = MainConfig.Config.StringDict["先导解压目录"];
                    string catalogNumber = ConnectionManager.Context.table("Catalog").where("CatalogID='" + projectObj.CatalogID + "'").select("CatalogNumber").getValue<string>("");
                    if (File.Exists(Path.Combine(decompressDir, Path.Combine(catalogNumber, "战略先导计划.doc"))))
                    {
                        Process.Start(Path.Combine(decompressDir, Path.Combine(catalogNumber, "战略先导计划.doc")));
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void txtTotalMoneys_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            nud.Value = (int)nud.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProjectName.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目名称!");
                return;
            }
            if (txtProjectTopic.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目主题!");
                return;
            }
            if (txtProjectDirection.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目方向!");
                return;
            }
            if (txtDutyUnitName.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位名称!");
                return;
            }
            if (txtDutyUnitNormalName.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位常用名称!");
                return;
            }
            if (txtDutyUnitAddress.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位省市!");
                return;
            }
            if (txtDutyUnitContact.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位联系人!");
                return;
            }
            if (txtDutyUnitContactTelephone.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位联系人电话!");
                return;
            }
            if (cbxSecretLevel.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入保密等级!");
                return;
            }
            if (cbxDutyUnit2.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位所属大单位!");
                return;
            }
            if (txtTotalMoneys.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入总经费!");
                return;
            }
            if (txtTotalTimes.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入总时间!");
                return;
            }
            if (txtRegisterDate.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入申报日期!");
                return;
            }
            if (txtProjectMasterName.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目负责人!");
                return;
            }
            if (txtDutyUnitContactJob.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位联系人职务!");
                return;
            }

            projectObj.ProjectName = txtProjectName.Text;
            projectObj.ProjectTopic = txtProjectTopic.Text;
            projectObj.ProjectDirection = txtProjectDirection.Text;
            projectObj.ProjectSecretLevel = cbxSecretLevel.Text + MainConfig.rowFlag + txtSecretYears.Value;
            projectObj.ProjectMasterName = txtProjectMasterName.Text;
            projectObj.UnitName = txtDutyUnitName.Text;
            projectObj.UnitRealName = txtDutyUnitNormalName.Text;
            projectObj.UnitContact = txtDutyUnitContact.Text;
            projectObj.UnitContactJob = txtDutyUnitContactJob.Text;
            projectObj.UnitContactPhone = txtDutyUnitContactTelephone.Text;
            projectObj.UnitAddress = txtDutyUnitAddress.Text;
            projectObj.UnitType2 = cbxDutyUnit2.Text;
            projectObj.TotalMoney = txtTotalMoneys.Value;
            projectObj.TotalTime = (int)txtTotalTimes.Value;
            projectObj.RequestTime = txtRegisterDate.Value;

            //更新数据库
            projectObj.copyTo(ConnectionManager.Context.table("Project")).where("ID='" + projectObj.ProjectID + "'").update();            
        }
    }
}