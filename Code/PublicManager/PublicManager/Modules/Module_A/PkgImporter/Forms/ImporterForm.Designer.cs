namespace PublicManager.Modules.Module_A.PkgImporter.Forms
{
    partial class ImporterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlTestA = new System.Windows.Forms.TreeView();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tlAll = new System.Windows.Forms.TreeView();
            this.gcIgnoreList = new DevExpress.XtraEditors.GroupControl();
            this.tlErrorList = new System.Windows.Forms.TreeView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSelectAllOrUnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.rcTopBar = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.bsiBottomText = new DevExpress.XtraBars.BarStaticItem();
            this.btnSelectNotInList = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIgnoreList)).BeginInit();
            this.gcIgnoreList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 27);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlTestA);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1103, 513);
            this.splitContainerControl1.SplitterPosition = 295;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tlTestA
            // 
            this.tlTestA.CheckBoxes = true;
            this.tlTestA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlTestA.FullRowSelect = true;
            this.tlTestA.HideSelection = false;
            this.tlTestA.Location = new System.Drawing.Point(0, 0);
            this.tlTestA.Name = "tlTestA";
            this.tlTestA.Size = new System.Drawing.Size(295, 513);
            this.tlTestA.TabIndex = 0;
            this.tlTestA.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tlTestA_AfterCheck);
            this.tlTestA.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tlTestA_AfterSelect);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.gcIgnoreList);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(803, 513);
            this.splitContainerControl2.SplitterPosition = 432;
            this.splitContainerControl2.TabIndex = 2;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tlAll);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(432, 513);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "已导入项目列表";
            // 
            // tlAll
            // 
            this.tlAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAll.Location = new System.Drawing.Point(2, 21);
            this.tlAll.Name = "tlAll";
            this.tlAll.Size = new System.Drawing.Size(428, 490);
            this.tlAll.TabIndex = 0;
            // 
            // gcIgnoreList
            // 
            this.gcIgnoreList.Controls.Add(this.tlErrorList);
            this.gcIgnoreList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcIgnoreList.Location = new System.Drawing.Point(0, 0);
            this.gcIgnoreList.Name = "gcIgnoreList";
            this.gcIgnoreList.Size = new System.Drawing.Size(366, 513);
            this.gcIgnoreList.TabIndex = 0;
            this.gcIgnoreList.Text = "是否需要覆盖已存在数据？";
            // 
            // tlErrorList
            // 
            this.tlErrorList.CheckBoxes = true;
            this.tlErrorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlErrorList.Enabled = false;
            this.tlErrorList.Location = new System.Drawing.Point(2, 21);
            this.tlErrorList.Name = "tlErrorList";
            this.tlErrorList.Size = new System.Drawing.Size(362, 490);
            this.tlErrorList.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnSelectNotInList);
            this.panelControl2.Controls.Add(this.btnSelectAllOrUnSelectAll);
            this.panelControl2.Controls.Add(this.btnOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 540);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1103, 44);
            this.panelControl2.TabIndex = 5;
            // 
            // btnSelectAllOrUnSelectAll
            // 
            this.btnSelectAllOrUnSelectAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelectAllOrUnSelectAll.Location = new System.Drawing.Point(2, 2);
            this.btnSelectAllOrUnSelectAll.Name = "btnSelectAllOrUnSelectAll";
            this.btnSelectAllOrUnSelectAll.Size = new System.Drawing.Size(106, 40);
            this.btnSelectAllOrUnSelectAll.TabIndex = 1;
            this.btnSelectAllOrUnSelectAll.Text = "全选/全不选";
            this.btnSelectAllOrUnSelectAll.Click += new System.EventHandler(this.btnSelectAllOrUnSelectAll_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(1017, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "导入";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rcTopBar
            // 
            this.rcTopBar.AutoHideEmptyItems = true;
            this.rcTopBar.AutoSaveLayoutToXml = true;
            this.rcTopBar.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            this.rcTopBar.DrawGroupsBorder = false;
            this.rcTopBar.ExpandCollapseItem.Id = 0;
            this.rcTopBar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcTopBar.ExpandCollapseItem,
            this.barCheckItem1,
            this.ribbonGalleryBarItem1,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.bsiBottomText});
            this.rcTopBar.Location = new System.Drawing.Point(0, 0);
            this.rcTopBar.MaxItemId = 13;
            this.rcTopBar.Name = "rcTopBar";
            this.rcTopBar.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcTopBar.ShowCategoryInCaption = false;
            this.rcTopBar.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcTopBar.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcTopBar.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.rcTopBar.ShowQatLocationSelector = false;
            this.rcTopBar.ShowToolbarCustomizeItem = false;
            this.rcTopBar.Size = new System.Drawing.Size(1103, 27);
            this.rcTopBar.Toolbar.ShowCustomizeItem = false;
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "演示选择";
            this.barCheckItem1.Id = 1;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Caption = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.Id = 4;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 7;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 8;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 9;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 10;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Id = 11;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // bsiBottomText
            // 
            this.bsiBottomText.Caption = "...";
            this.bsiBottomText.Id = 12;
            this.bsiBottomText.Name = "bsiBottomText";
            this.bsiBottomText.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnSelectNotInList
            // 
            this.btnSelectNotInList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelectNotInList.Location = new System.Drawing.Point(108, 2);
            this.btnSelectNotInList.Name = "btnSelectNotInList";
            this.btnSelectNotInList.Size = new System.Drawing.Size(106, 40);
            this.btnSelectNotInList.TabIndex = 2;
            this.btnSelectNotInList.Text = "增加选择";
            this.btnSelectNotInList.Click += new System.EventHandler(this.btnSelectNotInList_Click);
            // 
            // ImporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 584);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.rcTopBar);
            this.MaximizeBox = false;
            this.Name = "ImporterForm";
            this.Ribbon = this.rcTopBar;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcIgnoreList)).EndInit();
            this.gcIgnoreList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl gcIgnoreList;
        private System.Windows.Forms.TreeView tlTestA;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnSelectAllOrUnSelectAll;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        protected DevExpress.XtraBars.Ribbon.RibbonControl rcTopBar;
        protected DevExpress.XtraBars.BarCheckItem barCheckItem1;
        protected DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem3;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem4;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem5;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem6;
        protected DevExpress.XtraBars.BarStaticItem bsiBottomText;
        private System.Windows.Forms.TreeView tlErrorList;
        private System.Windows.Forms.TreeView tlAll;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SimpleButton btnSelectNotInList;
    }
}