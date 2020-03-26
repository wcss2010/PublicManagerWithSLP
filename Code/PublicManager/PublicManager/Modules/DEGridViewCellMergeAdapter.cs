using System;
using System.Collections.Generic;
using System.Text;

namespace PublicManager.Modules
{
    public class DEGridViewCellMergeAdapter
    {
        private DevExpress.XtraGrid.Views.Grid.GridView myGridView;
        private List<string> mergeFieldNameList = new List<string>();

        public DEGridViewCellMergeAdapter(DevExpress.XtraGrid.Views.Grid.GridView gv, string[] mergeColNames)
        {
            this.myGridView = gv;
            this.myGridView.OptionsView.AllowCellMerge = true;
            this.myGridView.CellMerge += myGridView_CellMerge;
            mergeFieldNameList.AddRange(mergeColNames);
        }

        void myGridView_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (!mergeFieldNameList.Contains(e.Column.FieldName))
            {
                e.Merge = false; //值相同的2个单元格是否要合并在一起
                e.Handled = true; //合并单元格是否已经处理过，无需再次进行省缺处理
            }
        }
    }
}