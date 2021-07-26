using System.Reflection;
using HarmonyLib;
using Verse;

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