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
            this.scUnitPage = new System.Windows.Forms.SplitContainer();
            this.tvUnitAndProject = new PublicManager.Modules.TreeViewWithSearch();
            this.plContent = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnDelAll = new System.Windows.Forms.Button();
            this.btnExportExcelForUnit = new System.Windows.Forms.Button();
            this.scUnitPage2 = new System.Windows.Forms.SplitContainer();
            this.tvUnitAndProject2 = new PublicManager.Modules.TreeViewWithSearch();
            this.plContent2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExportExcelForSubject = new System.Windows.Forms.Button();
            this.lblHint2 = new System.Windows.Forms.Label();
            this.xtcPages = new DevExpress.XtraTab.XtraTabControl();
            this.tpUnitPage = new DevExpress.XtraTab.XtraTabPage();
            this.tpSubjectAndDirectionPage = new DevExpress.XtraTab.XtraTabPage();
            this.btnRefreshUnitList = new System.Windows.Forms.Button();
            this.btnRefreshSubjectList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scUnitPage)).BeginInit();
            this.scUnitPage.Panel1.SuspendLayout();
            this.scUnitPage.Panel2.SuspendLayout();
            this.scUnitPage.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scUnitPage2)).BeginInit();
            this.scUnitPage2.Panel1.SuspendLayout();
            this.scUnitPage2.Panel2.SuspendLayout();
            this.scUnitPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcPages)).BeginInit();
            this.xtcPages.SuspendLayout();
            this.tpUnitPage.SuspendLayout();
            this.tpSubjectAndDirectionPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // scUnitPage
            // 
            this.scUnitPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scUnitPage.Location = new System.Drawing.Point(0, 0);
            this.scUnitPage.Name = "scUnitPage";
            // 
            // scUnitPage.Panel1
            // 
            this.scUnitPage.Panel1.Controls.Add(this.tvUnitAndProject);
            // 
            // scUnitPage.Panel2
            // 
            this.scUnitPage.Panel2.Controls.Add(this.plContent);
            this.scUnitPage.Panel2.Controls.Add(this.panel3);
            this.scUnitPage.Size = new System.Drawing.Size(1270, 655);
            this.scUnitPage.SplitterDistance = 244;
            this.scUnitPage.TabIndex = 1;
            // 
            // tvUnitAndProject
            // 
            this.tvUnitAndProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUnitAndProject.Font = new System.Drawing.Font("宋体", 12F);
            this.tvUnitAndProject.Location = new System.Drawing.Point(0, 0);
            this.tvUnitAndProject.Margin = new System.Windows.Forms.Padding(4);
            this.tvUnitAndProject.Name = "tvUnitAndProject";
            this.tvUnitAndProject.Size = new System.Drawing.Size(244, 655);
            this.tvUnitAndProject.TabIndex = 0;
            // 
            // plContent
            // 
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(0, 30);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1022, 625);
            this.plContent.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblHint);
            this.panel3.Controls.Add(this.btnRefreshUnitList);
            this.panel3.Controls.Add(this.btnDelAll);
            this.panel3.Controls.Add(this.btnExportExcelForUnit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1022, 30);
            this.panel3.TabIndex = 2;
            // 
            // lblHint
            // 
            this.lblHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHint.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.Location = new System.Drawing.Point(0, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(797, 30);
            this.lblHint.TabIndex = 1;
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelAll
            // 
            this.btnDelAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelAll.Location = new System.Drawing.Point(872, 0);
            this.btnDelAll.Name = "btnDelAll";
            this.btnDelAll.Size = new System.Drawing.Size(75, 30);
            this.btnDelAll.TabIndex = 3;
            this.btnDelAll.Text = "删除项目";
            this.btnDelAll.UseVisualStyleBackColor = true;
            this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
            // 
            // btnExportExcelForUnit
            // 
            this.btnExportExcelForUnit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportExcelForUnit.Location = new System.Drawing.Point(947, 0);
            this.btnExportExcelForUnit.Name = "btnExportExcelForUnit";
            this.btnExportExcelForUnit.Size = new System.Drawing.Size(75, 30);
            this.btnExportExcelForUnit.TabIndex = 2;
            this.btnExportExcelForUnit.Text = "导出Excel";
            this.btnExportExcelForUnit.UseVisualStyleBackColor = true;
            this.btnExportExcelForUnit.Click += new System.EventHandler(this.btnExportExcelForUnit_Click);
            // 
            // scUnitPage2
            // 
            this.scUnitPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scUnitPage2.Location = new System.Drawing.Point(0, 0);
            this.scUnitPage2.Name = "scUnitPage2";
            // 
            // scUnitPage2.Panel1
            // 
            this.scUnitPage2.Panel1.Controls.Add(this.tvUnitAndProject2);
            // 
            // scUnitPage2.Panel2
            // 
            this.scUnitPage2.Panel2.Controls.Add(this.plContent2);
            this.scUnitPage2.Panel2.Controls.Add(this.panel4);
            this.scUnitPage2.Size = new System.Drawing.Size(1270, 655);
            this.scUnitPage2.SplitterDistance = 244;
            this.scUnitPage2.TabIndex = 2;
            // 
            // tvUnitAndProject2
            // 
            this.tvUnitAndProject2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUnitAndProject2.Font = new System.Drawing.Font("宋体", 12F);
            this.tvUnitAndProject2.Location = new System.Drawing.Point(0, 0);
            this.tvUnitAndProject2.Margin = new System.Windows.Forms.Padding(4);
            this.tvUnitAndProject2.Name = "tvUnitAndProject2";
            this.tvUnitAndProject2.Size = new System.Drawing.Size(244, 655);
            this.tvUnitAndProject2.TabIndex = 0;
            // 
            // plContent2
            // 
            this.plContent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent2.Location = new System.Drawing.Point(0, 30);
            this.plContent2.Name = "plContent2";
            this.plContent2.Size = new System.Drawing.Size(1022, 625);
            this.plContent2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblHint2);
            this.panel4.Controls.Add(this.btnRefreshSubjectList);
            this.panel4.Controls.Add(this.btnExportExcelForSubject);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1022, 30);
            this.panel4.TabIndex = 2;
            // 
            // btnExportExcelForSubject
            // 
            this.btnExportExcelForSubject.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportExcelForSubject.Location = new System.Drawing.Point(947, 0);
            this.btnExportExcelForSubject.Name = "btnExportExcelForSubject";
            this.btnExportExcelForSubject.Size = new System.Drawing.Size(75, 30);
            this.btnExportExcelForSubject.TabIndex = 0;
            this.btnExportExcelForSubject.Text = "导出Excel";
            this.btnExportExcelForSubject.UseVisualStyleBackColor = true;
            this.btnExportExcelForSubject.Click += new System.EventHandler(this.btnExportExcelForSubject_Click);
            // 
            // lblHint2
            // 
            this.lblHint2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHint2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHint2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint2.Location = new System.Drawing.Point(0, 0);
            this.lblHint2.Name = "lblHint2";
            this.lblHint2.Size = new System.Drawing.Size(872, 30);
            this.lblHint2.TabIndex = 1;
            this.lblHint2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xtcPages
            // 
            this.xtcPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcPages.Location = new System.Drawing.Point(0, 0);
            this.xtcPages.Name = "xtcPages";
            this.xtcPages.SelectedTabPage = this.tpUnitPage;
            this.xtcPages.Size = new System.Drawing.Size(1276, 684);
            this.xtcPages.TabIndex = 3;
            this.xtcPages.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpUnitPage,
            this.tpSubjectAndDirectionPage});
            // 
            // tpUnitPage
            // 
            this.tpUnitPage.Controls.Add(this.scUnitPage);
            this.tpUnitPage.Name = "tpUnitPage";
            this.tpUnitPage.Size = new System.Drawing.Size(1270, 655);
            this.tpUnitPage.Text = "单位项目列表";
            // 
            // tpSubjectAndDirectionPage
            // 
            this.tpSubjectAndDirectionPage.Controls.Add(this.scUnitPage2);
            this.tpSubjectAndDirectionPage.Name = "tpSubjectAndDirectionPage";
            this.tpSubjectAndDirectionPage.Size = new System.Drawing.Size(1270, 655);
            this.tpSubjectAndDirectionPage.Text = "主题方向与项目列表";
            // 
            // btnRefreshUnitList
            // 
            this.btnRefreshUnitList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefreshUnitList.Location = new System.Drawing.Point(797, 0);
            this.btnRefreshUnitList.Name = "btnRefreshUnitList";
            this.btnRefreshUnitList.Size = new System.Drawing.Size(75, 30);
            this.btnRefreshUnitList.TabIndex = 4;
            this.btnRefreshUnitList.Text = "刷新列表";
            this.btnRefreshUnitList.UseVisualStyleBackColor = true;
            this.btnRefreshUnitList.Click += new System.EventHandler(this.btnRefreshUnitList_Click);
            // 
            // btnRefreshSubjectList
            // 
            this.btnRefreshSubjectList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefreshSubjectList.Location = new System.Drawing.Point(872, 0);
            this.btnRefreshSubjectList.Name = "btnRefreshSubjectList";
            this.btnRefreshSubjectList.Size = new System.Drawing.Size(75, 30);
            this.btnRefreshSubjectList.TabIndex = 5;
            this.btnRefreshSubjectList.Text = "刷新列表";
            this.btnRefreshSubjectList.UseVisualStyleBackColor = true;
            this.btnRefreshSubjectList.Click += new System.EventHandler(this.btnRefreshSubjectList_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtcPages);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1276, 684);
            this.scUnitPage.Panel1.ResumeLayout(false);
            this.scUnitPage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scUnitPage)).EndInit();
            this.scUnitPage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.scUnitPage2.Panel1.ResumeLayout(false);
            this.scUnitPage2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scUnitPage2)).EndInit();
            this.scUnitPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtcPages)).EndInit();
            this.xtcPages.ResumeLayout(false);
            this.tpUnitPage.ResumeLayout(false);
            this.tpSubjectAndDirectionPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeViewWithSearch tvUnitAndProject;
        private System.Windows.Forms.SplitContainer scUnitPage;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.SplitContainer scUnitPage2;
        private TreeViewWithSearch tvUnitAndProject2;
        private System.Windows.Forms.Panel plContent2;
        private System.Windows.Forms.Label lblHint2;
        private DevExpress.XtraTab.XtraTabControl xtcPages;
        private DevExpress.XtraTab.XtraTabPage tpUnitPage;
        private DevExpress.XtraTab.XtraTabPage tpSubjectAndDirectionPage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExportExcelForUnit;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnExportExcelForSubject;
        private System.Windows.Forms.Button btnDelAll;
        private System.Windows.Forms.Button btnRefreshUnitList;
        private System.Windows.Forms.Button btnRefreshSubjectList;



    }
}
