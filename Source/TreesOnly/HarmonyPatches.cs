using System.Reflection;
using HarmonyLib;
using Verse;

namespace TreesOnly;

[StaticConstructorOnStartup]
public static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("Mlie.SeparateTreeChoppingPriority").PatchAll(Assembly.GetExecutingAssembly());
    }
}