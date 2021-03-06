﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace Li.Access.Core.WGAccesses
{
    public class WGAccess :AccessCore, IAccessCore
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(WGAccess));
        private static object lockPortObj = new object();//绑定端口锁定
        private void DoBindPort(bool multi=false)
        {
            lock (lockPortObj)
            {
                int port = DataHelper.GetNextAvailableNetPort(20000);
                if (port >= 0)
                {
                    if (multi)
                    {
                        this.MultiBinds(port);
                    }
                    else this.Bind(port);
                }
                //this.Bind(61003);
                else
                {
                    throw new Exception("无可用端口");
                }
            }
        }
        private void BindPort(bool ismulti=false)
        {
            if (!isBeginReadRecord)
            {
                DoBindPort(ismulti);
            }
        }
        public List<byte[]> WGRecieveFrom(int maxCount = -1)
        {
           return this.RecieveFrom(64, maxCount);
        }
        public List<WGPacket> WGRecievePacketAddClose(int maxCount = -1)
        {
            try
            {
                List<WGPacket> list = WGRecievePacket(maxCount);
                return list;
            }
            finally
            {
                if (!isBeginReadRecord)
                {
                    this.Close();
                }
            }
        }
        public List<WGPacket> WGRecievePacket(int maxCount = -1)
        {
            List<byte[]> dics = WGRecieveFrom(maxCount);
            List<WGPacket> list = new List<WGPacket>();
            if (dics.Count > 0)
            {
                foreach (var item in dics)
                {
                    WGPacket p = ToWGPacket(item);
                    list.Add(p);
                }
            }
            return list;
        }
        private bool DoSend(WGPacket packet, string controllerIp = null,int controllerPort=60000)
        {
            
            if (string.IsNullOrWhiteSpace(controllerIp))
            {
                BindPort(true);
                controllerIp = "255.255.255.255";
            }
            else
            {
                BindPort();
            }
            if (controllerPort<=0)
            {
                controllerPort = 60000;
            }
            bool ret = this.SendTo(DataHelper.GetBytes(typeof(WGPacket), packet), controllerIp, controllerPort);
            return ret;
        }

        public static WGPacket ToWGPacket(byte[] buffer)
        {
            IntPtr ptr = Marshal.AllocHGlobal(64);
            Marshal.Copy(buffer, 0, ptr, 64);
            WGPacket p = (WGPacket)Marshal.PtrToStructure(ptr, typeof(WGPacket));
            Marshal.FreeHGlobal(ptr);
            return p;
        }
        public List<Controller> SearchController()
        {
            List<Controller> list = new List<Controller>();
            try
            {
                WGPacket packet = new WGPacket(0x94);
                if (DoSend(packet))
                {
                    List<byte[]> dics = this.RecieveFrom(64);
                    if (dics.Count > 0)
                    {
                        foreach (var item in dics)
                        {
                            WGPacket p = ToWGPacket(item);
                            Controller ctrl = p.ToController();
                            ctrl.port = 60000;
                            if (ctrl != null)
                            {
                                list.Add(ctrl);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                this.Close();
            }
            return list;
        }
        public void SetControllerIP(Controller controller)
        {
            WGPacket packet = new WGPacket(0x96);
            packet.SetControllerIP(controller);
            DoSend(packet, controllerPort: controller.port);
            Close();
        }
        public ControllerState GetControllerState(Controller controller)
        {
            WGPacket packet = new WGPacket(0x20);
            packet.SetDevSn(controller.sn);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count==1)
            {
              return  packets[0].ToControllerState();
            }
            return null;
        }
        public DateTime GetControllerTime(Controller controller)
        {
            WGPacket packet = new WGPacket(0x32);
            packet.SetDevSn(controller.sn);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].ToDateTime();
            }
            return DateTime.Now;
        }


        public bool SetControllerTime(Controller controller, DateTime dateTime)
        {
            WGPacket packet = new WGPacket(0x30);
            packet.SetDevSn(controller.sn);
            packet.SetDateTime(dateTime);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                DateTime dt = packets[0].ToDateTime();
                return dt.Year == dateTime.Year &&
                         dt.Month == dateTime.Month &&
                         dt.Day == dateTime.Day &&
                         dt.Hour == dateTime.Hour &&
                         dt.Minute == dateTime.Minute &&
                         dt.Second == dateTime.Second;
            }
            return false;
        }


        public ControllerState GetControllerRecord(Controller controller, long recordIndex)
        {
            WGPacket packet = new WGPacket(0xB0);
            packet.SetDevSn(controller.sn);
            packet.SetRecordIndex(recordIndex);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].ToControllerState(true);
            }
            return null;
        }


        public bool SetControllerReadedIndex(Controller controller, long recordIndex)
        {
            WGPacket packet = new WGPacket(0xB2);
            packet.SetDevSn(controller.sn);
            packet.SetRecordIndex(recordIndex);
            packet.SetReadedIndexTag();
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }

        public long GetControllerReadedIndex(Controller controller)
        {
            WGPacket packet = new WGPacket(0xB4);
            packet.SetDevSn(controller.sn);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].GetRecordIndex();
            }
            return -1;
        }

        private bool isBeginReadRecord = false;
        private long currentReadedRecord = 0;
        private Controller currentController = null;
        public bool BeginReadRecord(Controller controller)
        {
            if (isBeginReadRecord)
            {
                return true;
            }
            isBeginReadRecord = true;
            currentController = controller;
            DoBindPort();
            currentReadedRecord = GetControllerReadedIndex(controller);
            Console.WriteLine("当前记录号：" + currentReadedRecord);
            if (currentReadedRecord==-1)
            {
                return false;
            }
            return true;
        }

        public ControllerState ReadNextRecord()
        {
            long index;
            if (currentReadedRecord>=0xffffffff)
            {
                index = 0;
            }
            else
            {
                index = currentReadedRecord + 1;
            }
            ControllerState state = GetControllerRecord(currentController, index);
            if (state != null)
            {
                if (state.recordType != RecordType.NoRecord)
                {
                    currentReadedRecord = index;
                    SetControllerReadedIndex(currentController, currentReadedRecord);
                    Console.WriteLine("当前记录号：" + currentReadedRecord);
                    if (state.recordType == RecordType.CoveredRecord)
                    {
                        state = ReadNextRecord();
                    }
                }
            }
            return state;
        }

        public void EndReadRecord()
        {
            isBeginReadRecord = false;
            this.Close();
        }


        public bool OpenRemoteControllerDoor(Controller controller, int doorNum)
        {
            WGPacket packet = new WGPacket(0x40);
            packet.SetDevSn(controller.sn);
            packet.SetDoorNum(doorNum);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }


        public bool AddOrModifyAuthority(Controller controller, string hexCardNum, DateTime startTime, DateTime endTime, Dictionary<int, int> doorNumAuthorities, int password = 0)
        {
            WGPacket packet = new WGPacket(0x50);
            packet.SetDevSn(controller.sn);
           // hexCardNum = DataHelper.ToWGAccessCardNo(hexCardNum);
            packet.SetCardNum(hexCardNum);
            packet.SetAuthoriTimeTime(startTime,endTime);
            if (controller.doorType== ControllerDoorType.Elevator)
            {
                packet.SetAuthoriElevator(doorNumAuthorities);
            }
            else
            {
                packet.SetAuthoriDoors(doorNumAuthorities);
            }

            packet.SetAuthoriPassword(password);

            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }
        public bool DeleteAuthority(Controller controller, string hexCardNum)
        {
            WGPacket packet = new WGPacket(0x52);
            packet.SetDevSn(controller.sn);
            //hexCardNum = DataHelper.ToWGAccessCardNo(hexCardNum);
            packet.SetCardNum(hexCardNum);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }


        public bool SetDoorControlStyle(Controller controller, int doorNum, DoorControlStyle ctrlStyle, int delaySecond = 3)
        {
            WGPacket packet = new WGPacket(0x80);
            packet.SetDevSn(controller.sn);
            packet.SetDoorNum(doorNum);
            packet.SetCtrlStyle(ctrlStyle, delaySecond);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] > 0;
            }
            return false;
            
        }


        public bool ClearAuthority(Controller controller)
        {
            return true;
            WGPacket packet = new WGPacket(0x54);
            packet.SetDevSn(controller.sn);
            packet.SetClearTag();
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }


        public bool SetReceiveServer(Controller controller, string ip, int port)
        {
            WGPacket packet = new WGPacket(0x90);
            packet.SetDevSn(controller.sn);
            var bts= DataHelper.GetIPBytes(ip);
            if (bts==null)
            {
                return false;
            }
            packet.SetRecieverIPAndPort(bts, port);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }


        public bool GetReceiveServer(Controller controller, ref string ip, ref int port)
        {
            WGPacket packet = new WGPacket(0x92);
            packet.SetDevSn(controller.sn);
           
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
               return packets[0].GetReceiveServer(ref ip, ref port);
            }
            return false;
        }


        public bool SetTimeScales(Controller controller, TimeScaleNum tsNum)
        {
            WGPacket packet = new WGPacket(0x88);
            packet.SetDevSn(controller.sn);
            packet.SetTimeScale(tsNum);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }


        public bool ClearTimeScales(Controller controller)
        {
            WGPacket packet = new WGPacket(0x8A);
            packet.SetDevSn(controller.sn);
            packet.SetClearTag();
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }


        public bool ClearTimeTask(Controller controller)
        {
            WGPacket packet = new WGPacket(0xA6);
            packet.SetDevSn(controller.sn);
            packet.SetClearTag();
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }

        public bool AddTimeTask(Controller controller, TimeTask task)
        {
            try
            {
                WGPacket packet = new WGPacket(0xA8);
                packet.SetDevSn(controller.sn);
                packet.SetTimeTask(task);
                bool ret = true;
                foreach (var item in task.doorIndexs)
                {
                    if (item < 1 || item > 4)
                    {
                        continue;
                    }
                    packet.SetTimeTaskDoorIndex(item);
                    DoSend(packet, controller.ip, controller.port);
                    List<WGPacket> packets = WGRecievePacket(1);
                    if (packets.Count == 1)
                    {
                        ret = ret && (packets[0].data[0] == 1);
                    }
                }
                return ret;
            }
            finally
            {
                this.Close();
            }
        }


        public bool SetHoliday(Controller controller, HolidayPrm holiday)
        {
            WGPacket packet = new WGPacket(0xCC);
            packet.SetDevSn(controller.sn);
            packet.SetHoliday(holiday);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }

        public bool SetSuperPwds(Controller controller, int doorIndex, List<string> pwds)
        {
            WGPacket packet = new WGPacket(0x8C);
            packet.SetDevSn(controller.sn);
            packet.SetDoorNum(doorIndex);
            try
            {
                packet.SetSuperPwds(pwds);
            }
            catch (Exception ex)
            {
                log.Error("密码转换发生异常：", ex);
                return false;
            }
           
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }


        public bool SetAlarmParamsSetting(Controller controller, AlarmParamsSetting setting)
        {
            WGPacket packet = new WGPacket(0xAE);
            packet.SetDevSn(controller.sn);
            packet.SetAlarmParamsSetting(setting);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }

        public bool SetAlarmConnectPortSetting(Controller controller, AlarmConnectPortSetting setting)
        {
            WGPacket packet = new WGPacket(0xC6);
            packet.SetDevSn(controller.sn);
            packet.SetAlarmConnectPortSetting(setting);
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }


        public bool SetRecordButtonRecords(Controller controller, bool record)
        {
            WGPacket packet = new WGPacket(0x8E);
            packet.SetDevSn(controller.sn);
            packet.data[0] = record ? (byte)1 : (byte)0;
            DoSend(packet, controller.ip, controller.port);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].data[0] == 1;
            }
            return false;
        }
    }
    /// <summary>
    /// WG请求包
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct WGPacket
    {
        public byte type;				  //类型
        public byte functionID;		      //功能号
        public ushort reserved;              //保留
        public uint iDevSn;               //设备序列号 4字节
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] data;              //32字节的数据
        public uint sequenceId;            //数据包流水号
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] extern_data;        //第二版本 扩展20字节
        public WGPacket(byte fucId = 0x94)
        {
            type = 0x17;
            functionID = fucId;
            reserved = 0;
            iDevSn = 0;
            data = new byte[32];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0;
            }
            sequenceId = 0;
            extern_data = new byte[20];
            for (int i = 0; i < extern_data.Length; i++)
            {
                extern_data[i] = 0;
            }
        }

        public Controller ToController()//转为控制器（搜索）结果
        {
            Controller ctrl = new Controller();
            ctrl.sn = iDevSn.ToString();
            if (ctrl.sn[0]=='1')
            {
                ctrl.doorType = ControllerDoorType.OneDoorTwoDirections;
            }
            else if (ctrl.sn[0]=='2')
            {
                ctrl.doorType = ControllerDoorType.TwoDoorsTwoDirections;
            }
            else if (ctrl.sn[0] == '4')
            {
                ctrl.doorType = ControllerDoorType.FourDoorsOneDirection;
            }
            ctrl.ip = DataHelper.GetIP(data, 0);
            ctrl.mask = DataHelper.GetIP(data, 4);
            ctrl.gateway = DataHelper.GetIP(data, 8);
            ctrl.mac = DataHelper.GetHexString(data, 12, 6);
            ctrl.driverVersion = DataHelper.GetFromBCD(data[18]) + "." + DataHelper.GetFromBCD(data[19]);
            int year = DataHelper.GetFromBCD(data[20]) * 100 + DataHelper.GetFromBCD(data[21]);
            ctrl.driverReleaseTime = new DateTime(year, DataHelper.GetFromBCD(data[22]), DataHelper.GetFromBCD(data[23]));
            return ctrl;
        }
        public void SetControllerIP(Controller controller)//设置控制器的IP
        {
            SetDevSn(controller.sn);
            byte[] ips = DataHelper.GetBytes(controller.ip, '.');
            ips.CopyTo(data, 0);
            byte[] mask = DataHelper.GetBytes(controller.mask, '.');
            for (int i = 0; i < mask.Length; i++)
            {
                data[4 + i] = mask[i];
            }
            byte[] gateway = DataHelper.GetBytes(controller.gateway, '.');
            for (int i = 0; i < gateway.Length; i++)
            {
                data[8 + i] = gateway[i];
            }
            data[12] = 0x55;
            data[13] = 0xAA;
            data[14] = 0xAA;
            data[15] = 0x55;
        }
        public void SetDevSn(string sn)
        {
            iDevSn = uint.Parse(sn);
        }
        public void SetDoorNum(int doorNum)
        {
            data[0] = (byte)doorNum;
        }
        public void SetCtrlStyle(DoorControlStyle ctrlStyle,int delaySecond=3)
        {
            data[1] = 3;
            switch (ctrlStyle)
            {
                case DoorControlStyle.Online:
                    data[1] = 3;
                    break;
                case DoorControlStyle.AlwaysOpen:
                    data[1] = 1;
                    break;
                case DoorControlStyle.AlwaysClose:
                    data[1] = 2;
                    break;
                default:
                    break;
            }
            if (delaySecond < 1)
            {
                delaySecond = 3;
            }
            data[2] = (byte)delaySecond;
        }
        public ControllerState ToControllerState(bool isRecord=false)
        {
            ControllerState state = new ControllerState();
            state.sn = iDevSn.ToString();//控制器序列号
            state.lastRecordIndex = data[3] * 256u * 256u * 256u + data[2] * 256u * 256u + data[1] * 256u + data[0];//最后一条记录的索引号(=0表示没有记录)
            state.recordType = (RecordType)(data[4]);
            if (state.recordType == RecordType.NoRecord || state.recordType == RecordType.CoveredRecord)
            {
                return state;
            }
            state.isAllowValid = data[5] == 1;//有效性(0 表示不通过:false, 1表示通过:true)
            state.doorNum = data[6];//门号(1,2,3,4)
            state.isEnterDoor = data[7] == 1;//进门/出门(1表示进门:true, 2表示出门:false)
            byte[] bts = new byte[] { data[11], data[10], data[9], data[8] };
            state.cardOrNoNumber = DataHelper.GetHexString(bts, 0, 4);
            //state.cardOrNoNumber = (data[11] * 256u * 256u * 256u + data[10] * 256u * 256u + data[9] * 256u + data[8]).ToString();//卡号(类型是刷卡记录时)或编号(其他类型记录)
            state.recordTime = new DateTime(
                DataHelper.GetFromBCD(data[12]) * 100 + DataHelper.GetFromBCD(data[13]),
                DataHelper.GetFromBCD(data[14]),
                DataHelper.GetFromBCD(data[15]),
                DataHelper.GetFromBCD(data[16]),
                DataHelper.GetFromBCD(data[17]),
                DataHelper.GetFromBCD(data[18])
                );//刷卡时间:年月日时分秒 (采用BCD码)见设置时间部分的说明
            state.reasonNo = (RecordReasonNo)data[19];
            if (!isRecord)
            {
                state.isOpenDoorOfLock1 = data[20] == 1;//   1号门门磁(0表示关上:false, 1表示打开:true)
                state.isOpenDoorOfLock2 = data[21] == 1;//2号门门磁(0表示关上, 1表示打开)
                state.isOpenDoorOfLock3 = data[22] == 1;//3号门门磁(0表示关上, 1表示打开)
                state.isOpenDoorOfLock4 = data[23] == 1;//4号门门磁(0表示关上, 1表示打开)
                state.isOpenDoorOfButton1 = data[24] == 1;//1号门按钮(0表示松开, 1表示按下)
                state.isOpenDoorOfButton2 = data[25] == 1;//2号门按钮(0表示松开, 1表示按下)
                state.isOpenDoorOfButton3 = data[26] == 1;//3号门按钮(0表示松开, 1表示按下)
                state.isOpenDoorOfButton4 = data[27] == 1;//4号门按钮(0表示松开, 1表示按下)
                state.troubleNum = data[28];//故障号， 0 无故障，不等于0, 有故障(先重设时间, 如果还有问题, 则要返厂家维护)
                state.controllerCurTime = new DateTime(
                    ((int)(DateTime.Now.Year / 100)) * 100 + DataHelper.GetFromBCD(extern_data[7]),
                    DataHelper.GetFromBCD(extern_data[8]),
                    DataHelper.GetFromBCD(extern_data[9]),
                    DataHelper.GetFromBCD(data[29]),
                    DataHelper.GetFromBCD(data[30]),
                    DataHelper.GetFromBCD(data[31])
                    );//控制器当前时间
                state.seqNum = sequenceId;//流水号
                state.relayState = new bool[8];//0-8,表示1-8号门继电器状态，true 门开锁， false 门上锁
                for (int i = 0; i < 8; i++)
                {
                    state.relayState[i] = ((extern_data[5] >> i) & (byte)0x01) == 1;
                }

                state.isFireAlarm = ((extern_data[6] >> 1) & (byte)0x01) == 1;//是否火警
                state.isForceLock = (extern_data[6] & (byte)0x01) == 1;//是否强制锁门
            }
            return state;
        }
        /// <summary>
        /// 转为获取控制器时间
        /// </summary>
        /// <returns>控制器时间</returns>
        public DateTime ToDateTime()
        {
            return new DateTime(
                DataHelper.GetFromBCD(data[0]) * 100 + DataHelper.GetFromBCD(data[1]),
                DataHelper.GetFromBCD(data[2]),
                DataHelper.GetFromBCD(data[3]),
                DataHelper.GetFromBCD(data[4]),
                DataHelper.GetFromBCD(data[5]),
                DataHelper.GetFromBCD(data[6])
                );
        }

        public void SetDateTime(DateTime dateTime)
        {
            data[0] = DataHelper.ToByteBCD(dateTime.Year/100);
            data[1] = DataHelper.ToByteBCD(dateTime.Year - (dateTime.Year / 100)*100);
            data[2] = DataHelper.ToByteBCD(dateTime.Month);
            data[3] = DataHelper.ToByteBCD(dateTime.Day);
            data[4] = DataHelper.ToByteBCD(dateTime.Hour);
            data[5] = DataHelper.ToByteBCD(dateTime.Minute);
            data[6] = DataHelper.ToByteBCD(dateTime.Second);
        }
        //设置索引号
        public void SetRecordIndex(long recordIndex)
        {
            uint u = (uint)recordIndex;
            data[0] = (byte)(u & 0x000000ff);
            data[1] = (byte)((u>>8) & 0x000000ff);
            data[2] = (byte)((u >> 16) & 0x000000ff);
            data[3] = (byte)((u >> 24) & 0x000000ff);
        }

        public void SetCardNum(string hexCardNum)
        {
            byte[] cardNums = DataHelper.ToBytesFromHexString(hexCardNum);
            for (int i = 0; i < 4; i++)
            {
                if (cardNums.Length - i - 1 >= 0)
                {
                    data[i] = cardNums[cardNums.Length - i - 1];
                }
                else
                {
                    data[i] = 0;
                }
            }
        }

        public long GetRecordIndex()
        {
            return data[3] * 256u * 256u * 256u + data[2] * 256u * 256u + data[1] * 256u + data[0];
        }
        public void SetReadedIndexTag()
        {
            data[4] = 0x55;
            data[5] = 0xAA;
            data[6] = 0xAA;
            data[7] = 0x55;
        }
        public void SetClearTag()
        {
            data[0] = 0x55;
            data[1] = 0xAA;
            data[2] = 0xAA;
            data[3] = 0x55;
        }
        public void SetAuthoriTimeTime(DateTime startTime,DateTime endTime)
        {
            var mindate=DateTime.Parse("2000-01-01 00:00:00");
            var maxdate=DateTime.Parse("2029-12-31 00:00:00");
            if (startTime < mindate)
            {
                startTime = mindate;
            }
            if (endTime>maxdate)
            {
                endTime = maxdate;
            }

            data[4] = DataHelper.ToByteBCD((int)(startTime.Year / 100));
            data[5] = DataHelper.ToByteBCD(startTime.Year - ((int)(startTime.Year / 100)) * 100);
            data[6] = DataHelper.ToByteBCD(startTime.Month);
            data[7] = DataHelper.ToByteBCD(startTime.Day);

            data[8] = DataHelper.ToByteBCD((int)(endTime.Year / 100));
            data[9] = DataHelper.ToByteBCD(endTime.Year - ((int)(endTime.Year / 100)) * 100);
            data[10] = DataHelper.ToByteBCD(endTime.Month);
            data[11] = DataHelper.ToByteBCD(endTime.Day);
        }

        public void SetAuthoriDoors(Dictionary<int, int> doorNumAuthorities)
        {
            for (int i = 0; i < 4; i++)
            {
                int ret = -1;
                if (doorNumAuthorities.TryGetValue(i + 1, out ret))
                {
                    data[12 + i] = (byte)(ret);
                }
                else
                {
                    data[12 + i] = 0;
                }
            }
        }
        public void SetAuthoriElevator(Dictionary<int, int> doorNumAuthorities)
        {
            if (doorNumAuthorities.Count==0)
            {
                return;
            }
            data[12] = (byte)doorNumAuthorities.Values.First();//1号门时间段 20

            List<int> keys = doorNumAuthorities.Keys.ToList();

            for (int i = 0; i < 3; i++)//21,22,23
            {
                var floors = keys.FindAll(m => m >= i * 8 + 1 && m <= (i + 1) * 8);
                foreach (var item in floors)
                {
                    int floor = item - 8 * i - 1;
                    data[13 + i] |= (byte)(0x01 << floor);
                }
            }

            for (int i = 0; i < 2; i++)//29,30
            {
                var floors = keys.FindAll(m => m >= (i+3) * 8 + 1 && m <= (i + 4) * 8);
                foreach (var item in floors)
                {
                    int floor = item - 8 * (i+3) - 1;
                    data[21 + i] |= (byte)(0x01 << floor);
                }
            }
        }
        public void SetAuthoriPassword(int password)
        {
            if (password==0||password>999999||password<0)
            {
                return;
            }
            data[16] = (byte)(password & 0x0000ff);
            data[17] = (byte)((password>>8) & 0x0000ff);
            data[18] = (byte)((password >> 16) & 0x0000ff);
        }

        public void SetRecieverIPAndPort(byte[] ips, int port)
        {
            for (int i = 0; i < 4; i++)
            {
                data[i] = ips[i];
            }
            data[4] = (byte)(0xff & port);
            data[5] = (byte)((port >> 8) & 0xff);
        }

        public bool GetReceiveServer(ref string ip, ref int port)
        {
            ip = "";
            for (int i = 0; i < 4; i++)
            {
                ip += data[i] + ".";
            }
            ip = ip.TrimEnd('.');
            port = ((int)data[5] << 8)&0xff00|data[4];
            return true;
        }

        public void SetTimeScale(TimeScaleNum tsNum)
        {
            data[0] = (byte)tsNum.Num;
            data[1] = DataHelper.ToByteBCD((int)(tsNum.startDate.Year / 100));
            data[2] = DataHelper.ToByteBCD(tsNum.startDate.Year - ((int)(tsNum.startDate.Year / 100)) * 100);
            data[3] = DataHelper.ToByteBCD(tsNum.startDate.Month);
            data[4] = DataHelper.ToByteBCD(tsNum.startDate.Day);

            data[5] = DataHelper.ToByteBCD((int)(tsNum.endDate.Year / 100));
            data[6] = DataHelper.ToByteBCD(tsNum.endDate.Year - ((int)(tsNum.endDate.Year / 100)) * 100);
            data[7] = DataHelper.ToByteBCD(tsNum.endDate.Month);
            data[8] = DataHelper.ToByteBCD(tsNum.endDate.Day);

            for (int i = 0; i < 7; i++)
            {
                data[9 + i] = tsNum.weekDaysEnable[i] ? (byte)1 : (byte)0;
            }
             //data[15]
            for (int i = 0; i < tsNum.timeScales.Count; i++)
            {
                if (i == 3)
                {
                    break;
                }
                data[16 + i * 4] = DataHelper.ToByteBCD(tsNum.timeScales[i].start.Hours);
                data[16 + i * 4 + 1] = DataHelper.ToByteBCD(tsNum.timeScales[i].start.Minutes);
                data[16 + i * 4 + 2] = DataHelper.ToByteBCD(tsNum.timeScales[i].end.Hours);
                data[16 + i * 4 + 3] = DataHelper.ToByteBCD(tsNum.timeScales[i].end.Minutes);
            }
            //data[27]
            data[28] = (byte)tsNum.NextNum;
        }

        public void SetTimeTask(TimeTask task)
        {
            data[0] = DataHelper.ToByteBCD((int)(task.startDate.Year / 100));
            data[1] = DataHelper.ToByteBCD(task.startDate.Year - ((int)(task.startDate.Year / 100)) * 100);
            data[2] = DataHelper.ToByteBCD(task.startDate.Month);
            data[3] = DataHelper.ToByteBCD(task.startDate.Day);

            data[4] = DataHelper.ToByteBCD((int)(task.endDate.Year / 100));
            data[5] = DataHelper.ToByteBCD(task.endDate.Year - ((int)(task.endDate.Year / 100)) * 100);
            data[6] = DataHelper.ToByteBCD(task.endDate.Month);
            data[7] = DataHelper.ToByteBCD(task.endDate.Day);

            for (int i = 0; i < task.weekDaysEnable.Length; i++)
			{
                data[8 + i] = task.weekDaysEnable[i] ? (byte)1 : (byte)0;
			}//data[14]
            data[15] = DataHelper.ToByteBCD(task.actionTime.Hours);
            data[16] = DataHelper.ToByteBCD(task.actionTime.Minutes);
            //data[17]
            data[18] = task.ctrlStyle;
            data[19] = task.cardCount;
        }
        public void SetTimeTaskDoorIndex(byte doorIndex)
        {
            data[17] = doorIndex;
        }

        public void SetHoliday(HolidayPrm holiday)
        {
            data[0] = (byte)(holiday.IsOnDuty ? 0x02 : 0x01);
            if (holiday.IsClear)
            {
                data[0] = (byte)0xA5;
            }
            data[1] = DataHelper.ToByteBCD((int)(holiday.startDate.Year / 100));
            data[2] = DataHelper.ToByteBCD(holiday.startDate.Year - ((int)(holiday.startDate.Year / 100)) * 100);
            data[3] = DataHelper.ToByteBCD(holiday.startDate.Month);
            data[4] = DataHelper.ToByteBCD(holiday.startDate.Day);
            data[5] = DataHelper.ToByteBCD(holiday.startDate.Hour);
            data[6] = DataHelper.ToByteBCD(holiday.startDate.Minute);

            data[7] = DataHelper.ToByteBCD((int)(holiday.endDate.Year / 100));
            data[8] = DataHelper.ToByteBCD(holiday.endDate.Year - ((int)(holiday.endDate.Year / 100)) * 100);
            data[9] = DataHelper.ToByteBCD(holiday.endDate.Month);
            data[10] = DataHelper.ToByteBCD(holiday.endDate.Day);
            data[11] = DataHelper.ToByteBCD(holiday.endDate.Hour);
            data[12] = DataHelper.ToByteBCD(holiday.endDate.Minute);
        }

        public void SetSuperPwds(List<string> pwds)
        {
            for (int i = 0; i < pwds.Count; i++)
            {
                if (i == 4)
                {
                    break;
                }
                byte[] bts = DataHelper.ToBytesFromUint(uint.Parse(pwds[i]));
                for (int j = 0; j <4; j ++)
                {
                    data[4 + j + i * 4] = bts[j];
                }
            }
        }

        public void SetAlarmParamsSetting(AlarmParamsSetting setting)
        {
            data[0] = setting.EnableForcePwdAlarm ? (byte)1 : (byte)0;
            data[1] = setting.EnableUnClosed ? (byte)1 : (byte)0;
            data[2] = setting.EnableForceAccess ? (byte)1 : (byte)0;
            data[3] = setting.EnableForceCloseDoor ? (byte)1 : (byte)0;
            data[4] = setting.EnableInvalidCard ? (byte)1 : (byte)0;
            data[5] = setting.EnableFire ? (byte)1 : (byte)0;
            data[6] = setting.EnableSteal ? (byte)1 : (byte)0;
            data[7] = setting.EnableForceWithCard ? (byte)1 : (byte)0;
            uint pwd=0;
            uint.TryParse(setting.IForcePwd, out pwd);
            byte[] bts = DataHelper.ToBytesFromUint(pwd);
            for (int i = 0; i < 3; i++)
            {
                data[i + 8] = bts[i + 1];
            }
        }

        public void SetAlarmConnectPortSetting(AlarmConnectPortSetting setting)
        {
            data[0] = (byte)setting.IConnectPort;
            data[1] = (byte)setting.ActionDoorIndex;
            data[2] = (byte)setting.FixedDelayTime;
            data[3] = setting.ForcePwdEvent?(byte)1:(byte)0;
            data[4] = setting.UnClosedTimeEvent ? (byte)1 : (byte)0;
            data[5] = setting.ForceAccessEvent ? (byte)1 : (byte)0;
            data[6] = setting.ForceLockDoorEvent ? (byte)1 : (byte)0;
            data[7] = setting.InvalidCardEvent ? (byte)1 : (byte)0;
            data[8] = setting.FireEvent ? (byte)1 : (byte)0;
            data[9] = setting.DoorRelayActionEvent ? (byte)1 : (byte)0;
            data[10] = setting.ConnectItem == AlarmConnectItem.KeepState ? (byte)0 : (byte)1;
        }
    }
}
