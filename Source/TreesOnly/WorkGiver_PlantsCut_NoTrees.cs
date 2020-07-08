using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using Verse.AI;

namespace TreesOnly
{
    public class WorkGiver_PlantsCut_NoTrees : WorkGiver_PlantsCut
    {
        public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
        {
            var allDesignations = pawn.Map.designationManager.allDesignations;

            for (int i = 0; i < allDesignations.Count; i++)
            {
                var designation = allDesignations[i];

                if (designation.def == DesignationDefOf.CutPlant || designation.def == DesignationDefOf.HarvestPlant)
                {
                    var plant = designation.target.Thing as Plant;
                    if (!plant.def.plant.IsTree)
                    {
                        yield return designation.target.Thing;
                    }
                }
            }
        }
    }
}
