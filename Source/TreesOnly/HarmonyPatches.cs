using System.Reflection;
using HarmonyLib;
using Verse;

namespace TreesOnly;

[StaticConstructorOnStartup]
public class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("Mlie.SeparateTreeChoppingPriority").PatchAll(Assembly.GetExecutingAssembly());
    }
}