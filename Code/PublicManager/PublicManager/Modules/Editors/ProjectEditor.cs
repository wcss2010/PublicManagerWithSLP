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
                    txtSecretYears.Enabled = false;
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
                txtSecretYears.Enabled = false;
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
    }
}