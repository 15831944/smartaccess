﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Li.Access.Core.WGAccesses;
using SmartAccess.Common.WinInfo;
using Li.Access.Core;
using System.Threading;
using SmartAccess.Common.Datas;
using System.Net;

namespace SmartAccess.ControlDevMgr
{
    public partial class FrmSearchController : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmSearchController));
        public bool Changed = false;
        public FrmSearchController()
        {
            InitializeComponent();
        }

        private void btnSearchCtrlr_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void DoSearch(int waitminisecond=0)
        {
            CtrlWaiting ctrlWaiting = new CtrlWaiting("搜索控制器中...", new Action(() =>
            {
                if (waitminisecond>0)
                {
                    Thread.Sleep(waitminisecond);//需要等待控制器修改IP后重启
                }
                IAccessCore access = new WGAccess();
                List<Controller> ctrlrs = access.SearchController();
                if (ctrlrs == null || ctrlrs.Count == 0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "没有查询到控制器！", 5);
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        AddControllerToGrid(ctrlrs);
                    }));
                }
            }));
            ctrlWaiting.Show(this);
        }

        private void AddControllerToGrid(List<Controller>  ctrlrs)
        {
            dgvCtrlr.Rows.Clear();
            string ip = "127.0.0.1";
            try
            {
                IPAddress[] ips = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

                foreach (var item in ips)
                {
                    if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ip = item.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("获取本地地址错误：", ex);
            }

            
            foreach (Controller item in ctrlrs)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvCtrlr,
                    item.sn,
                    item.ip,
                    item.mask,
                    item.gateway,
                    item.port,
                    item.mac,
                    ip,
                    item.driverVersion,
                    "修改IP",
                    "添加/更新"
                    );
                row.Tag = item;
                dgvCtrlr.Rows.Add(row);
            }
        }
        private void DoShowModifyIp(DataGridViewRow row)
        {
            Controller ctrlr = (Controller)row.Tag;
            FrmModifyCtrlrIp frmModifyIp = new FrmModifyCtrlrIp(ctrlr);
            if (frmModifyIp.ShowDialog(this) == DialogResult.OK)
            {
                if (cbAutoSearch.Checked)
                {
                    DoSearch(5000);
                }
            }
        }

        private void DoAddCtrlr(DataGridViewRow row)
        {
            Controller ctrlr = (Controller)row.Tag;
            CtrlWaiting ctrlWaiting = new CtrlWaiting("添加控制...", () =>
            {
                try
                {
                    Maticsoft.Model.SMT_CONTROLLER_INFO info = ControllerHelper.AddController(ctrlr);
                    if (info!=null)
                    {
                        log.Info("添加控制器成功：" + ctrlr.sn + "," + ctrlr.ip);
                        WinInfoHelper.ShowInfoWindow(this, "添加/更新控制器成功，请编辑控制器参数.");
                        Changed = true;
                        this.Invoke(new Action(() =>
                            {
                                FrmAddOrModifyCtrlr modify = new FrmAddOrModifyCtrlr(info);
                                modify.ShowDialog(this);
                            }));
                    }
                    else
                    {
                        log.Warn("添加控制器失败：" + ctrlr.sn + "," + ctrlr.ip);
                        WinInfoHelper.ShowInfoWindow(this, "添加/更新控制器失败！");  
                    }
                }
                catch (Exception ex)
                {
                    log.Error("添加控制器异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "添加/更新控制器失败:" + ex.Message);
                }
            });
            ctrlWaiting.Show(this);
        }

        private void dgvCtrlr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)//修改
            {
                if (e.ColumnIndex == dgvCtrlr.ColumnCount - 2)
                {
                    DoShowModifyIp(dgvCtrlr.Rows[e.RowIndex]);
                }
                else if (e.ColumnIndex == dgvCtrlr.ColumnCount - 1)
                {
                    DoAddCtrlr(dgvCtrlr.Rows[e.RowIndex]);
                }
            }
        }
        private Controller GetSelectedController()
        {
            if (dgvCtrlr.SelectedRows.Count > 0)
            {
                return dgvCtrlr.SelectedRows[0].Tag as Controller;
            }
            else if (dgvCtrlr.SelectedCells.Count > 0 && dgvCtrlr.SelectedCells[0].RowIndex >= 0)
            {
                return dgvCtrlr.Rows[dgvCtrlr.SelectedCells[0].RowIndex].Tag as Controller;
            }
            else
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择控制器！");
            }
            return null;
        }

        private void dgvCtrlr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                DoShowModifyIp(dgvCtrlr.Rows[e.RowIndex]);
            }
        }

        private void FrmSearchController_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 300;
            timer.Tick += (s, ee)=>
            {
                timer.Stop();
                DoSearch();
                timer.Dispose();
            };
            timer.Start();
        }

        private void btnGetTime_Click(object sender, EventArgs e)
        {
            Controller ctrl = GetSelectedController();
            if (ctrl == null)
            {
                return;
            }
            using( IAccessCore access = new WGAccess())
            {
                DateTime dt = access.GetControllerTime(ctrl);
                dtpTime.Value = dt;
            }
        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            Controller ctrl = GetSelectedController();
            if (ctrl == null)
            {
                return;
            }
            if (dtpTime.ValueObject==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择时间！");
                return;
            }
            using(IAccessCore access = new WGAccess())
            {
                bool ret = access.SetControllerTime(ctrl, dtpTime.Value);
                WinInfoHelper.ShowInfoWindow(this, "设置时间" + (ret ? "成功！" : "失败"));
            }
        }
    }
}
