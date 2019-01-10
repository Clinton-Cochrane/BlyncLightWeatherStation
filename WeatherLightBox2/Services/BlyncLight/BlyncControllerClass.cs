using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

using BlyncLightWeatherStation.Models;


namespace BlyncLightWeatherStation.Services.BlyncLight
{
	public class BlyncController
	{
		public DeviceInfo[] AoDevInfo = DeviceInfo.NewInitArray(10UL);
		internal DeviceAccess OUsbDeviceAccess = new DeviceAccess();
		internal byte ByBlyncControlCode = byte.MaxValue;
		internal byte ByBlyncIBuddyLightColorMask = 112;
		internal int MnTotalDevices;
		internal bool BResult;

		public BlyncController() => OUsbDeviceAccess.oBlyncController = this;

		private void LookForBlyncDevices(ref int nNumberOfBlyncDevices)
		{
			BResult = OUsbDeviceAccess.GetDevices(ref AoDevInfo, ref MnTotalDevices);
			nNumberOfBlyncDevices = MnTotalDevices;
		}

		public bool ResetLight(int nDeviceIndex)
		{
			BResult = false;
			if(nDeviceIndex >= 0 && nDeviceIndex <= MnTotalDevices - 1)
			{
				if(AoDevInfo[nDeviceIndex].ByDeviceType == 1)
				{
					ByBlyncControlCode = byte.MaxValue;
					BResult = OUsbDeviceAccess.SendBlyncTenx10ChipSetControlCommand(AoDevInfo[nDeviceIndex].PHandle,
						ByBlyncControlCode);
				}
			}

			return BResult;
		}

		public bool TurnOnRedLight(int nDeviceIndex)
		{
			BResult = false;
			if(nDeviceIndex >= 0 && nDeviceIndex <= MnTotalDevices - 1)
			{
				if(AoDevInfo[nDeviceIndex].ByDeviceType == 1)
				{
					ByBlyncControlCode = byte.MaxValue;
					ByBlyncControlCode &= (byte) ~ByBlyncIBuddyLightColorMask;
					ByBlyncControlCode |= 111;
					BResult = OUsbDeviceAccess.SendBlyncTenx10ChipSetControlCommand(AoDevInfo[nDeviceIndex].PHandle,
						ByBlyncControlCode);
				}
			}

			return BResult;
		}

		public bool TurnOnGreenLight(int nDeviceIndex)
		{
			BResult = false;
			if(nDeviceIndex >= 0 && nDeviceIndex <= MnTotalDevices - 1)
			{
				if(AoDevInfo[nDeviceIndex].ByDeviceType == 1)
				{
					ByBlyncControlCode = byte.MaxValue;
					ByBlyncControlCode &= (byte) ~ByBlyncIBuddyLightColorMask;
					ByBlyncControlCode |= 95;
					BResult = OUsbDeviceAccess.SendBlyncTenx10ChipSetControlCommand(AoDevInfo[nDeviceIndex].PHandle,
						ByBlyncControlCode);
				}
			}

			return BResult;
		}

		public void PlayRecipe(List<BlyncLightInstruction> recipe)
		{
			while(true)
			{
				foreach(BlyncLightInstruction blyncLightInstruction in recipe)
				{
					DisplayColor(blyncLightInstruction.Color);
					Thread.Sleep((int) blyncLightInstruction.DisplayTime);
				}
			}
		}

		public bool TurnOnYellowLight(int nDeviceIndex)
		{
			BResult = false;
			if(nDeviceIndex >= 0 && nDeviceIndex <= MnTotalDevices - 1)
			{
				if(AoDevInfo[nDeviceIndex].ByDeviceType == 1)
				{
					ByBlyncControlCode = byte.MaxValue;
					ByBlyncControlCode &= (byte) ~ByBlyncIBuddyLightColorMask;
					ByBlyncControlCode |= 79;
					BResult = OUsbDeviceAccess.SendBlyncTenx10ChipSetControlCommand(AoDevInfo[nDeviceIndex].PHandle,
						ByBlyncControlCode);
				}
			}

			return BResult;
		}

		public bool TurnOnBlueLight(int nDeviceIndex)
		{
			BResult = false;
			if(nDeviceIndex >= 0 && nDeviceIndex <= MnTotalDevices - 1)
			{
				if(AoDevInfo[nDeviceIndex].ByDeviceType == 1)
				{
					ByBlyncControlCode = byte.MaxValue;
					ByBlyncControlCode &= (byte) ~ByBlyncIBuddyLightColorMask;
					ByBlyncControlCode |= 63;
					BResult = OUsbDeviceAccess.SendBlyncTenx10ChipSetControlCommand(AoDevInfo[nDeviceIndex].PHandle,
						ByBlyncControlCode);
				}
			}

			return BResult;
		}

		public bool TurnOnMagentaLight(int nDeviceIndex)
		{
			BResult = false;
			if(nDeviceIndex >= 0 && nDeviceIndex <= MnTotalDevices - 1)
			{
				if(AoDevInfo[nDeviceIndex].ByDeviceType == 1)
				{
					ByBlyncControlCode = byte.MaxValue;
					ByBlyncControlCode &= (byte) ~ByBlyncIBuddyLightColorMask;
					ByBlyncControlCode |= 47;
					BResult = OUsbDeviceAccess.SendBlyncTenx10ChipSetControlCommand(AoDevInfo[nDeviceIndex].PHandle,
						ByBlyncControlCode);
				}
			}

			return BResult;
		}

		public bool TurnOnWhiteLight(int nDeviceIndex)
		{
			BResult = false;
			if(nDeviceIndex >= 0 && nDeviceIndex <= MnTotalDevices - 1)
			{
				if(AoDevInfo[nDeviceIndex].ByDeviceType == 1)
				{
					ByBlyncControlCode = byte.MaxValue;
					ByBlyncControlCode &= (byte) ~ByBlyncIBuddyLightColorMask;
					ByBlyncControlCode |= 15;
					BResult = OUsbDeviceAccess.SendBlyncTenx10ChipSetControlCommand(AoDevInfo[nDeviceIndex].PHandle,
						ByBlyncControlCode);
				}
			}

			return BResult;
		}

		public bool TurnOnCyanLight(int nDeviceIndex)
		{
			BResult = false;
			if(nDeviceIndex >= 0 && nDeviceIndex <= MnTotalDevices - 1)
			{
				if(AoDevInfo[nDeviceIndex].ByDeviceType == 1)
				{
					ByBlyncControlCode = byte.MaxValue;
					ByBlyncControlCode &= (byte) ~ByBlyncIBuddyLightColorMask;
					ByBlyncControlCode |= 31;
					BResult = OUsbDeviceAccess.SendBlyncTenx10ChipSetControlCommand(AoDevInfo[nDeviceIndex].PHandle,
						ByBlyncControlCode);
				}
			}

			return BResult;
		}

		public void CloseDevices(int nNumberOfDevices)
		{
			for(var index = 0; index < nNumberOfDevices; ++index)
			{
				if(uint.MaxValue             != (uint) AoDevInfo[index].PHandle.ToInt64() &&
					AoDevInfo[index].PHandle != IntPtr.Zero                               &&
					(AoDevInfo[index].ByDeviceType == 1))
				{
					NativeMethods.CloseHandle(AoDevInfo[index].PHandle);
					AoDevInfo[index].PHandle = IntPtr.Zero;
				}
			}
		}

		public int InitBlyncDevices()
		{
			var nNumberOfBlyncDevices = 0;
			if(MnTotalDevices > 0)
			{
				CloseDevices(MnTotalDevices);
			}

			MnTotalDevices = 0;
			LookForBlyncDevices(ref nNumberOfBlyncDevices);

			return nNumberOfBlyncDevices;
		}

		private void DisplayColor(BlyncLightColor color)
		{
			switch(color.ToString())
			{
				case"Blue":

					PlayBlyncLightBlue();

					break;
				case"Cyan":

					PlayBlyncLightCyan();

					break;
				case"Green":

					PlayBlyncLightGreen();

					break;
				case"None":
				case"Off":

					PlayBlyncLightOff();

					break;
				case"Purple":

					PlayBlyncLightMagenta();

					break;
				case"Red":

					PlayBlyncLightRed();

					break;
				case"White":

					PlayBlyncLightWhite();

					break;
				case"Yellow":

					PlayBlyncLightYellow();

					break;
			}
		}

		private void PlayBlyncLightCyan()
		{
			for(var nDeviceIndex = 0; nDeviceIndex < MnTotalDevices; ++nDeviceIndex)
			{
				BResult = TurnOnCyanLight(nDeviceIndex);
			}
		}

		private void PlayBlyncLightWhite()
		{
			for(var nDeviceIndex = 0; nDeviceIndex < MnTotalDevices; ++nDeviceIndex)
			{
				BResult = TurnOnWhiteLight(0);
			}
		}

		private void PlayBlyncLightBlue()
		{
			for(var nDeviceIndex = 0; nDeviceIndex < MnTotalDevices; ++nDeviceIndex)
			{
				BResult = TurnOnBlueLight(nDeviceIndex);
			}
		}

		private void PlayBlyncLightYellow()
		{
			for(var nDeviceIndex = 0; nDeviceIndex < MnTotalDevices; ++nDeviceIndex)
			{
				BResult = TurnOnYellowLight(nDeviceIndex);
			}
		}

		private void PlayBlyncLightGreen()
		{
			for(var nDeviceIndex = 0; nDeviceIndex < MnTotalDevices; ++nDeviceIndex)
			{
				BResult = TurnOnGreenLight(nDeviceIndex);
			}
		}

		private void PlayBlyncLightRed()
		{
			for(var nDeviceIndex = 0; nDeviceIndex < MnTotalDevices; ++nDeviceIndex)
			{
				BResult = TurnOnRedLight(nDeviceIndex);
			}
		}

		private void PlayBlyncLightOff()
		{
			for(var nDeviceIndex = 0; nDeviceIndex < MnTotalDevices; ++nDeviceIndex)
			{
				BResult = ResetLight(nDeviceIndex);
			}
		}

		private void PlayBlyncLightMagenta()
		{
			for(var nDeviceIndex = 0; nDeviceIndex < MnTotalDevices; ++nDeviceIndex)
			{
				BResult = TurnOnMagentaLight(nDeviceIndex);
			}
		}


		public class DeviceInfo
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string SzDevicePath;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string SzDeviceName;
			public byte ByDeviceType;
			public IntPtr PHandle;
			public int NDeviceIndex;

			internal static DeviceInfo[] NewInitArray(ulong num)
			{
				var deviceInfoArray = new DeviceInfo[num];
				for(ulong index = 0; index < num; ++index)
				{
					deviceInfoArray[index] = new DeviceInfo();
				}

				return deviceInfoArray;
			}
		}
	}
}