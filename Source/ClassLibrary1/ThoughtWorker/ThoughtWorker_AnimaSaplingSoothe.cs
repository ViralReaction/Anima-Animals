using RimWorld;
using System;
using System.Collections.Generic;
using Verse;

namespace AnimaAnimals
{
    public class ThoughtWorker_AnimaSaplingSoothe : ThoughtWorker
    {
        private const float Radius = 10f;

        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if (!p.Spawned)
                return (ThoughtState)false;
            List<Thing> thingList = p.Map.listerThings.ThingsOfDef(ThingDefOf.AnimaSapling);
            for (int index = 0; index < thingList.Count; ++index)
            {
                if (p.Position.InHorDistOf(thingList[index].Position, 15f))
                    return (ThoughtState)true;
            }
            return (ThoughtState)false;
        }
    }

}
