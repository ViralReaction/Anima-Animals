using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace AnimaAnimals
{
    public class IncidentWorker_AnimaThrumboPasses : IncidentWorker
    {
        protected virtual bool CanFireNowSub(IncidentParms parms)
        {
            Map target = (Map)parms.target;
            return !target.gameConditionManager.ConditionIsActive(GameConditionDefOf.ToxicFallout) && target.mapTemperature.SeasonAndOutdoorTemperatureAcceptableFor(ThingDefOf.AnimaThrumbo) && this.TryFindEntryCell(target, out IntVec3 _);
        }

        protected virtual bool TryExecuteWorker(IncidentParms parms)
        {
            Map target = (Map)parms.target;
            IntVec3 cell;
            if (!this.TryFindEntryCell(target, out cell))
                return false;
            PawnKindDef pawnKindDef = PawnKindDefOf.AnimaThrumbo;
            int num1 = Mathf.Clamp(GenMath.RoundRandom(StorytellerUtility.DefaultThreatPointsNow((IIncidentTarget)target) / pawnKindDef.combatPower), 1, Rand.RangeInclusive(3, 6));
            int num2 = Rand.RangeInclusive(90000, 150000);
            IntVec3 result = IntVec3.Invalid;
            if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(cell, target, 10f, out result))
                result = IntVec3.Invalid;
            Pawn newThing = (Pawn)null;
            for (int index = 0; index < num1; ++index)
            {
                IntVec3 loc = CellFinder.RandomClosewalkCellNear(cell, target, 10);
                newThing = PawnGenerator.GeneratePawn(pawnKindDef);
                GenSpawn.Spawn((Thing)newThing, loc, target, Rot4.Random);
                newThing.mindState.exitMapAfterTick = Find.TickManager.TicksGame + num2;
                if (result.IsValid)
                    newThing.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(result, target, 10);
            }
            this.SendStandardLetter("LetterLabelAnimaThrumboPass".Translate((NamedArgument)pawnKindDef.label).CapitalizeFirst(), "LetterAnimaThrumboPasses".Translate((NamedArgument)pawnKindDef.label), LetterDefOf.PositiveEvent, parms, (LookTargets)(Thing)newThing);
            return true;
        }

        private bool TryFindEntryCell(Map map, out IntVec3 cell) => RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f);
    }
}