using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LibUSB.Legacy;

namespace uDMX
{
	public class Interface
	{
		public static Interface[] GetInterfaces()
		{
			List<Interface> list = new List<Interface>();
			Device[] devices = Device.GetDevices(0x16C0, 0x05DC);
			if (devices.Length > 0)
			{
				foreach (Device device in devices)
				{
					list.Add(new Interface(device));
				}
			}
			return list.ToArray();
		}

		private Device mvarDevice = null;
		private Interface(Device device)
		{
			mvarDevice = device;
		}
		
		private void SendCommand(CommandType type, int wValue, int wIndex, int wLength, byte[] data)
		{

		}
		
		public void SetSingleChannel(int channel, byte value)
		{
			SendCommand(CommandType.SetSingleChannel, value, channel, 0, null);
		}
		public void SetChannelRange(int startChannel, int channelCount, byte[] values)
		{
			SendCommand(CommandType.SetChannelRange, channelCount, startChannel, values.Length, values);
		}
	}
}
