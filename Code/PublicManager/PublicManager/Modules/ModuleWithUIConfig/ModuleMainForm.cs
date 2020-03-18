using DevExpress.XtraTreeList;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PublicManager.Modules.ModuleWithUIConfig
{
    public class ModuleMainForm : BaseModuleMainFormWithUIConfig
    {
        private DevExpress.XtraTreeList.TreeList treeListObj;
        private DevExpress.XtraNavBar.NavBarGroup firstPage;

        public ModuleMainForm()
            : base()
        {
            Text = "军队主管部门汇总系统";
        }

        protected override void initMenus()
        {
            base.initMenus();

            //menuController = new MainMenuController();
            //menuController.MenuControl.Width = 0;
            //menuController.MenuControl.Height = 0;
            //Controls.Add(menuController.MenuControl);
            //rcTopBar.ApplicationButtonDropDownControl = menuController.MenuControl;
        }

        protected override void initModules()
        {
            base.initModules();

            //ModuleDict["XXXX模块"] = new XXXX.YYYY();
        }

        protected override void initUI()
        {
            base.initUI();

            Text = "带皮肤配置的主界面";

            treeListObj = buildTreeControl(new string[] { string.Empty }, new string[] { "数据包汇总", "专业类别维护", "数据编辑", "数据导出", "数据包编辑" });

            treeListObj.MouseClick += treeListObj_MouseClick;
            firstPage = appendPage("数据汇总", PublicManager.Properties.Resources.Mail_32x32);
            firstPage.ControlContainer.Controls.Add(treeListObj);
        }

        void treeListObj_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tree = ((DevExpress.XtraTreeList.TreeList)sender);
            Point p = new Point(e.X, e.Y);　　//获取到鼠标点击的坐标位置
            TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
            if (hitInfo.HitInfoType == HitInfoType.Cell)
            {
                tree.SetFocusedNode(hitInfo.Node);         //这句话就是关键，用于选中节点　　

                //显示模块
                showModule(hitInfo.Node.GetDisplayText(0), true);
            }
        }
    }
}