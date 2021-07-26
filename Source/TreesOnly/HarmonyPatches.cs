using HarmonyLib;
using RimWorld;
using Verse;
using System.Reflection;

namespace TreesOnly
{
    [StaticConstructorOnStartup]
    public class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = new Harmony("Mlie.SeparateTreeChoppingPriority");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
