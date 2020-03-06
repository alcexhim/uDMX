//
//  FixtureInstance.cs
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
	public class FixtureInstance
	{
		public class FixtureInstanceCollection
			: System.Collections.ObjectModel.Collection<FixtureInstance>
		{
		}

		/// <summary>
		/// The initial address of this fixture.
		/// </summary>
		/// <value>The address.</value>
		public int Address { get; set; } = 0;

		public Fixture Fixture { get; private set; } = null;

		public void SetChannelValue(KnownChannel ch, byte value)
		{
			foreach (Channel ch1 in Fixture.Channels) {
				if (ch1.Type == ch) {
					SetChannelValue (ch1, value);
					break;
				}
			}
		}

		private System.Collections.Generic.Dictionary<Channel, byte> _chvalues = new System.Collections.Generic.Dictionary<Channel, byte>();
		public void SetChannelValue(Channel ch, byte value)
		{
			_chvalues [ch] = value;
		}
		public byte GetChannelValue(Channel ch, byte defaultValue = 0)
		{
			if (_chvalues.ContainsKey (ch))
				return _chvalues [ch];
			return defaultValue;
		}

		public FixtureInstance(Fixture fixture)
		{
			Fixture = fixture;
		}
	}
}

