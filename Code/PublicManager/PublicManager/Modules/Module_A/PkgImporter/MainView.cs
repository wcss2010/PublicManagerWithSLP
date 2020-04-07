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
        public TreeView UnitTreeViewList
        {
            get
            {
                return tvUnitAndProject.ContentTreeView;
            }
        }

        public TreeView SubjectTreeViewList
        {
            get
            {
                return tvUnitAndProject2.ContentTreeView;
            }
        }

        List<string> unitList = new List<string>();
        private Dictionary<string, List<string>> subjectDict = new Dictionary<string, List<string>>();

        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            unitList = DataHelper.getUnitList();
            subjectDict = DataHelper.getSubjectList();
            tvUnitAndProject.ContentTreeView.AfterSelect += ContentTreeView_AfterSelect;
            tvUnitAndProject2.ContentTreeView.AfterSelect += ContentTreeView2_AfterSelect;
            updateTreeViews();
        }

        public void updateTreeViews()
        {
            updateUnitTreeView();
            updateSubjectTreeView();
        }

        private void updateSubjectTreeView()
        {
            #region 创建根节点
            tvUnitAndProject2.ContentTreeView.Nodes.Clear();
            Dictionary<string, TreeNode> nodeDict = new Dictionary<string, TreeNode>();
            foreach (KeyValuePair<string, List<string>> kvp in subjectDict)
            {
                TreeNode firstNode = new TreeNode(kvp.Key);
                nodeDict[kvp.Key] = firstNode;
                tvUnitAndProject2.ContentTreeView.Nodes.Add(nodeDict[kvp.Key]);

                foreach (string subs in kvp.Value)
                {
                    TreeNode secondNode = new TreeNode(subs);
                    nodeDict[kvp.Key + "****" + subs] = secondNode;
                    firstNode.Nodes.Add(secondNode);
                }
            }
            nodeDict["其它"] = new TreeNode("其它");
            tvUnitAndProject2.ContentTreeView.Nodes.Add(nodeDict["其它"]);
            #endregion

            #region 创建子节点
            List<Project> projList = ConnectionManager.Context.table("Project").select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
                TreeNode topicNode = null;
                string directionKey = string.Empty;
                if (nodeDict.ContainsKey(proj.ProjectTopic))
                {
                    //正常主题
                    if (subjectDict.ContainsKey(proj.ProjectTopic))
                    {
                        if (subjectDict[proj.ProjectTopic].Contains(proj.ProjectDirection))
                        {
                            topicNode = nodeDict[proj.ProjectTopic];
                            directionKey = proj.ProjectTopic + "****" + proj.ProjectDirection;
                        }
                        else
                        {
                            //其它主题
                            topicNode = nodeDict["其它"];
                            directionKey = "其它" + "****" + proj.ProjectDirection;
                        }
                    }
                    else
                    {
                        //其它主题
                        topicNode = nodeDict["其它"];
                        directionKey = "其它" + "****" + proj.ProjectDirection;
                    }
                }
                else
                {
                    //其它主题
                    topicNode = nodeDict["其它"];
                    directionKey = "其它" + "****" + proj.ProjectDirection;
                }

                if (nodeDict.ContainsKey(directionKey))
                {
                    //有
                    TreeNode projectNode = new TreeNode(proj.ProjectName);
                    projectNode.Tag = proj;

                    nodeDict[directionKey].Nodes.Add(projectNode);
                }
                else
                {
                    //没有
                    TreeNode projectNode = new TreeNode(proj.ProjectName);
                    projectNode.Tag = proj;

                    nodeDict[directionKey] = new TreeNode(proj.ProjectDirection);
                    nodeDict[directionKey].Nodes.Add(projectNode);
                    topicNode.Nodes.Add(nodeDict[directionKey]);
                }
            }
            #endregion

            foreach (KeyValuePair<string, TreeNode> kvp in nodeDict)
            {
                if (kvp.Key.Contains("****"))
                {
                    kvp.Value.ExpandAll();
                }
            }
        }

        void ContentTreeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                //显示项目信息
                if (e.Node.Tag is Project)
                {
                    #region 显示数据
                    plContent2.Controls.Clear();
                    ProjectEditor pe = new ProjectEditor();
                    pe.loadData((Project)e.Node.Tag);
                    pe.Dock = DockStyle.Fill;
                    plContent2.Controls.Add(pe);
                    #endregion

                    lblHint2.Text = "数量:1,金额:" + ((Project)e.Node.Tag).TotalMoney;
                }
            }
            else
            {
                plContent.Controls.Clear();
                plContent2.Controls.Clear();

                //显示数量及金额
                int projCount = 0;
                decimal projMoneyCount = 0;

                //统计数量
                countMoneyAndCount(e.Node, ref projCount, ref projMoneyCount);

                lblHint2.Text = "数量:" + projCount + ",金额:" + projMoneyCount;
            }
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
                plContent.Controls.Clear();
                plContent2.Controls.Clear();

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

        public void updateUnitTreeView()
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

        private void btnExportExcelForUnit_Click(object sender, EventArgs e)
        {
            //基本数据
            DataTable dtBase = ExcelHelper.getProjectExcelDataTable();

            if (tvUnitAndProject.ContentTreeView.SelectedNode != null)
            {
                printProjectNode(dtBase, tvUnitAndProject.ContentTreeView.SelectedNode);
                ExcelHelper.ExportToExcel(dtBase, "项目列表");
            }
        }

        private void printProjectNode(DataTable dtBase, TreeNode treeNode)
        {
            foreach (TreeNode suba in treeNode.Nodes)
            {
                printProjectNode(dtBase, suba);
            }

            if (treeNode.Tag is Project)
            {
                Project p = (Project)treeNode.Tag;

                //打印数据
                ExcelHelper.printProjectToDataTable(dtBase, p);
            }
        }

        private void btnExportExcelForSubject_Click(object sender, EventArgs e)
        {
            //基本数据
            DataTable dtBase = ExcelHelper.getProjectExcelDataTable();

            if (tvUnitAndProject2.ContentTreeView.SelectedNode != null)
            {
                printProjectNode(dtBase, tvUnitAndProject2.ContentTreeView.SelectedNode);
                ExcelHelper.ExportToExcel(dtBase, "项目列表");
            }
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            if (tvUnitAndProject.ContentTreeView.SelectedNode != null)
            {
                if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DBImporter dii = new DBImporter();

                    List<Project> needDeleteCatalogList = new List<Project>();
                    getCatalogListForTreeNode(tvUnitAndProject.ContentTreeView.SelectedNode, needDeleteCatalogList);

                    foreach (Project catalogObj in needDeleteCatalogList)
                    {
                        dii.deleteProject(catalogObj.CatalogID);
                    }

                    updateTreeViews();
                }
            }
        }

        private void getCatalogListForTreeNode(TreeNode parentNode, List<Project> needDeleteCatalogList)
        {
            foreach (TreeNode tn in parentNode.Nodes)
            {
                getCatalogListForTreeNode(tn, needDeleteCatalogList);
            }

            if (parentNode.Tag is Project)
            {
                needDeleteCatalogList.Add(((Project)parentNode.Tag));
            }
        }

        private void btnRefreshUnitList_Click(object sender, EventArgs e)
        {
            updateUnitTreeView();
        }

        private void btnRefreshSubjectList_Click(object sender, EventArgs e)
        {
            updateSubjectTreeView();
        }
    }
}