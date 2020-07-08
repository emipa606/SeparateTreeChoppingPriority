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
    public class WorkGiver_TreesChop : WorkGiver_Scanner
    {
        public override PathEndMode PathEndMode
        {
            get
            {
                return PathEndMode.Touch;
            }
        }

        public override Danger MaxPathDanger(Pawn pawn)
        {
            return Danger.Deadly;
        }

        public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
        {
            List<Designation> desList = pawn.Map.designationManager.allDesignations;

            for (int i = 0; i < desList.Count; i++)
            {
                Designation des = desList[i];             
                if (des.def == DesignationDefOf.CutPlant || des.def == DesignationDefOf.HarvestPlant)
                {
                    Plant plant = des.target.Thing as Plant;

                    if (plant != null)
                    {
                        if (plant.def.plant.IsTree)
                        {
                            yield return des.target.Thing;
                        }
                    }
                }
            }
        }

        public override Job JobOnThing(Pawn pawn, Thing t, bool forced = false)
        {
            if (t.def.category != ThingCategory.Plant)
            {
                return null;
            }
            if (!pawn.CanReserve(t, 1, -1, null, false))
            {
                return null;
            }
            if (t.IsForbidden(pawn))
            {
                return null;
            }
            if (t.IsBurning())
            {
                return null;
            }
            Job result = null;
            foreach (Designation current in pawn.Map.designationManager.AllDesignationsOn(t))
            {                
                if (current.def == DesignationDefOf.HarvestPlant)
                {
                    if (!((Plant)t).HarvestableNow || !((Plant)t).def.plant.IsTree)
                    {
                        break;
                    }
                    result = new Job(JobDefOf.HarvestDesignated, t);
                    break;
                }
                else if (current.def == DesignationDefOf.CutPlant)
                {
                    if (!((Plant)t).def.plant.IsTree)
                    {
                        break;
                    }
                    result = new Job(JobDefOf.CutPlantDesignated , t);
                    break;
                }
            }
            return result;
        }
    }
}
