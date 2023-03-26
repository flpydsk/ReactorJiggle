//Copyright 2023 (c) Floppydisk
//GPL 3.0-only
using HarmonyLib;

namespace ReactorJiggle
{
    [HarmonyPatch(typeof(PLReactorInstance), "Update")]
    internal class ReactorInstance
    {
        public static float Jiggle;
        static void Prefix(PLReactorInstance __instance, ref float __state)
        {
            if (__instance.MyShipInfo)
            {
                //save CoreInstability value before any modifications (values generally between 0 and 1)
                __state = __instance.MyShipInfo.CoreInstability;

                //get temperature (values generally between 0 and 1)
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
            //restore saved value before returning from method to ensure that the correct value is sent to anything that requires the CoreInstability float
            __instance.MyShipInfo.CoreInstability = __state;
        }
    }
}
