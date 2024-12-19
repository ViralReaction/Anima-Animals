using RimWorld;
using Verse;

namespace AnimaAnimals
{
    [DefOf]
    public static class ThingDefOf
    {
        public static ThingDef AnimaSapling;
        public static ThingDef AnimaBear;
        public static ThingDef AnimaFox;
        public static ThingDef AnimaMegaspider;
        public static ThingDef AnimaMuffalo;
        public static ThingDef AnimaThrumbo;
        public static ThingDef AnimaWarg;
        public static ThingDef AnimaYak;

        static ThingDefOf() => DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
    }

}
