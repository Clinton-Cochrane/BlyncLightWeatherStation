// Decompiled with JetBrains decompiler
// Type: Blynclight.NativeMethods
// Assembly: Blynclight, Version=0.3.0.11, Culture=neutral, PublicKeyToken=null
// MVID: 5BBF77FB-8F3D-4A6F-B095-307E683776AC
// Assembly location: C:\Users\cecochr\Downloads\Embrava_SDK_For_Windows_v3.0.3\Embrava_SDK_For_Windows_v3.0.3\Binaries\AnyCpu\Blynclight.dll

using System;
using System.Runtime.InteropServices;


namespace BlyncLightWeatherStation.Services.BlyncLight
{
    internal class NativeMethods
    {
        [DllImport("hid.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern void HidD_GetHidGuid(ref Guid HidGuid);

        [DllImport("hid.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern bool HidD_SetOutputReport(IntPtr HidDeviceObject,byte[] lpReportBuffer,int ReportBufferLength);

        [DllImport("hid.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern bool HidD_SetFeature(IntPtr HidDeviceObject,byte[] lpReportBuffer,int ReportBufferLength);

        [DllImport("hid.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern bool HidD_GetFeature(IntPtr HidDeviceObject,[Out] byte[] lpBuffer,int ReportBufferLength);

        [DllImport("setupapi.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid,IntPtr Enumerator,IntPtr hwndParent,uint Flags);

        [DllImport("setupapi.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        public static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

        [DllImport("setupapi.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern bool SetupDiEnumDeviceInfo(IntPtr hDevInfo,uint uintDeviceID,IntPtr psDeviceInfoData);

        [DllImport("setupapi.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern bool SetupDiGetDeviceRegistryProperty(IntPtr DeviceInfoSet,IntPtr psDeviceInfoData,uint Property,ref uint PropertyRegDataType,IntPtr pchBuffer,uint uintBufferSize,ref uint untBufferSize);

        [DllImport("setupapi.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern bool SetupDiEnumDeviceInterfaces(IntPtr DeviceInfoSet,IntPtr DeviceInfoData,ref Guid InterfaceClassGuid,uint MemberIndex,IntPtr psDeviceInterfaceData);

        [DllImport("setupapi.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo,IntPtr pspDeviceInterfaceData,IntPtr DeviceInterfaceDetailData,int DeviceInterfaceDetailDataSize,ref int RequiredSize,IntPtr DeviceInfoData);

        [DllImport("kernel32.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern uint GetLastError();

        [DllImport("kernel32.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern IntPtr CreateFile(string lpFileName,uint dwDesiredAccess,uint dwShareMode,IntPtr lpSecurityAttributes,uint dwCreationDisposition,uint dwFlagsAndAttributes,IntPtr hTemplateFile);

        [DllImport("kernel32.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr pHandle);

        [DllImport("kernel32.dll",CharSet = CharSet.Unicode,SetLastError = true)]
        internal static extern bool WriteFile(IntPtr pHandle,byte[] lpReportBuffer,uint unReportBufferSize,ref uint lpBytesReturned,IntPtr lpOverlapped);
    }
}
