﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.Datas;
using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.ControlDevMgr
{
    public partial class ControllerMgr : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(ControllerMgr));
        public ControllerMgr()
        {
            InitializeComponent();
        }
        private void Init()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrls = ControllerHelper.GetList("1=1",true);//获取所有控制器
                List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas = AreaDataHelper.GetAreas(true);//获取所有区域
                this.Invoke(new Action(()=>
                    {
                        ShowAreas(areas);
                        ShowCtrls(ctrls);
                    }));
            });
            waiting.Show(this,500);
        }
        private void DoLoadCtrlrs(List<decimal> areaIds)
        {
            List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrls = ControllerHelper.GetList(areaIds);

        }
        private void ShowAreas(List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas)
        {
            var tree=  AreaDataHelper.ToTree(areas);
            advTreeArea.Nodes[0].Nodes.Clear();
            advTreeArea.Nodes[0].Nodes.AddRange(tree.ToArray());
            advTreeArea.ExpandAll();
        }
 
        private void ShowCtrls(List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrls)
        {
            if (ctrls == null)
            {
                return;
            }
            dgvCtrlr.Rows.Clear();
            foreach (var item in ctrls)
            {
                AddRow(item);
            }
        }
        private void AddRow(Maticsoft.Model.SMT_CONTROLLER_INFO ctrl)
        {
            DataGridViewRow row = new DataGridViewRow();
            string doors = "";
            if (ctrl.DOOR_INFOS != null && ctrl.DOOR_INFOS.Count > 0)
            {
                foreach (var door in ctrl.DOOR_INFOS)
                {
                    doors += door.DOOR_NAME + ";";
                }
            }
            row.CreateCells(dgvCtrlr,
                ctrl.NAME,
                ctrl.SN_NO,
                ctrl.IS_ENABLE?"启用":"禁用",
                ctrl.IP,
                ctrl.PORT,
                ctrl.AREA_NAME,
                ctrl.CTRLR_DESC,
                doors,//所控制的门
                "修改",
                "删除"
                );
            row.Tag = ctrl;
            dgvCtrlr.Rows.Add(row);
        }
        private void UpdateRow(DataGridViewRow row, Maticsoft.Model.SMT_CONTROLLER_INFO ctrl)
        {
            if (ctrl==null)
            {
                return;
            }
            string doors = "";
            if (ctrl.DOOR_INFOS != null && ctrl.DOOR_INFOS.Count > 0)
            {
                foreach (var door in ctrl.DOOR_INFOS)
                {
                    doors += door.DOOR_NAME + ";";
                }
            }
            row.Cells[0].Value = ctrl.NAME;
            row.Cells[1].Value = ctrl.SN_NO;
            row.Cells[2].Value = ctrl.IS_ENABLE ? "启用" : "禁用";
            row.Cells[3].Value = ctrl.IP;
            row.Cells[4].Value = ctrl.PORT;
            row.Cells[5].Value = ctrl.AREA_NAME;
            row.Cells[6].Value = ctrl.CTRLR_DESC;
            row.Cells[7].Value = doors;//所控制的门
            row.Tag = ctrl;
        }
        private Maticsoft.Model.SMT_CONTROLLER_ZONE GetSelectArea()
        {
            if(advTreeArea.SelectedNode!=null)
            {
               return advTreeArea.SelectedNode.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
            }
            return null;
        }
        private List<Maticsoft.Model.SMT_CONTROLLER_ZONE> GetSelectWithSubAreas()
        {
            List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas = new List<Maticsoft.Model.SMT_CONTROLLER_ZONE>();
            if (advTreeArea.SelectedNode!=null&&advTreeArea.SelectedNode.Tag is Maticsoft.Model.SMT_CONTROLLER_ZONE)
            {
                areas.Add((Maticsoft.Model.SMT_CONTROLLER_ZONE)advTreeArea.SelectedNode.Tag);
                GetSubAreas(advTreeArea.SelectedNode, ref areas);
            }
            return areas;
        }
        private void GetSubAreas(DevComponents.AdvTree.Node node,ref List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas)
        {
            foreach (DevComponents.AdvTree.Node item in node.Nodes)
            {
                areas.Add((Maticsoft.Model.SMT_CONTROLLER_ZONE)item.Tag);
                GetSubAreas(item, ref areas);
            }
        }
        private void ControlerMgr_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void advTreeArea_NodeMouseDown(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Left)
            {
               
            }
        }

        private void advTreeArea_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            if (e.Node==null)
            {
                return;
            }
            if (e.Node.Level==0)
            {
                biDeleteArea.Enabled = false;
                biModifyArea.Enabled = false;
            }
            else
            {
                biDeleteArea.Enabled = true;
                biModifyArea.Enabled = true;
            }
        }

        private void biAddArea_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE area = GetSelectArea();
            FrmControlAreaEditor areaEditor = new FrmControlAreaEditor();
            areaEditor.IsAdd = true;
            if (area!=null)
            {
                areaEditor.ParentAreaID = area.PAR_ID;
            }
            else
            {
                areaEditor.ParentAreaID = 0;
            }
            if(areaEditor.ShowDialog(this)== DialogResult.OK)
            {
                Maticsoft.Model.SMT_CONTROLLER_ZONE areaAdded = areaEditor.Area;
                DevComponents.AdvTree.Node node = AreaDataHelper.CreateNode(areaAdded);
                if (advTreeArea.SelectedNode==null||advTreeArea.SelectedNode.Level==0)
                {
                    advTreeArea.Nodes[0].Nodes.Add(node);
                }
                else
                {
                    advTreeArea.SelectedNode.Parent.Nodes.Add(node);
                    
                }
                node.Parent.Expand();
            }
        }

        private void biAddSubArea_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE area = GetSelectArea();
            FrmControlAreaEditor areaEditor = new FrmControlAreaEditor();
            areaEditor.IsAdd = true;
            if (area != null)
            {
                areaEditor.ParentAreaID = area.ID;
            }
            else
            {
                areaEditor.ParentAreaID = 0;
            }
            if (areaEditor.ShowDialog(this) == DialogResult.OK)
            {
                Maticsoft.Model.SMT_CONTROLLER_ZONE areaAdded = areaEditor.Area;
                DevComponents.AdvTree.Node node = AreaDataHelper.CreateNode(areaAdded);
                if (advTreeArea.SelectedNode == null || advTreeArea.SelectedNode.Level == 0)
                {
                    advTreeArea.Nodes[0].Nodes.Add(node);
                }
                else
                {
                    advTreeArea.SelectedNode.Nodes.Add(node);
                }
                node.Parent.Expand();
            }
        }

        private void biDeleteArea_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas = GetSelectWithSubAreas();
            if (areas.Count>0)
            {
                if (MessageBox.Show("确定删除当前区域及其下级区域？","提示",MessageBoxButtons.OKCancel)== DialogResult.OK)
                {
                    AreaDataHelper.DeleteAreas(areas);
                    advTreeArea.SelectedNode.Remove();
                }
            }
        }

        private void biAddRootArea_Click(object sender, EventArgs e)
        {
            FrmSearchController search = new FrmSearchController();
            search.ShowDialog(this);
        }

        private void btnAddCtrlr_Click(object sender, EventArgs e)
        {
            FrmAddOrModifyCtrlr frmModify = new FrmAddOrModifyCtrlr();
            if (frmModify.ShowDialog(this) == DialogResult.OK)
            {
                AddRow(frmModify.Controller);
            }
        }

        private void dgvCtrlr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&&e.ColumnIndex>=0)
            {
                if (dgvCtrlr.Columns[e.ColumnIndex].Name=="Col_XG")//修改
                {
                    DoModify(dgvCtrlr.Rows[e.RowIndex]);
                }
                else if (dgvCtrlr.Columns[e.ColumnIndex].Name=="Col_SC")//删除
                {
                    DoDelete(dgvCtrlr.Rows[e.RowIndex]);
                }
            }
        }
        private void DoModify(DataGridViewRow row)
        {
            Maticsoft.Model.SMT_CONTROLLER_INFO ctrlr = (Maticsoft.Model.SMT_CONTROLLER_INFO)row.Tag;
            FrmAddOrModifyCtrlr frmModify = new FrmAddOrModifyCtrlr(ctrlr);
            if(frmModify.ShowDialog(this)==DialogResult.OK)
            {
                UpdateRow(row, frmModify.Controller);
            }
        }
        private void DoDelete(DataGridViewRow row)
        {
            if (MessageBox.Show("确定删除该控制器？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                CtrlWaiting ctrlWaiting = new CtrlWaiting("正在删除中...", () =>
                {
                    try
                    {
                        Maticsoft.Model.SMT_CONTROLLER_INFO ctrlr = (Maticsoft.Model.SMT_CONTROLLER_INFO)row.Tag;
                        Maticsoft.BLL.SMT_CONTROLLER_INFO ctrlBll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
                        ctrlBll.Delete(ctrlr.ID);
                        //置门关联控制器为空
                        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update SMT_DOOR_INFO set CTRL_ID=-1,CTRL_DOOR_INDEX=0 where CTRL_ID=" + ctrlr.ID);
                        this.Invoke(new Action(() =>
                            {
                                dgvCtrlr.Rows.Remove(row);
                            }));
                    }
                    catch (System.Exception ex)
                    {
                        log.Error("删除控制器异常：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "删除失败：" + ex.Message);
                    }

                });
                ctrlWaiting.Show(this);
            }
        }
    }
}