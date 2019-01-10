// Decompiled with JetBrains decompiler
// Type: Blynclight.DeviceAccessDeclarations
// Assembly: Blynclight, Version=0.3.0.11, Culture=neutral, PublicKeyToken=null
// MVID: 5BBF77FB-8F3D-4A6F-B095-307E683776AC
// Assembly location: C:\Users\cecochr\Downloads\Embrava_SDK_For_Windows_v3.0.3\Embrava_SDK_For_Windows_v3.0.3\Binaries\AnyCpu\Blynclight.dll

using System;
using System.Runtime.InteropServices;


namespace BlyncLightWeatherStation.Services.BlyncLight
{
    public class DeviceAccessDeclarations
    {
        [StructLayout(LayoutKind.Sequential)]
        internal class SP_DEVINFO_DATA
        {
            public int cbSize;
            public Guid ClassGuid;
            public int DevInst;
            public IntPtr Reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            public int cbSize;
            [MarshalAs(UnmanagedType.ByValArray,SizeConst = 260)]
            public byte[] DevicePath;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class SP_DEVICE_INTERFACE_DATA
        {
            public int cbSize;
            public Guid InterfaceClassGuid;
            public int Flags;
            public UIntPtr Reserved;
        }

        [StructLayout(LayoutKind.Sequential,Pack = 8)]
        public class OVERLAPPED
        {
            private IntPtr InternalLow;
            private IntPtr InternalHigh;
            public long Offset;
            public IntPtr hEvent;
        }
    }
}
