﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using Li.Access.Core;

namespace SmartAccess.InfoSearchMgr
{
    public partial class AutoAccessRecordInfo : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AutoAccessRecordInfo));
        public AutoAccessRecordInfo()
        {
            InitializeComponent();
            var list = AccessStateItem.GetStatesList();
            foreach (var item in list)
            {
                if (item.state== AccessState.RequestCancel)
                {
                    list.Remove(item);
                    break;
                }
            }
            cboState.DataSource = list;
            dtpStart.Value = DateTime.Now.Date.AddDays(-7);
            dtpEnd.Value = DateTime.Now.Date.AddDays(7);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value >= dtpEnd.Value)
            {
                WinInfoHelper.ShowInfoWindow(this, "开始时间大于结束时间！");
                return;
            }
            string strWhere = "";
            string timeStart = dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string timeEnd = dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
            strWhere += "((ACC_START_TIME >='" + timeStart + "' and ACC_START_TIME <='" + timeEnd + "') ";
            strWhere += " or (ACC_END_TIME >='" + timeStart + "' and ACC_END_TIME <='" + timeEnd + "') ";
            strWhere += " or (ACC_ADD_TIME >='" + timeStart + "' and ACC_ADD_TIME <='" + timeEnd + "') ";
            strWhere += " or (ACC_STATE_TIME >='" + timeStart + "' and ACC_STATE_TIME <='" + timeEnd + "')) ";
            if (!string.IsNullOrWhiteSpace(tbAppName.Text))
            {
                strWhere += " and ACC_APP_NAME like '%" + tbAppName.Text.Trim() + "%'";
            }
            if (cboState.SelectedItem != null)
            {
                AccessStateItem asi = (AccessStateItem)cboState.SelectedItem;
                if (asi.state!= AccessState.None)
                {
                    strWhere += " and ACC_STATE=" + (int)asi.state;
                }
            }

            pageDataGridView.Reset();
            pageDataGridView.SqlWhere = strWhere;
            DoSearch(true);
        }
        private void DoSearch(bool searchCount = false)
        {
            dgvData.Rows.Clear();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_AUTO_ACCESS_RECORD bll = new Maticsoft.BLL.SMT_AUTO_ACCESS_RECORD();
                    int count = -1;
                    if (searchCount)
                    {
                        count = bll.GetRecordCount(pageDataGridView.SqlWhere);
                        if (count <= 0)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "没有记录！");
                        }
                    }
                    List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD> records = null;
                    if (count != 0)
                    {
                        records = bll.GetModelListEx(pageDataGridView.SqlWhere, pageDataGridView.PageControl.StartIndex, pageDataGridView.PageControl.EndIndex);
                    }

                    this.Invoke(new Action(() =>
                    {
                        if (searchCount)
                        {
                            pageDataGridView.PageControl.TotalRecords = count;
                        }

                        DoShowGrid(records);
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("查询记录异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "查询记录异常：" + ex.Message);
                }

            });
            waiting.Show(this);
        }

        private void DoShowGrid(List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD> records)
        {
            if (records==null)
            {
                return;
            }
            foreach (var item in records)
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.CreateCells(dgvData);
                string sys=item.ACC_FROM_SYS;
                AutoAccessSys.SysNames.TryGetValue(item.ACC_FROM_SYS, out sys);
                dgvr.Cells[0].Value = sys;
                dgvr.Cells[1].Value = item.ACC_APP_NAME;
                dgvr.Cells[2].Value = item.STAFF_REAL_NAME;
                dgvr.Cells[3].Value = item.DOOR_NAME;
                dgvr.Cells[4].Value = item.ACC_START_TIME;
                dgvr.Cells[5].Value = item.ACC_END_TIME;
                dgvr.Cells[6].Value = item.ACC_ADD_TIME;
                dgvr.Cells[7].Value = item.ACC_STATE_TIME;
                AccessStateItem asi = new AccessStateItem(){state= (AccessState)item.ACC_STATE};
                dgvr.Cells[8].Value = asi.Text;
                dgvr.Cells[8].Style.ForeColor = asi.StateColor;
                dgvr.Tag = item;
                dgvData.Rows.Add(dgvr);
            }
        }
    }
}
