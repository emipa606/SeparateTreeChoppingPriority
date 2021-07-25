using HarmonyLib;
using RimWorld;
using Verse;

namespace TreesOnly
{
    [DefOf]
    public static class WorkTypeDefOf
    {
        public static WorkTypeDef TreeChopping;
    }

    [HarmonyPatch(typeof(PlantUtility))]
    [HarmonyPatch(nameof(PawnWillingToCutPlant_Job))]
    public static class PlantUtility_Patch
    {
        [HarmonyPrefix]
        public static bool PawnWillingToCutPlant_Job(ref bool __result, Thing plant, Pawn pawn)
        {
            // Possibly block cutting down trees when considered for clearing place for other work.
            if(!pawn.workSettings.WorkIsActive(WorkTypeDefOf.TreeChopping))
            {
                __result = false;
                return false;
            }
            return true; // execute the original version of the function
        }
    }
}
