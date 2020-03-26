using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Localization;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using System.Diagnostics;
using System.IO;
using PublicManager.Modules.Editors;

namespace PublicManager.Modules.Module_A.PkgImporter
{
    public partial class MainView : XtraUserControl
    {
        List<string> unitList = new List<string>();

        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            unitList = DataHelper.getUnitList();
            tvUnitAndProject.ContentTreeView.AfterSelect += ContentTreeView_AfterSelect;
            updateCatalogs();
        }

        void ContentTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                //显示项目信息
                if (e.Node.Tag is Project)
                {
                    #region 显示数据
                    plContent.Controls.Clear();
                    ProjectEditor pe = new ProjectEditor();
                    pe.loadData((Project)e.Node.Tag);
                    pe.Dock = DockStyle.Fill;
                    plContent.Controls.Add(pe);
                    #endregion

                    lblHint.Text = "数量:1,金额:" + ((Project)e.Node.Tag).TotalMoney;
                }
            }
            else
            {
                //显示数量及金额
                int projCount = 0;
                decimal projMoneyCount = 0;

                //统计数量
                countMoneyAndCount(e.Node, ref projCount, ref projMoneyCount);

                lblHint.Text = "数量:" + projCount + ",金额:" + projMoneyCount;
            }
        }

        private void countMoneyAndCount(TreeNode treeNodess, ref int projCount, ref decimal projMoneyCount)
        {
            if (treeNodess.Tag is Project)
            {
                Project proj = (Project)treeNodess.Tag;
                projCount++;
                projMoneyCount += proj.TotalMoney;
            }
            foreach (TreeNode tnnnn in treeNodess.Nodes)
            {
                countMoneyAndCount(tnnnn, ref projCount, ref projMoneyCount);
            }
        }

        public void updateCatalogs()
        {
            tvUnitAndProject.ContentTreeView.Nodes.Clear();

            foreach (string unitS in unitList)
            {
                TreeNode parentNode = new TreeNode(unitS);

                Dictionary<string, TreeNode> unitParentDict = new Dictionary<string, TreeNode>();
                List<Project> projectList = ConnectionManager.Context.table("Project").where("UnitType2='" + unitS + "'").select("*").getList<Project>(new Project());
                foreach (Project proj in projectList)
                {
                    TreeNode smallUnitNode = null;
                    if (unitParentDict.ContainsKey(proj.UnitName))
                    {
                        smallUnitNode = unitParentDict[proj.UnitName];
                    }
                    else
                    {
                        unitParentDict[proj.UnitName] = new TreeNode(proj.UnitName);
                        smallUnitNode = unitParentDict[proj.UnitName];
                        parentNode.Nodes.Add(smallUnitNode);
                    }

                    TreeNode subObj = new TreeNode(proj.ProjectName);
                    subObj.Tag = proj;
                    smallUnitNode.Nodes.Add(subObj);
                }

                tvUnitAndProject.ContentTreeView.Nodes.Add(parentNode);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tvUnitAndProject.ContentTreeView.SelectedNode != null && tvUnitAndProject.ContentTreeView.SelectedNode.Tag is Project)
            {
                Project proj = (Project)tvUnitAndProject.ContentTreeView.SelectedNode.Tag;
                if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    new DBImporter().deleteProject(proj.CatalogID);
                    updateCatalogs();
                }
            }
        }
    }
}