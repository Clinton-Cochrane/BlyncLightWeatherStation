// Decompiled with JetBrains decompiler
// Type: Blynclight.DeviceAccess
// Assembly: Blynclight, Version=0.3.0.11, Culture=neutral, PublicKeyToken=null
// MVID: 5BBF77FB-8F3D-4A6F-B095-307E683776AC
// Assembly location: C:\Users\cecochr\Downloads\Embrava_SDK_For_Windows_v3.0.3\Embrava_SDK_For_Windows_v3.0.3\Binaries\AnyCpu\Blynclight.dll

using System;
using System.Runtime.InteropServices;


namespace BlyncLightWeatherStation.Services.BlyncLight
{
    internal class DeviceAccess
    {
        internal byte[] abyBlyncOutputReportBuffer = new byte[9];
        internal byte[] abyBlyncUsbHeadsetOutputReportBuffer = new byte[16];
        internal byte[] abyBlyncBluetoothHeadsetOutputReportBuffer = new byte[16];
        internal byte[] abyBlyncFeatureReportBuffer = new byte[9];
        internal byte[] abyBlyncIntOutputReportBuffer = new byte[65];
        internal IntPtr pspDeviceInterfaceData = IntPtr.Zero;
        internal IntPtr pspDeviceInterfaceDetailData = IntPtr.Zero;
        internal BlyncController oBlyncController;
        internal byte testNumber = 255;

        internal bool GetDevices(ref BlyncController.DeviceInfo[] aoDevInfo,ref int m_nTotalDevices)
        {
            
            uint num1 = 0;
            IntPtr zero1 = IntPtr.Zero;
            IntPtr zero2 = IntPtr.Zero;
            bool flag = true;
            uint PropertyRegDataType = 0;
            uint untBufferSize = 0;
            Guid guid = new Guid();
            IntPtr num2 = IntPtr.Zero;
            DeviceAccessDeclarations.SP_DEVINFO_DATA spDevinfoData = new DeviceAccessDeclarations.SP_DEVINFO_DATA();
            NativeMethods.HidD_GetHidGuid(ref guid);
            IntPtr num3 = IntPtr.Zero;
            num1 = 0U;
            m_nTotalDevices = 0;
            IntPtr classDevs = NativeMethods.SetupDiGetClassDevs(ref guid,IntPtr.Zero,IntPtr.Zero,18U);
            if(uint.MaxValue == (uint) classDevs.ToInt64())
            {
                num1 = 6U;
                flag = false;
            } else
            {
                spDevinfoData.cbSize = Marshal.SizeOf((object) spDevinfoData);
                num2 = Marshal.AllocHGlobal(Marshal.SizeOf((object) spDevinfoData));
                Marshal.StructureToPtr((object) spDevinfoData,num2,true);
                for(uint uintDeviceID = 0; NativeMethods.SetupDiEnumDeviceInfo(classDevs,uintDeviceID,num2); ++uintDeviceID)
                {
                    DeviceAccessDeclarations.SP_DEVINFO_DATA structure = (DeviceAccessDeclarations.SP_DEVINFO_DATA) Marshal.PtrToStructure(num2,typeof(DeviceAccessDeclarations.SP_DEVINFO_DATA));
                    for(; !NativeMethods.SetupDiGetDeviceRegistryProperty(classDevs,num2,0U,ref PropertyRegDataType,num3,untBufferSize,ref untBufferSize); num3 = Marshal.AllocHGlobal((int) untBufferSize))
                    {
                        if(122 != Marshal.GetLastWin32Error())
                        {
                            flag = false;
                            break;
                        }
                    }
                    Marshal.PtrToStringAuto(new IntPtr(num3.ToInt64()));
                    string empty = string.Empty;
                    flag = this.GetDevicePathName(ref guid,classDevs,uintDeviceID,ref empty);
        
                    if(empty.Contains("vid_1130&pid_1e00&mi_01"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 2;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCUSB20 DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        ++m_nTotalDevices;
                    } else if(empty.Contains("vid_1130&pid_0001&mi_01") || empty.Contains("vid_1130&pid_0002&mi_01"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 1;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCUSB10 DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        aoDevInfo[m_nTotalDevices].PHandle = NativeMethods.CreateFile(empty,3221225472U,3U,IntPtr.Zero,3U,0U,IntPtr.Zero);
                        ++m_nTotalDevices;
                    } else if(empty.Contains("vid_0e53&pid_2517") || empty.Contains("vid_2c0d&pid_0002") || empty.Contains("vid_2c0d&pid_000d"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 4;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCUSB30S DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        aoDevInfo[m_nTotalDevices].PHandle = NativeMethods.CreateFile(empty,3221225472U,3U,IntPtr.Zero,3U,0U,IntPtr.Zero);
                        ++m_nTotalDevices;
                    } else if(empty.Contains("vid_0e53&pid_2516") || empty.Contains("vid_2c0d&pid_0001") || empty.Contains("vid_2c0d&pid_000c"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 3;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCUSB30 DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        aoDevInfo[m_nTotalDevices].PHandle = NativeMethods.CreateFile(empty,3221225472U,3U,IntPtr.Zero,3U,0U,IntPtr.Zero);
                        ++m_nTotalDevices;
                    } else if(empty.Contains("vid_2c0d&pid_0004&mi_03&col02"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 5;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCUSB_HEADSET_LUMENA110 DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        aoDevInfo[m_nTotalDevices].PHandle = NativeMethods.CreateFile(empty,3221225472U,3U,IntPtr.Zero,3U,0U,IntPtr.Zero);
                        ++m_nTotalDevices;
                    } else if(empty.Contains("vid_2c0d&pid_0005&mi_03&col02"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 8;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCUSB_HEADSET_LUMENA120 DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        aoDevInfo[m_nTotalDevices].PHandle = NativeMethods.CreateFile(empty,3221225472U,3U,IntPtr.Zero,3U,0U,IntPtr.Zero);
                        ++m_nTotalDevices;
                    } else if(empty.Contains("vid_0d8c&pid_0031&mi_03&col02"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 9;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCUSB_HEADSET_LUMENA DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        aoDevInfo[m_nTotalDevices].PHandle = NativeMethods.CreateFile(empty,3221225472U,3U,IntPtr.Zero,3U,0U,IntPtr.Zero);
                        ++m_nTotalDevices;
                    } else if(empty.Contains("vid_2c0d&pid_0006") || empty.Contains("vid_2c0d&pid_000b"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 6;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCLIGHT_WIRELESS DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        aoDevInfo[m_nTotalDevices].PHandle = NativeMethods.CreateFile(empty,3221225472U,3U,IntPtr.Zero,3U,0U,IntPtr.Zero);
                        ++m_nTotalDevices;
                    } else if(empty.Contains("vid_2c0d&pid_0009"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 12;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCLIGHT_EMBRAVA_EMBEDDED DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        aoDevInfo[m_nTotalDevices].PHandle = NativeMethods.CreateFile(empty,3221225472U,3U,IntPtr.Zero,3U,0U,IntPtr.Zero);
                        ++m_nTotalDevices;
                    } else if(empty.Contains("vid_0e53&pid_2519") || empty.Contains("vid_2c0d&pid_0003") || empty.Contains("vid_2c0d&pid_000a"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 7;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCLIGHT_MINI DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        aoDevInfo[m_nTotalDevices].PHandle = NativeMethods.CreateFile(empty,3221225472U,3U,IntPtr.Zero,3U,0U,IntPtr.Zero);
                        ++m_nTotalDevices;
                    } else if(empty.Contains("vid_2c0d&pid_0007&mi_03&col02"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 10;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCUSB_HEADSET_LUMENA210 DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        aoDevInfo[m_nTotalDevices].PHandle = NativeMethods.CreateFile(empty,3221225472U,3U,IntPtr.Zero,3U,1073741824U,IntPtr.Zero);
                        ++m_nTotalDevices;
                    } else if(empty.Contains("vid_2c0d&pid_0008&mi_03&col02"))
                    {
                        aoDevInfo[m_nTotalDevices].ByDeviceType = (byte) 11;
                        aoDevInfo[m_nTotalDevices].SzDeviceName = "BLYNCUSB_HEADSET_LUMENA220 DEVICE";
                        aoDevInfo[m_nTotalDevices].SzDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].NDeviceIndex = m_nTotalDevices;
                        aoDevInfo[m_nTotalDevices].PHandle = NativeMethods.CreateFile(empty,3221225472U,3U,IntPtr.Zero,3U,1073741824U,IntPtr.Zero);
                        ++m_nTotalDevices;
                    }
                }
            }
            if(num2 != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(num2);
                IntPtr zero3 = IntPtr.Zero;
            }
            if(num3 != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(num3);
                IntPtr zero3 = IntPtr.Zero;
            }
            if(classDevs != IntPtr.Zero)
                NativeMethods.SetupDiDestroyDeviceInfoList(classDevs);
           
            return flag;
        }

        //internal bool GetDevices(ref BlyncController.DeviceInfo[] aoDevInfo,ref int m_nTotalDevices) => throw new NotImplementedException();

        internal bool GetDevicePathName(ref Guid guid,IntPtr hDevInfo,uint uintDeviceID,ref string strDevicePathName)
        {
           
            IntPtr zero = IntPtr.Zero;
            int RequiredSize = 0;
            DeviceAccessDeclarations.SP_DEVICE_INTERFACE_DATA deviceInterfaceData = new DeviceAccessDeclarations.SP_DEVICE_INTERFACE_DATA();
            deviceInterfaceData.cbSize = Marshal.SizeOf((object) deviceInterfaceData);
            this.pspDeviceInterfaceData = Marshal.AllocHGlobal(Marshal.SizeOf((object) deviceInterfaceData));
            Marshal.StructureToPtr((object) deviceInterfaceData,this.pspDeviceInterfaceData,true);
            bool flag = NativeMethods.SetupDiEnumDeviceInterfaces(hDevInfo,IntPtr.Zero,ref guid,uintDeviceID,this.pspDeviceInterfaceData);
            DeviceAccessDeclarations.SP_DEVICE_INTERFACE_DATA structure = (DeviceAccessDeclarations.SP_DEVICE_INTERFACE_DATA) Marshal.PtrToStructure(this.pspDeviceInterfaceData,typeof(DeviceAccessDeclarations.SP_DEVICE_INTERFACE_DATA));
            if(flag)
            {
                NativeMethods.SetupDiGetDeviceInterfaceDetail(hDevInfo,this.pspDeviceInterfaceData,IntPtr.Zero,RequiredSize,ref RequiredSize,IntPtr.Zero);
                this.pspDeviceInterfaceDetailData = Marshal.AllocHGlobal(RequiredSize);
                Marshal.WriteInt32(this.pspDeviceInterfaceDetailData,IntPtr.Size == 4 ? 4 + Marshal.SystemDefaultCharSize : 8);
                flag = NativeMethods.SetupDiGetDeviceInterfaceDetail(hDevInfo,this.pspDeviceInterfaceData,this.pspDeviceInterfaceDetailData,RequiredSize,ref RequiredSize,IntPtr.Zero);
                IntPtr ptr = new IntPtr(this.pspDeviceInterfaceDetailData.ToInt64() + 4L);
                strDevicePathName = Marshal.PtrToStringAuto(ptr);
            }
            if(this.pspDeviceInterfaceData != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(this.pspDeviceInterfaceData);
                this.pspDeviceInterfaceData = IntPtr.Zero;
            }
            if(this.pspDeviceInterfaceDetailData != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(this.pspDeviceInterfaceDetailData);
                this.pspDeviceInterfaceDetailData = IntPtr.Zero;
            }
           
            return flag;
        }

        internal bool SendBlyncTenx20ChipSetControlCommand(string szDevicePath,byte byBlyncControlCode)
        {
          
            uint lpBytesReturned = 0;
            this.abyBlyncIntOutputReportBuffer[0] = (byte) 0;
            this.abyBlyncIntOutputReportBuffer[1] = byBlyncControlCode;
            for(int index = 2; index < this.abyBlyncIntOutputReportBuffer.Length; ++index)
                this.abyBlyncIntOutputReportBuffer[index] = (byte) 0;
            IntPtr file = NativeMethods.CreateFile(szDevicePath,3221225472U,0U,IntPtr.Zero,3U,0U,IntPtr.Zero);
            if(file.ToInt64() == (long) uint.MaxValue || file == IntPtr.Zero)
                return false;
            bool flag = NativeMethods.WriteFile(file,this.abyBlyncIntOutputReportBuffer,(uint) this.abyBlyncIntOutputReportBuffer.Length,ref lpBytesReturned,IntPtr.Zero);
            if(file != IntPtr.Zero && file.ToInt64() != (long) uint.MaxValue)
            {
                NativeMethods.CloseHandle(file);
                IntPtr zero = IntPtr.Zero;
            }
            
            return flag;
        }

        internal bool SendBlyncTenx10ChipSetControlCommand(IntPtr pHandle,byte byBlyncControlCode)
        {
            
            this.abyBlyncOutputReportBuffer[0] = (byte) 0;
            this.abyBlyncOutputReportBuffer[1] = (byte) 85; 
            this.abyBlyncOutputReportBuffer[2] = (byte) 83;
            this.abyBlyncOutputReportBuffer[3] = (byte) 66;
            this.abyBlyncOutputReportBuffer[4] = (byte) 67;
            this.abyBlyncOutputReportBuffer[5] = (byte) 0;
            this.abyBlyncOutputReportBuffer[6] = (byte) 64;
            this.abyBlyncOutputReportBuffer[7] = (byte) 2;
            this.abyBlyncOutputReportBuffer[8] = byBlyncControlCode;
            testNumber -= 10;
            bool flag = NativeMethods.HidD_SetOutputReport(pHandle,this.abyBlyncOutputReportBuffer,this.abyBlyncOutputReportBuffer.Length);
            
            return flag;
        }

        internal bool SendBlyncUsb30ChipSetControlCommand(IntPtr pHandle,byte byRedValue,byte byGreenValue,byte byBlueValue,byte byLightControl,byte byMusicControl_1,byte byMusicControl_2)
        {
            
            this.abyBlyncOutputReportBuffer[0] = (byte) 0;
            this.abyBlyncOutputReportBuffer[1] = byRedValue;
            this.abyBlyncOutputReportBuffer[2] = byBlueValue;
            this.abyBlyncOutputReportBuffer[3] = byGreenValue;
            this.abyBlyncOutputReportBuffer[4] = byLightControl;
            this.abyBlyncOutputReportBuffer[5] = byMusicControl_1;
            this.abyBlyncOutputReportBuffer[6] = byMusicControl_2;
            this.abyBlyncOutputReportBuffer[7] = byte.MaxValue;
            this.abyBlyncOutputReportBuffer[8] = byte.MaxValue;
            bool flag = NativeMethods.HidD_SetOutputReport(pHandle,this.abyBlyncOutputReportBuffer,this.abyBlyncOutputReportBuffer.Length);
            
            return flag;
        }

        internal bool SendBlyncUsbHeadset30ChipSetControlCommand(IntPtr pHandle,byte byRedValue,byte byGreenValue,byte byBlueValue,byte byLightControl)
        {
            
            for(int index = 0; index < this.abyBlyncUsbHeadsetOutputReportBuffer.Length; ++index)
                this.abyBlyncUsbHeadsetOutputReportBuffer[index] = (byte) 0;
            this.abyBlyncUsbHeadsetOutputReportBuffer[0] = (byte) 5;
            this.abyBlyncUsbHeadsetOutputReportBuffer[8] = byRedValue;
            this.abyBlyncUsbHeadsetOutputReportBuffer[9] = byBlueValue;
            this.abyBlyncUsbHeadsetOutputReportBuffer[10] = byGreenValue;
            this.abyBlyncUsbHeadsetOutputReportBuffer[11] = byLightControl;
            bool flag = NativeMethods.HidD_SetOutputReport(pHandle,this.abyBlyncUsbHeadsetOutputReportBuffer,this.abyBlyncUsbHeadsetOutputReportBuffer.Length);
            
            return flag;
        }

        internal bool SendBlyncUsbBluetoothHeadsetControlCommand(IntPtr pHandle,byte byRedValue,byte byGreenValue,byte byBlueValue,byte byLightControl)
        {
            
            for(int index = 0; index < this.abyBlyncBluetoothHeadsetOutputReportBuffer.Length; ++index)
                this.abyBlyncBluetoothHeadsetOutputReportBuffer[index] = (byte) 0;
            this.abyBlyncBluetoothHeadsetOutputReportBuffer[0] = (byte) 5;
            this.abyBlyncBluetoothHeadsetOutputReportBuffer[8] = byRedValue;
            this.abyBlyncBluetoothHeadsetOutputReportBuffer[9] = byBlueValue;
            this.abyBlyncBluetoothHeadsetOutputReportBuffer[10] = byGreenValue;
            this.abyBlyncBluetoothHeadsetOutputReportBuffer[11] = byLightControl;
            bool flag = NativeMethods.HidD_SetOutputReport(pHandle,this.abyBlyncBluetoothHeadsetOutputReportBuffer,this.abyBlyncBluetoothHeadsetOutputReportBuffer.Length);
            
            return flag;
        }

        internal bool GetDeviceUniqueId(IntPtr pHandle,ref uint unUniqueId)
        {
            
            for(int index = 0; index < this.abyBlyncFeatureReportBuffer.Length; ++index)
                this.abyBlyncFeatureReportBuffer[index] = (byte) 0;
            this.abyBlyncFeatureReportBuffer[0] = (byte) 0;
            
            bool feature = NativeMethods.HidD_GetFeature(pHandle,this.abyBlyncFeatureReportBuffer,this.abyBlyncFeatureReportBuffer.Length);
            if(!feature)
            {
                
            } else
            {
               
                for(int index = 0; index < this.abyBlyncFeatureReportBuffer.Length; ++index)
                    
                unUniqueId = (uint) ((int) this.abyBlyncFeatureReportBuffer[8] | (int) this.abyBlyncFeatureReportBuffer[7] << 8 | (int) this.abyBlyncFeatureReportBuffer[6] << 16 | (int) this.abyBlyncFeatureReportBuffer[5] << 24);
            }
            
            return feature;
        }
    }
}
