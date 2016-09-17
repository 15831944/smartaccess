﻿namespace SmartAccess.RealDetectMgr
{
    partial class RealDoorState
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealDoorState));
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("11111", 0);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("22222", 2);
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biSelectAll = new DevComponents.DotNetBar.ButtonItem();
            this.biRealDetect = new DevComponents.DotNetBar.ButtonItem();
            this.biStop = new DevComponents.DotNetBar.ButtonItem();
            this.biDetectCtrlr = new DevComponents.DotNetBar.ButtonItem();
            this.biAdjustTime = new DevComponents.DotNetBar.ButtonItem();
            this.biUploadSetting = new DevComponents.DotNetBar.ButtonItem();
            this.biClearInfo = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem10 = new DevComponents.DotNetBar.ButtonItem();
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.listDoors = new System.Windows.Forms.ListView();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.dgvRealLog = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealLog)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biSelectAll,
            this.biRealDetect,
            this.biStop,
            this.biDetectCtrlr,
            this.biAdjustTime,
            this.biUploadSetting,
            this.biClearInfo,
            this.buttonItem10});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(955, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 3;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biSelectAll
            // 
            this.biSelectAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biSelectAll.Image = global::SmartAccess.Properties.Resources.editor;
            this.biSelectAll.Name = "biSelectAll";
            this.biSelectAll.Text = "全选";
            this.biSelectAll.Click += new System.EventHandler(this.biSelectAll_Click);
            // 
            // biRealDetect
            // 
            this.biRealDetect.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRealDetect.Image = global::SmartAccess.Properties.Resources.editor;
            this.biRealDetect.Name = "biRealDetect";
            this.biRealDetect.Text = "实时监控";
            this.biRealDetect.Click += new System.EventHandler(this.biRealDetect_Click);
            // 
            // biStop
            // 
            this.biStop.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biStop.Image = global::SmartAccess.Properties.Resources.editor;
            this.biStop.Name = "biStop";
            this.biStop.Text = "停止";
            this.biStop.Click += new System.EventHandler(this.biStop_Click);
            // 
            // biDetectCtrlr
            // 
            this.biDetectCtrlr.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDetectCtrlr.Image = global::SmartAccess.Properties.Resources.editor;
            this.biDetectCtrlr.Name = "biDetectCtrlr";
            this.biDetectCtrlr.Text = "检测控制器";
            this.biDetectCtrlr.Click += new System.EventHandler(this.biDetectCtrlr_Click);
            // 
            // biAdjustTime
            // 
            this.biAdjustTime.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAdjustTime.Image = global::SmartAccess.Properties.Resources.editor;
            this.biAdjustTime.Name = "biAdjustTime";
            this.biAdjustTime.Text = "校准时间";
            // 
            // biUploadSetting
            // 
            this.biUploadSetting.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biUploadSetting.Image = global::SmartAccess.Properties.Resources.editor;
            this.biUploadSetting.Name = "biUploadSetting";
            this.biUploadSetting.Text = "上传设置";
            // 
            // biClearInfo
            // 
            this.biClearInfo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biClearInfo.Image = global::SmartAccess.Properties.Resources.editor;
            this.biClearInfo.Name = "biClearInfo";
            this.biClearInfo.Text = "清空信息";
            // 
            // buttonItem10
            // 
            this.buttonItem10.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem10.Image = global::SmartAccess.Properties.Resources.editor;
            this.buttonItem10.Name = "buttonItem10";
            this.buttonItem10.Text = "查找";
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "door_close.png");
            this.smallImageList.Images.SetKeyName(1, "room_open.png");
            this.smallImageList.Images.SetKeyName(2, "door_dump.png");
            this.smallImageList.Images.SetKeyName(3, "door_disable.png");
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.GlobalItem = false;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // listDoors
            // 
            this.listDoors.Dock = System.Windows.Forms.DockStyle.Top;
            this.listDoors.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listDoors.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.listDoors.LargeImageList = this.smallImageList;
            this.listDoors.Location = new System.Drawing.Point(0, 28);
            this.listDoors.Name = "listDoors";
            this.listDoors.ShowItemToolTips = true;
            this.listDoors.Size = new System.Drawing.Size(955, 233);
            this.listDoors.TabIndex = 4;
            this.listDoors.UseCompatibleStateImageBehavior = false;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 261);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(955, 6);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 6;
            this.expandableSplitter1.TabStop = false;
            // 
            // dgvRealLog
            // 
            this.dgvRealLog.AllowUserToAddRows = false;
            this.dgvRealLog.AllowUserToDeleteRows = false;
            this.dgvRealLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRealLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRealLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRealLog.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRealLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRealLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvRealLog.Location = new System.Drawing.Point(0, 267);
            this.dgvRealLog.Name = "dgvRealLog";
            this.dgvRealLog.ReadOnly = true;
            this.dgvRealLog.RowTemplate.Height = 23;
            this.dgvRealLog.Size = new System.Drawing.Size(955, 131);
            this.dgvRealLog.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.FillWeight = 193.5371F;
            this.Column1.HeaderText = "时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.FillWeight = 76.14214F;
            this.Column2.HeaderText = "门禁";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.FillWeight = 30.32081F;
            this.Column3.HeaderText = "描述";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // RealDoorState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvRealLog);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.listDoors);
            this.Controls.Add(this.bar1);
            this.Name = "RealDoorState";
            this.Size = new System.Drawing.Size(955, 398);
            this.Load += new System.EventHandler(this.RealDoorState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biSelectAll;
        private DevComponents.DotNetBar.ButtonItem biRealDetect;
        private DevComponents.DotNetBar.ButtonItem biStop;
        private DevComponents.DotNetBar.ButtonItem biDetectCtrlr;
        private DevComponents.DotNetBar.ButtonItem biAdjustTime;
        private DevComponents.DotNetBar.ButtonItem biUploadSetting;
        private DevComponents.DotNetBar.ButtonItem biClearInfo;
        private DevComponents.DotNetBar.ButtonItem buttonItem10;
        private System.Windows.Forms.ImageList smallImageList;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private System.Windows.Forms.ListView listDoors;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private Li.Controls.DataGridViewEx dgvRealLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
