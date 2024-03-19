using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AnimaAnimals
{
    public class CompBerry : CompHasGatherableBodyResource
    {
        protected override int GatherResourcesIntervalDays => this.Props.berryIntervalDays;

        protected override int ResourceAmount => this.Props.berryAmount;

        protected override ThingDef ResourceDef => this.Props.berryDef;

        protected override string SaveKey => "BerriesGrowth";

        private CompProperties_CompBerry Props => (CompProperties_CompBerry)this.props;

        protected override bool Active
        {
            get
            {
                if (!base.Active)
                    return false;
                Pawn parent = this.parent as Pawn;
                return (!this.Props.berryFemaleOnly || parent == null || parent.gender == Gender.Female) && (parent == null || parent.ageTracker.CurLifeStage.milkable);
            }
        }

        public override string CompInspectStringExtra() => this.Active ? (string)("BerriesGrowth".Translate() + ": " + this.Fullness.ToStringPercent()) : (string)null;
    }
}
