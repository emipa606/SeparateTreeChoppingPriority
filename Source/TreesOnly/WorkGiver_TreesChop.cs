using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace TreesOnly;

public class WorkGiver_TreesChop : WorkGiver_Scanner
{
    public override PathEndMode PathEndMode => PathEndMode.Touch;

    public override Danger MaxPathDanger(Pawn pawn)
    {
        return Danger.Deadly;
    }

    public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
    {
        var desList = pawn.Map.designationManager.allDesignations;

        foreach (var des in desList)
        {
            if (des.def != DesignationDefOf.CutPlant && des.def != DesignationDefOf.HarvestPlant)
            {
                continue;
            }

            if (des.target.Thing is not Plant plant)
            {
                continue;
            }

            if (plant.def.plant.IsTree)
            {
                yield return des.target.Thing;
            }
        }
    }

    public override Job JobOnThing(Pawn pawn, Thing t, bool forced = false)
    {
        if (t.def.category != ThingCategory.Plant)
        {
            return null;
        }

        if (!pawn.CanReserve(t))
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
        foreach (var current in pawn.Map.designationManager.AllDesignationsOn(t))
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

            if (current.def != DesignationDefOf.CutPlant)
            {
                continue;
            }

            if (!((Plant)t).def.plant.IsTree)
            {
                break;
            }

            result = new Job(JobDefOf.CutPlantDesignated, t);
            break;
        }

        return result;
    }
}