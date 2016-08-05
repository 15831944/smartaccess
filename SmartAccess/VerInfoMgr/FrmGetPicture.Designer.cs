﻿namespace SmartAccess.VerInfoMgr
{
    partial class FrmGetPicture
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
            this.components = new System.ComponentModel.Container();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biOpenLocalPic = new DevComponents.DotNetBar.ButtonItem();
            this.biSave = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.cboCameraList = new DevComponents.DotNetBar.ComboBoxItem();
            this.biOpenCamera = new DevComponents.DotNetBar.ButtonItem();
            this.biCaptureVideo = new DevComponents.DotNetBar.ButtonItem();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.picBox2 = new System.Windows.Forms.PictureBox();
            this.picBox5 = new System.Windows.Forms.PictureBox();
            this.picBox4 = new System.Windows.Forms.PictureBox();
            this.picBox3 = new System.Windows.Forms.PictureBox();
            this.panelVideo = new System.Windows.Forms.Panel();
            this.cameraControl = new Camera_NET.CameraControl();
            this.timerCapture = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.biOk = new DevComponents.DotNetBar.ButtonItem();
            this.biClose = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).BeginInit();
            this.panelVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biOpenLocalPic,
            this.biSave,
            this.labelItem1,
            this.cboCameraList,
            this.biOpenCamera,
            this.biCaptureVideo,
            this.biOk,
            this.biClose});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(843, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biOpenLocalPic
            // 
            this.biOpenLocalPic.Name = "biOpenLocalPic";
            this.biOpenLocalPic.Text = "浏览本地照片";
            this.biOpenLocalPic.Click += new System.EventHandler(this.biOpenLocalPic_Click);
            // 
            // biSave
            // 
            this.biSave.Name = "biSave";
            this.biSave.Text = "保存图片至本地";
            this.biSave.Click += new System.EventHandler(this.biSave_Click);
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "摄像头:";
            // 
            // cboCameraList
            // 
            this.cboCameraList.ComboWidth = 200;
            this.cboCameraList.DropDownHeight = 120;
            this.cboCameraList.ItemHeight = 17;
            this.cboCameraList.Name = "cboCameraList";
            // 
            // biOpenCamera
            // 
            this.biOpenCamera.Name = "biOpenCamera";
            this.biOpenCamera.Text = "打开摄像头";
            this.biOpenCamera.Click += new System.EventHandler(this.biOpenCamera_Click);
            // 
            // biCaptureVideo
            // 
            this.biCaptureVideo.Name = "biCaptureVideo";
            this.biCaptureVideo.Text = "拍照";
            this.biCaptureVideo.Click += new System.EventHandler(this.biCaptureVideo_Click);
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.Gray;
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(0, 33);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(327, 408);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            // 
            // picBox1
            // 
            this.picBox1.BackColor = System.Drawing.Color.Gray;
            this.picBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox1.Location = new System.Drawing.Point(677, 33);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(166, 132);
            this.picBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox1.TabIndex = 3;
            this.picBox1.TabStop = false;
            this.picBox1.DoubleClick += new System.EventHandler(this.picBox_DoubleClick);
            // 
            // picBox2
            // 
            this.picBox2.BackColor = System.Drawing.Color.Gray;
            this.picBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox2.Location = new System.Drawing.Point(677, 171);
            this.picBox2.Name = "picBox2";
            this.picBox2.Size = new System.Drawing.Size(166, 132);
            this.picBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox2.TabIndex = 3;
            this.picBox2.TabStop = false;
            this.picBox2.DoubleClick += new System.EventHandler(this.picBox_DoubleClick);
            // 
            // picBox5
            // 
            this.picBox5.BackColor = System.Drawing.Color.Gray;
            this.picBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox5.Location = new System.Drawing.Point(332, 309);
            this.picBox5.Name = "picBox5";
            this.picBox5.Size = new System.Drawing.Size(166, 132);
            this.picBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox5.TabIndex = 3;
            this.picBox5.TabStop = false;
            this.picBox5.DoubleClick += new System.EventHandler(this.picBox_DoubleClick);
            // 
            // picBox4
            // 
            this.picBox4.BackColor = System.Drawing.Color.Gray;
            this.picBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox4.Location = new System.Drawing.Point(504, 309);
            this.picBox4.Name = "picBox4";
            this.picBox4.Size = new System.Drawing.Size(166, 132);
            this.picBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox4.TabIndex = 3;
            this.picBox4.TabStop = false;
            this.picBox4.DoubleClick += new System.EventHandler(this.picBox_DoubleClick);
            // 
            // picBox3
            // 
            this.picBox3.BackColor = System.Drawing.Color.Gray;
            this.picBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox3.Location = new System.Drawing.Point(677, 309);
            this.picBox3.Name = "picBox3";
            this.picBox3.Size = new System.Drawing.Size(166, 132);
            this.picBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox3.TabIndex = 3;
            this.picBox3.TabStop = false;
            this.picBox3.DoubleClick += new System.EventHandler(this.picBox_DoubleClick);
            // 
            // panelVideo
            // 
            this.panelVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVideo.Controls.Add(this.cameraControl);
            this.panelVideo.Location = new System.Drawing.Point(332, 33);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(339, 270);
            this.panelVideo.TabIndex = 2;
            // 
            // cameraControl
            // 
            this.cameraControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cameraControl.DirectShowLogFilepath = "";
            this.cameraControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraControl.Location = new System.Drawing.Point(0, 0);
            this.cameraControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cameraControl.Name = "cameraControl";
            this.cameraControl.Size = new System.Drawing.Size(337, 268);
            this.cameraControl.TabIndex = 0;
            this.cameraControl.DoubleClick += new System.EventHandler(this.cameraControl_DoubleClick);
            // 
            // timerCapture
            // 
            this.timerCapture.Interval = 200;
            this.timerCapture.Tick += new System.EventHandler(this.timerCapture_Tick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "png";
            this.saveFileDialog.Filter = "图片文件(*.png)|*.png";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "图片文件|*.png;*.jpg;*.bmp;*.jpeg";
            // 
            // biOk
            // 
            this.biOk.Name = "biOk";
            this.biOk.Text = "确定并关闭";
            this.biOk.Click += new System.EventHandler(this.biOk_Click);
            // 
            // biClose
            // 
            this.biClose.Name = "biClose";
            this.biClose.Text = "关闭";
            this.biClose.Click += new System.EventHandler(this.biClose_Click);
            // 
            // FrmGetPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 446);
            this.Controls.Add(this.picBox5);
            this.Controls.Add(this.picBox4);
            this.Controls.Add(this.picBox3);
            this.Controls.Add(this.picBox2);
            this.Controls.Add(this.picBox1);
            this.Controls.Add(this.panelVideo);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGetPicture";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "获取照片";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGetPicture_FormClosing);
            this.Load += new System.EventHandler(this.FrmGetPicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).EndInit();
            this.panelVideo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biOpenCamera;
        private DevComponents.DotNetBar.ButtonItem biOpenLocalPic;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.PictureBox picBox2;
        private System.Windows.Forms.PictureBox picBox5;
        private System.Windows.Forms.PictureBox picBox4;
        private System.Windows.Forms.PictureBox picBox3;
        private DevComponents.DotNetBar.ButtonItem biCaptureVideo;
        private System.Windows.Forms.Panel panelVideo;
        private Camera_NET.CameraControl cameraControl;
        private DevComponents.DotNetBar.ButtonItem biSave;
        private System.Windows.Forms.Timer timerCapture;
        private DevComponents.DotNetBar.ComboBoxItem cboCameraList;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevComponents.DotNetBar.ButtonItem biOk;
        private DevComponents.DotNetBar.ButtonItem biClose;
    }
}