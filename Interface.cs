using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MBS.Framework.USB;

namespace uDMX
{
	public class Interface
	{
		static UsbContext ctx = null;
		public static Interface[] GetInterfaces()
		{
			if (ctx == null) {
				ctx = new UsbContext();
			}
			List<Interface> list = new List<Interface>();
			UsbDevice[] devices = ctx.GetDevices(0x16C0, 0x05DC);
			if (devices.Length > 0)
			{
				foreach (UsbDevice device in devices)
				{
					list.Add(new Interface(device));
				}
			}
			return list.ToArray();
		}

		private UsbDevice mvarDevice = null;
		private Interface(UsbDevice device)
		{
			mvarDevice = device;
		}

		public void Open()
		{
			mvarDevice.Open ();
			mvarDevice.ClaimInterface (0);
		}
		public void Close()
		{
			mvarDevice.ReleaseInterface (0);
			mvarDevice.Close ();
		}
		
		private int SendCommand(CommandType type, int wValue, int wIndex, int wLength, byte[] data)
		{
			mvarDevice.ControlTransfer((byte)((byte)EndpointDirection.Out | (byte)RequestType.Vendor | (byte)RequestRecipient.Device),
				(byte) type,
				(ushort)wValue,
				(ushort)wIndex,
				data,
				// (ushort)wLength,
				2000);
			return 0;
		}
		
		public int SetSingleChannel(int channel, byte value)
		{
			return SendCommand(CommandType.SetSingleChannel, value, channel, 0, null);
		}
		public int SetChannelRange(int startChannel, int channelCount, byte[] values)
		{
			return SendCommand(CommandType.SetChannelRange, channelCount, startChannel, values.Length, values);
		}
	}
}
