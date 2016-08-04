﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.Common.WinInfo
{
    public partial class FrmInfo : DevComponents.DotNetBar.Office2007Form
    { 
        private  const int WS_EX_NOACTIVATE = 0x08000000;
        private int _time = 0;
        public static void ShowInfo(IWin32Window owner, string text, int timeCloseSecond = 5)
        {
            Control ctrl = owner as Control;
            if (ctrl == null)
            {
                ctrl = Application.OpenForms[0];
            }
            ctrl.Invoke(new Action(() =>
            {
                FrmInfo frmInfo = new FrmInfo(text, timeCloseSecond);
                if (owner == null)
                {
                    frmInfo.Show();
                }
                else frmInfo.Show(owner);
            }));
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_NOACTIVATE;
                return cp;
            }
        }
        public FrmInfo(string text,int timeCloseSecond=5)
        {
            InitializeComponent();
            if (timeCloseSecond>0)
            {
                _time = timeCloseSecond;
                timerClose.Interval = timeCloseSecond * 1000;
            }
            this.lbMsg.Text = text;
        }
        private void FrmInfo_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            if (_time>0)
            {
                timerClose.Start();
            }
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            timerClose.Stop();
            this.Close();
        }
        private int _height = 0;
        private int _step = 10;
        private Rectangle _screen = Screen.PrimaryScreen.WorkingArea;
        public new void Show()
        {
            this.Show(Application.OpenForms[0]);
        }
        public new void Show(IWin32Window owner)
        {
            _height = this.Height;
            this.Height = 0;
            this.SetBounds(_screen.Right - this.Width, _screen.Bottom, this.Width, 0);
            int count = 200 / timerShow.Interval;
            _step = _height / count;
            if (_step == 0)
            {
                _step = 1;
            }
            base.Show(owner);
            timerShow.Start();
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static IntPtr SetActiveWindow(IntPtr handle);
        private const int WM_ACTIVATE = 0x006;
        private const int WM_ACTIVATEAPP = 0x01C;
        private const int WM_NCACTIVATE = 0x086;
        private const int WA_INACTIVE = 0;
        private const int WM_MOUSEACTIVATE = 0x21;
        private const int MA_NOACTIVATE = 3;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = new IntPtr(MA_NOACTIVATE);
                return;
            }
            else if (m.Msg == WM_NCACTIVATE)
            {
                if (((int)m.WParam & 0xFFFF) != WA_INACTIVE)
                {
                    if (m.LParam != IntPtr.Zero)
                    {
                        SetActiveWindow(m.LParam);
                    }
                    else
                    {
                        SetActiveWindow(IntPtr.Zero);
                    }
                }
            }
            base.WndProc(ref m);
        }

        private void timerShow_Tick(object sender, EventArgs e)
        {
            DoHeightAdd();
        }
        private void DoHeightAdd()
        {
            if (this.Height + _step > _height)
            {
                this.SetBounds(_screen.Right - this.Width, _screen.Bottom - _height, this.Width, _height);
                timerShow.Stop();
            }
            else
            {
                this.SetBounds(_screen.Right - this.Width, _screen.Bottom - this.Height - _step, this.Width, this.Height + _step);
            }
            this.Visible = true;
            this.Opacity = 100;
        }
    }
}
;