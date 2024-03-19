using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using UnityEngine;

namespace AnimaAnimals
{
    public class IncidentWorker_AnimaYaksPass : IncidentWorker
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            Map target = (Map)parms.target;
            return !target.gameConditionManager.ConditionIsActive(GameConditionDefOf.ToxicFallout) && target.mapTemperature.SeasonAndOutdoorTemperatureAcceptableFor(ThingDefOf.AnimaYak) && this.TryFindEntryCell(target, out IntVec3 _);
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map target = (Map)parms.target;
            IntVec3 cell;
            if (!this.TryFindEntryCell(target, out cell))
                return false;
            PawnKindDef kindDef = PawnKindDefOf.AnimaYak;
            int num1 = Mathf.Clamp(GenMath.RoundRandom(StorytellerUtility.DefaultThreatPointsNow((IIncidentTarget)target) / kindDef.combatPower), 2, Rand.RangeInclusive(3, 6));
            int num2 = Rand.RangeInclusive(90000, 150000);
            IntVec3 result = IntVec3.Invalid;
            if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(cell, target, 10f, out result))
                result = IntVec3.Invalid;
            Pawn pawn = (Pawn)null;
            for (int index = 0; index < num1; ++index)
            {
                IntVec3 intVec3 = CellFinder.RandomClosewalkCellNear(cell, target, 10);
                pawn = PawnGenerator.GeneratePawn(kindDef);
                GenSpawn.Spawn((Thing)pawn, intVec3, target, Rot4.Random, WipeMode.Vanish, false);
                pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + num2;
                if (result.IsValid)
                    pawn.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(result, target, 10);
            }
            this.SendStandardLetter("LetterLabelAnimaYaksPass".Translate((NamedArgument)kindDef.label).CapitalizeFirst(), "LetterAnimaYakPass".Translate((NamedArgument)kindDef.label), LetterDefOf.PositiveEvent, parms, (LookTargets)(Thing)pawn);
            return true;
        }

        private bool TryFindEntryCell(Map map, out IntVec3 cell) => RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f);
    }
}