namespace PublicManager.Modules.Module_A.PkgImporter
{
    partial class MainView
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
            this.tcPages = new System.Windows.Forms.TabControl();
            this.tpUnitPage = new System.Windows.Forms.TabPage();
            this.tpSubjectAndDirectionPage = new System.Windows.Forms.TabPage();
            this.scUnitPage2 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.plContent2 = new System.Windows.Forms.Panel();
            this.lblHint2 = new System.Windows.Forms.Label();
            this.scUnitPage = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.plContent = new System.Windows.Forms.Panel();
            this.lblHint = new System.Windows.Forms.Label();
            this.tvUnitAndProject2 = new PublicManager.Modules.TreeViewWithSearch();
            this.tvUnitAndProject = new PublicManager.Modules.TreeViewWithSearch();
            this.tcPages.SuspendLayout();
            this.tpUnitPage.SuspendLayout();
            this.tpSubjectAndDirectionPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scUnitPage2)).BeginInit();
            this.scUnitPage2.Panel1.SuspendLayout();
            this.scUnitPage2.Panel2.SuspendLayout();
            this.scUnitPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scUnitPage)).BeginInit();
            this.scUnitPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPages
            // 
            this.tcPages.Controls.Add(this.tpUnitPage);
            this.tcPages.Controls.Add(this.tpSubjectAndDirectionPage);
            this.tcPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPages.Location = new System.Drawing.Point(0, 0);
            this.tcPages.Name = "tcPages";
            this.tcPages.SelectedIndex = 0;
            this.tcPages.Size = new System.Drawing.Size(1276, 684);
            this.tcPages.TabIndex = 2;
            // 
            // tpUnitPage
            // 
            this.tpUnitPage.Controls.Add(this.scUnitPage);
            this.tpUnitPage.Location = new System.Drawing.Point(4, 23);
            this.tpUnitPage.Name = "tpUnitPage";
            this.tpUnitPage.Padding = new System.Windows.Forms.Padding(3);
            this.tpUnitPage.Size = new System.Drawing.Size(1268, 657);
            this.tpUnitPage.TabIndex = 0;
            this.tpUnitPage.Text = "单位项目列表";
            this.tpUnitPage.UseVisualStyleBackColor = true;
            // 
            // tpSubjectAndDirectionPage
            // 
            this.tpSubjectAndDirectionPage.Controls.Add(this.scUnitPage2);
            this.tpSubjectAndDirectionPage.Location = new System.Drawing.Point(4, 23);
            this.tpSubjectAndDirectionPage.Name = "tpSubjectAndDirectionPage";
            this.tpSubjectAndDirectionPage.Padding = new System.Windows.Forms.Padding(3);
            this.tpSubjectAndDirectionPage.Size = new System.Drawing.Size(1268, 657);
            this.tpSubjectAndDirectionPage.TabIndex = 1;
            this.tpSubjectAndDirectionPage.Text = "主题方向与项目列表";
            this.tpSubjectAndDirectionPage.UseVisualStyleBackColor = true;
            // 
            // scUnitPage2
            // 
            this.scUnitPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scUnitPage2.Location = new System.Drawing.Point(3, 3);
            this.scUnitPage2.Name = "scUnitPage2";
            // 
            // scUnitPage2.Panel1
            // 
            this.scUnitPage2.Panel1.Controls.Add(this.tvUnitAndProject2);
            this.scUnitPage2.Panel1.Controls.Add(this.panel2);
            // 
            // scUnitPage2.Panel2
            // 
            this.scUnitPage2.Panel2.Controls.Add(this.plContent2);
            this.scUnitPage2.Panel2.Controls.Add(this.lblHint2);
            this.scUnitPage2.Size = new System.Drawing.Size(1262, 651);
            this.scUnitPage2.SplitterDistance = 243;
            this.scUnitPage2.TabIndex = 2;
            // 
            // scUnitPage.Panel1
            // 
            this.scUnitPage.Panel1.Controls.Add(this.tvUnitAndProject);
            this.scUnitPage.Panel1.Controls.Add(this.panel1);
            // 
            // scUnitPage.Panel2
            // 
            this.scUnitPage.Panel2.Controls.Add(this.plContent);
            this.scUnitPage.Panel2.Controls.Add(this.lblHint);
            this.scUnitPage.Size = new System.Drawing.Size(1262, 651);
            this.scUnitPage.SplitterDistance = 243;
            this.scUnitPage.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 620);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 31);
            this.panel2.TabIndex = 1;
            // 
            // btnDelete2
            // 
            this.btnDelete2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete2.Location = new System.Drawing.Point(0, 0);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(243, 31);
            this.btnDelete2.TabIndex = 0;
            this.btnDelete2.Text = "删除选中项";
            this.btnDelete2.UseVisualStyleBackColor = true;
            // 
            // plContent2
            // 
            this.plContent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent2.Location = new System.Drawing.Point(0, 37);
            this.plContent2.Name = "plContent2";
            this.plContent2.Size = new System.Drawing.Size(1015, 614);
            this.plContent2.TabIndex = 0;
            // 
            // lblHint2
            // 
            this.lblHint2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHint2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHint2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint2.Location = new System.Drawing.Point(0, 0);
            this.lblHint2.Name = "lblHint2";
            this.lblHint2.Size = new System.Drawing.Size(1015, 37);
            this.lblHint2.TabIndex = 1;
            this.lblHint2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scUnitPage
            // 
            this.scUnitPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scUnitPage.Location = new System.Drawing.Point(3, 3);
            this.scUnitPage.Name = "scUnitPage";
            this.scUnitPage.Size = new System.Drawing.Size(1262, 651);
            this.scUnitPage.SplitterDistance = 243;
            this.scUnitPage.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 620);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 31);
            this.panel1.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(243, 31);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "删除选中项";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // plContent
            // 
            this.plContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.plContent.Location = new System.Drawing.Point(0, 37);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1015, 614);
            this.plContent.TabIndex = 0;
            // 
            // lblHint
            // 
            this.lblHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHint.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.Location = new System.Drawing.Point(0, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(1015, 37);
            this.lblHint.TabIndex = 1;
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tvUnitAndProject2
            // 
            this.tvUnitAndProject2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUnitAndProject2.Font = new System.Drawing.Font("仿宋", 12F);
            this.tvUnitAndProject2.Location = new System.Drawing.Point(0, 0);
            this.tvUnitAndProject2.Margin = new System.Windows.Forms.Padding(4);
            this.tvUnitAndProject2.Name = "tvUnitAndProject2";
            this.tvUnitAndProject2.Size = new System.Drawing.Size(243, 620);
            this.tvUnitAndProject2.TabIndex = 0;
            // 
            // tvUnitAndProject
            // 
            this.tvUnitAndProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUnitAndProject.Font = new System.Drawing.Font("仿宋", 12F);
            this.tvUnitAndProject.Location = new System.Drawing.Point(0, 0);
            this.tvUnitAndProject.Margin = new System.Windows.Forms.Padding(4);
            this.tvUnitAndProject.Name = "tvUnitAndProject";
            this.tvUnitAndProject.Size = new System.Drawing.Size(243, 620);
            this.tvUnitAndProject.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcPages);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1276, 684);
            this.tcPages.ResumeLayout(false);
            this.tpUnitPage.ResumeLayout(false);
            this.tpSubjectAndDirectionPage.ResumeLayout(false);
            this.scUnitPage2.Panel1.ResumeLayout(false);
            this.scUnitPage2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scUnitPage2)).EndInit();
            this.scUnitPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scUnitPage)).EndInit();
            this.scUnitPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeViewWithSearch tvUnitAndProject;
        private System.Windows.Forms.SplitContainer scUnitPage;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.TabControl tcPages;
        private System.Windows.Forms.TabPage tpUnitPage;
        private System.Windows.Forms.TabPage tpSubjectAndDirectionPage;
        private System.Windows.Forms.SplitContainer scUnitPage2;
        private TreeViewWithSearch tvUnitAndProject2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete2;
        private System.Windows.Forms.Panel plContent2;
        private System.Windows.Forms.Label lblHint2;



    }
}
