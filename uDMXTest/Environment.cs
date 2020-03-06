//
//  Environment.cs
//
//  Author:
//       Mike Becker <alcexhim@gmail.com>
//
//  Copyright (c) 2019 Mike Becker
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;

namespace uDMXTest
{
	public class Environment
	{
		private uDMX.Interface _intf = null;
		public Environment(uDMX.Interface intf)
		{
			_intf = intf;
		}

		public FixtureInstance.FixtureInstanceCollection Fixtures { get; } = new FixtureInstance.FixtureInstanceCollection();

		public void Send()
		{
			byte[] dmxdata = new byte[512];
			foreach (FixtureInstance inst in Fixtures) {
				foreach (Channel ch in inst.Fixture.Channels) {
					dmxdata[(inst.Address - 1) + (ch.Address - 1)] = inst.GetChannelValue (ch);
				}
			}

			int r = _intf.SetChannelRange (0, dmxdata.Length, dmxdata);
		}
	}
}

