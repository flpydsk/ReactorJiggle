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
using HarmonyLib;

namespace ReactorJiggle
{
    [HarmonyPatch(typeof(PLReactorInstance), "Update")]
    [HarmonyBefore(new string[] { "modders.hardmode" })]
    [HarmonyPriority(300)]
    internal class ReactorInstance
    {
        public static float Jiggle;
        static void Prefix(PLReactorInstance __instance, ref float __state)
        {
            if (__instance.MyShipInfo)
            {
                __state = __instance.MyShipInfo.CoreInstability;

                float temperature = __instance.MyShipInfo.MyStats.ReactorTempCurrent / __instance.MyShipInfo.MyStats.ReactorTempMax;

                //Some reactors require specific values to get maximum jiggle inside the reactor casing.
                //Core should be just bearly contained at 100% heat.
                switch (__instance.MyShipInfo.ShipTypeID)
                {
                    case EShipType.E_ROLAND:
                        Jiggle = 2.5f;
                        break;
                    case EShipType.E_OUTRIDER:
                        Jiggle = 0.3f;
                        break;
                    case EShipType.E_ANNIHILATOR:
                        Jiggle = 2f;
                        break;
                    case EShipType.E_ABYSS_PLAYERSHIP:
                        Jiggle = 0.4f;
                        break;
                    case EShipType.E_FLUFFY_TWO:
                        Jiggle = 1.5f;
                        break;
                    case EShipType.OLDWARS_SYLVASSI:
                        Jiggle = 1.2f;
                        break;
                    case EShipType.E_POLYTECH_SHIP:
                        Jiggle = 2f;
                        break;
                    case EShipType.OLDWARS_HUMAN:
                        Jiggle = 1.5f;
                        break;
                    default:
                        Jiggle = 0.7f;
                        break;
                }
                //use CoreInstability as a distance multiplier for the random orb movement
                //100f to counteract to 0.01f in PLReactorInstance.
                //*2 + 1 to make __state range from 1 to 3.
                //-6 to reduce wobble at idle temp, 7 should be no wobble.
                __instance.MyShipInfo.CoreInstability = (temperature * 100f - 6.5f) * Jiggle;
            }
        }

        static void Postfix(PLReactorInstance __instance, float __state)
        {
            __instance.MyShipInfo.CoreInstability = __state;
        }
    }
}
