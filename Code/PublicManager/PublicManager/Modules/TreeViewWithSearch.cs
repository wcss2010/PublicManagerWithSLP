using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules
{
    public partial class TreeViewWithSearch : UserControl
    {
        private List<TreeNode> listSearchTreeNodes;

        public Label SearchTextBoxLabel { get { return lblHint; } }

        public TextBox SearchTextBox { get { return txtNodeKeys; } }

        public TreeViewEx ContentTreeView { get { return tvDetail; } }

        public TreeViewWithSearch()
        {
            InitializeComponent();
        }

        private void txtNodeKeys_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text.Trim()))
            {
                if (listSearchTreeNodes != null)
                {
                    for (int i = 0; i < listSearchTreeNodes.Count; i++)
                    {
                        TreeNode trNode = listSearchTreeNodes[i];
                        trNode.BackColor = ContentTreeView.NoFocusNodeBackColor;
                        trNode.ForeColor = ContentTreeView.NoFocusNodeFontColor;
                    }
                    ContentTreeView.SelectedNode = null;
                }
                return;
            }

            if (listSearchTreeNodes != null)
            {
                for (int i = 0; i < listSearchTreeNodes.Count; i++)
                {
                    TreeNode trNode = listSearchTreeNodes[i];
                    trNode.BackColor = ContentTreeView.NoFocusNodeBackColor;
                    trNode.ForeColor = ContentTreeView.NoFocusNodeFontColor;
                }
                ContentTreeView.SelectedNode = null;
            }

            listSearchTreeNodes = new List<TreeNode>();
            foreach (TreeNode node in ContentTreeView.Nodes)  //Mange_TreeView是treeview控件名称
            {
                SearchLayer(node, this.SearchTextBox.Text.Trim());
            }

            for (int i = 0; i < listSearchTreeNodes.Count; i++)
            {
                TreeNode trNode = listSearchTreeNodes[i];
                ExpandNode(trNode);
                if (i == 0 && trNode.Parent != null)
                {
                    ContentTreeView.SelectedNode = trNode.Parent;
                }
                trNode.BackColor = ContentTreeView.FocusNodeBackColor;
                trNode.ForeColor = ContentTreeView.FocusNodeFontColor;
            }
        }

        /// <summary>
        /// 节点查询
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        private void SearchLayer(TreeNode node, string name)
        {
            if (node.Nodes.Count != 0)
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    SearchLayer(node.Nodes[i], name);
                }
            }

            if (string.Equals(node.Text, name) || node.Text.Contains(name))
            {
                listSearchTreeNodes.Add(node);
            }

            node.BackColor = ContentTreeView.NoFocusNodeBackColor;
            node.ForeColor = ContentTreeView.NoFocusNodeFontColor;
        }

        /// <summary>
        /// 展开节点
        /// </summary>
        /// <param name="node"></param>
        public void ExpandNode(TreeNode node)
        {
            node.Expand();

            if (node.Parent != null)
            {                
                ExpandNode(node.Parent);
            }
        }
    }

    public class TreeViewEx : TreeView
    {
        private Color focusNodeBackColor = Color.OrangeRed;
        public Color FocusNodeBackColor
        {
            get { return focusNodeBackColor; }
            set { focusNodeBackColor = value; }
        }

        private Color focusNodeFontColor = Color.White;
        public Color FocusNodeFontColor
        {
            get { return focusNodeFontColor; }
            set { focusNodeFontColor = value; }
        }

        private Color nofocusNodeBackColor = Color.White;
        public Color NoFocusNodeBackColor
        {
            get { return nofocusNodeBackColor; }
            set { nofocusNodeBackColor = value; }
        }

        private Color nofocusNodeFontColor = Color.Black;
        public Color NoFocusNodeFontColor
        {
            get { return nofocusNodeFontColor; }
            set { nofocusNodeFontColor = value; }
        }

        private Color selectedNodeBackColor = Color.LightGreen;
        public Color SelectedNodeBackColor
        {
            get { return selectedNodeBackColor; }
            set { selectedNodeBackColor = value; }
        }

        private Color selectedNodeFontColor = Color.White;
        public Color SelectedNodeFontColor
        {
            get { return selectedNodeFontColor; }
            set { selectedNodeFontColor = value; }
        }

        public TreeViewEx() : base()
        {
            HideSelection = false;
            DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            //读取默认设置
            TreeNodeStates currentState = e.State;
            Font currentFont = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color currentFontColor = e.Node.ForeColor;
            Color currentBackColor = e.Node.BackColor;
            if (currentFontColor == Color.Empty)
            {
                currentFontColor = NoFocusNodeFontColor;
            }
            if (currentBackColor == Color.Empty)
            {
                currentBackColor = NoFocusNodeBackColor;
            }

            if (e.Node == e.Node.TreeView.SelectedNode)
            {
                //选中状态
                e.Graphics.FillRectangle(new SolidBrush(SelectedNodeBackColor), e.Bounds);
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, currentFontColor, SelectedNodeBackColor);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, currentFont, e.Bounds, SelectedNodeFontColor, SelectedNodeBackColor, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                //非选中状态
                e.Graphics.FillRectangle(new SolidBrush(currentBackColor), e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, currentFont, e.Bounds, currentFontColor, TextFormatFlags.GlyphOverhangPadding);
            }
        }
    }
}