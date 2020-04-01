namespace PublicManager.Modules
{
    partial class TreeViewWithSearch
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tvDetail = new PublicManager.Modules.TreeViewEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNodeKeys = new System.Windows.Forms.TextBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvDetail
            // 
            this.tvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDetail.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvDetail.FocusNodeBackColor = System.Drawing.Color.OrangeRed;
            this.tvDetail.FocusNodeFontColor = System.Drawing.Color.White;
            this.tvDetail.FullRowSelect = true;
            this.tvDetail.HideSelection = false;
            this.tvDetail.Location = new System.Drawing.Point(0, 28);
            this.tvDetail.Name = "tvDetail";
            this.tvDetail.NoFocusNodeBackColor = System.Drawing.Color.White;
            this.tvDetail.NoFocusNodeFontColor = System.Drawing.Color.Black;
            this.tvDetail.SelectedNodeBackColor = System.Drawing.Color.LightGreen;
            this.tvDetail.SelectedNodeFontColor = System.Drawing.Color.White;
            this.tvDetail.Size = new System.Drawing.Size(580, 691);
            this.tvDetail.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNodeKeys);
            this.panel1.Controls.Add(this.lblHint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 28);
            this.panel1.TabIndex = 2;
            // 
            // txtNodeKeys
            // 
            this.txtNodeKeys.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNodeKeys.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNodeKeys.Location = new System.Drawing.Point(78, 0);
            this.txtNodeKeys.Margin = new System.Windows.Forms.Padding(4);
            this.txtNodeKeys.Name = "txtNodeKeys";
            this.txtNodeKeys.Size = new System.Drawing.Size(502, 26);
            this.txtNodeKeys.TabIndex = 1;
            this.txtNodeKeys.TextChanged += new System.EventHandler(this.txtNodeKeys_TextChanged);
            // 
            // lblHint
            // 
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHint.Location = new System.Drawing.Point(0, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(78, 28);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "关建字：";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TreeViewWithSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvDetail);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TreeViewWithSearch";
            this.Size = new System.Drawing.Size(580, 719);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TreeViewEx tvDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNodeKeys;
        private System.Windows.Forms.Label lblHint;
    }
}
