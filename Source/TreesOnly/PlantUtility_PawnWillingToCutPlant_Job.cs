using HarmonyLib;
using RimWorld;
using Verse;

namespace TreesOnly
{
    [HarmonyPatch(typeof(PlantUtility), "PawnWillingToCutPlant_Job")]
    public static class PlantUtility_PawnWillingToCutPlant_Job
    {
        public static bool Prefix(ref bool __result, Thing plant, Pawn pawn)
        {
            if (!plant.def.plant.IsTree)
                return true; // execute the original version of the function

            // Possibly block cutting down trees when considered for clearing place for other work.
            if (pawn.workSettings.WorkIsActive(WorkTypeDefOf.TreeChopping))
            {
                return true; // execute the original version of the function
            }

            __result = false;
            return false;
        }
    }
}