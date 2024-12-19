using RimWorld;
using Verse;

namespace AnimaAnimals
{
    [DefOf]
    public static class PawnKindDefOf
    {
        public static PawnKindDef AnimaBear;
        public static PawnKindDef AnimaFox;
        public static PawnKindDef AnimaMegaspider;
        public static PawnKindDef AnimaMuffalo;
        public static PawnKindDef AnimaThrumbo;
        public static PawnKindDef AnimaWarg;
        public static PawnKindDef AnimaYak;

        static PawnKindDefOf() => DefOfHelper.EnsureInitializedInCtor(typeof(PawnKindDefOf));
    }
   
}
