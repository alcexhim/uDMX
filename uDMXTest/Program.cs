//
//  Program.cs
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
using uDMX;
using LibUSB;

namespace uDMXTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (Context ctx = new Context ()) {
				// ctx.DebugLevel = DebugLevel.Debug;

				Interface[] intfs = Interface.GetInterfaces ();
				if (intfs.Length == 0) {
					Console.WriteLine ("uDMX device not connected!");
					return;
				}

				Interface intf = intfs [0];
				if (intf != null) {
					intf.Open ();

					//Megastrobe: 0-5 segments, 6-7 timing data
					// Slimpar64: 

					Environment env = new Environment (intf);

					FixtureInstance inst = new FixtureInstance (Fixtures.SlimPAR56);
					inst.Address = 1;

                    // 3-ch
                    inst.SetChannelValue(new Channel(1, null), 255);
                    inst.SetChannelValue(new Channel(2, null), 0);
                    inst.SetChannelValue(new Channel(3, null), 0);
                    inst.SetChannelValue(new Channel(4, null), 255);
                    inst.SetChannelValue(new Channel(5, null), 0);
                    inst.SetChannelValue(new Channel(6, null), 255);
                    inst.SetChannelValue(new Channel(7, null), 255);
                    inst.SetChannelValue(new Channel(8, null), 255);
                    inst.SetChannelValue(new Channel(21, null), 255);
                    inst.SetChannelValue(new Channel(22, null), 255);
                    inst.SetChannelValue(new Channel(23, null), 255);

                    // for the megastrobe, in 8-ch mode
                    // ch 0-5 are dimmers for the six rows of two LEDs each
                    // ch 6 and 7 are shutter effects && shutter effects speed

                    env.Fixtures.Add(inst);

					env.Send ();

					intf.Close ();

				}
			}
		}
	}
}
