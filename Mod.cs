/*
    Reactor Jiggle With this mod we can increase the action in the engineering bay by having the core fly around in the reactor proportional to the temperature.
    Copyright (C) 2023 FloppyDisk 18107
    https://github.com/flpydsk/ReactorJiggle.git

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using PulsarModLoader;

namespace ReactorJiggle
{
    public class Mod : PulsarMod
    {
        public override string License => "GNU GPL-3.0";
        public override string Version => "0.1.2";
        public override string Author => "FloppyDisk&18107";
        public override string Name => "ReactorJiggle";
        public override string HarmonyIdentifier() => $"{Author}.{Name}";
        public override string ShortDescription => "Jiggles the reactor core with temp";
        public override string ReadmeURL => "https://raw.githubusercontent.com/flpydsk/ReactorJiggle/master/README";

    }
}
