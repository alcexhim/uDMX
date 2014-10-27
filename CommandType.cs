using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uDMX
{
	public enum CommandType
	{
		SetSingleChannel = 1,
		SetChannelRange = 2,
		StartBootloader = 0xF8
	}
}
