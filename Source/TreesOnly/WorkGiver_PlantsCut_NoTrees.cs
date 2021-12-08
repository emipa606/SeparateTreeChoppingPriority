using System.Collections.Generic;
using RimWorld;
using Verse;

namespace TreesOnly;

public class WorkGiver_PlantsCut_NoTrees : WorkGiver_PlantsCut
{
    public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
    {
        var allDesignations = pawn.Map.designationManager.allDesignations;

        foreach (var designation in allDesignations)
        {
            if (designation.def != DesignationDefOf.CutPlant && designation.def != DesignationDefOf.HarvestPlant)
            {
                continue;
            }

            if (designation.target.Thing is Plant plant && !plant.def.plant.IsTree)
            {
                yield return designation.target.Thing;
            }
        }
    }
}