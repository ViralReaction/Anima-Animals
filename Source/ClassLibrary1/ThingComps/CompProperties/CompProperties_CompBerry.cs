using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AnimaAnimals
{
    internal class CompProperties_CompBerry : CompProperties
    {
        public int berryIntervalDays;
        public int berryAmount = 1;
        public ThingDef berryDef;
        public bool berryFemaleOnly = false;

        public CompProperties_CompBerry() => this.compClass = typeof(CompBerry);
    }
}
