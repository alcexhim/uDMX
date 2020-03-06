//
//  Fixtures.cs
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
	public class Fixtures
	{
		public static Fixture SlimPAR56 { get; private set; } = null;

		static Fixtures()
		{
			SlimPAR56 = new Fixture ("SlimPAR56", Manufacturers.Chauvet);
			SlimPAR56.Channels.Add (new Channel (1, "Red", KnownChannel.Red));
			SlimPAR56.Channels.Add (new Channel (2, "Green", KnownChannel.Green));
			SlimPAR56.Channels.Add (new Channel (3, "Blue", KnownChannel.Blue));
			SlimPAR56.Channels.Add (new Channel (4, "Color", KnownChannel.Color));
			SlimPAR56.Channels.Add (new Channel (5, "Shutter", KnownChannel.Shutter));
			SlimPAR56.Channels.Add (new Channel (6, "Mode", KnownChannel.Mode));
			SlimPAR56.Channels.Add (new Channel (7, "Brightness", KnownChannel.Brightness));
		}
	}
}

