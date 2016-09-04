﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Li.Controls
{
    public partial class DataGridViewEx : DevComponents.DotNetBar.Controls.DataGridViewX 
    {
        public int OffsetIndex = 0;
        public DataGridViewEx()
        {
            InitializeComponent();
        }
        public new void StyleManagerStyleChanged(DevComponents.DotNetBar.eDotNetBarStyle newStyle)
        {
            try
            {
                base.StyleManagerStyleChanged(newStyle);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
          
        }
        

        private void DataGridViewEx_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = 
                new System.Drawing.Rectangle(
                    e.RowBounds.Location.X,
                    e.RowBounds.Location.Y,
                    this.RowHeadersWidth - 4,
                    e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1 + OffsetIndex).ToString(),
                this.RowHeadersDefaultCellStyle.Font,
                rectangle,
                this.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void DataGridViewEx_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = this.Rows[e.RowIndex];
            foreach (DataGridViewCell item in row.Cells)
            {
                if (item.Value == DBNull.Value)
                {
                    item.Value = null;
                }
            }
        }
        
    }

    public class DataGridViewLinkLabelCell:DataGridViewLinkCell
    {
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }
        // Force the cell to repaint itself when the mouse pointer enters it.
        protected override void OnMouseEnter(int rowIndex)
        {
            this.DataGridView.InvalidateCell(this);
        }

        // Force the cell to repaint itself when the mouse pointer leaves it.
        protected override void OnMouseLeave(int rowIndex)
        {
            this.DataGridView.InvalidateCell(this);
        }
    }
    public class DataGridViewLinkLabelColumn : DataGridViewLinkColumn
    {
        private string _splitLinkSymbol = ",";
        public string SplitLinkSymbol
        {
            get
            {
                return _splitLinkSymbol;
            }
            set
            {
                if (value==null|| value=="")
                {
                    return;
                }
                _splitLinkSymbol = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }
        public DataGridViewLinkLabelColumn()
        {
            this.CellTemplate = new DataGridViewLinkLabelCell();
        }
    }

}
