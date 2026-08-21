using System.Collections.Generic;

namespace FalseAether;
internal static class LookupTables
{
    internal struct CardinalPair
    {
        public AtomType Earthly;
        public AtomType Heavenly;

        public CardinalPair(AtomType earthly, AtomType heavenly)
        {
            Earthly = earthly;
            Heavenly = heavenly;
        }
    }
    internal struct Anymae
    {
        public AtomType Alignment;
        public int Morality;
        public int Grace;

        public Anymae(AtomType alignment, int morality, int grace)
        {
            Alignment = alignment;
            Morality = morality;
            Grace = grace;
        }
    }
    
    internal static List<Anymae> AlignmentChart = new();
    internal static List<CardinalPair> CardinalChart = new();

    public static void SetupCharts()
    {
        /*
                                   ^
          Inops  Illustra Capax    1  Magis
          Mors   Salt     Vitae    0 [Grace(G)]
          Aegero Turpis   Phasmus -1  Daedrum
        < -1      0           1  > V
               [Morality(M)]                  
        */
                        // AlignmentChart.Add(new Anymae(Atoms.Example, M, G));
                             AlignmentChart.Add(new Anymae(Atoms.Capax, 1, 1));
        AlignmentChart.Add(new Anymae(Brimstone.API.VanillaAtoms.vitae, 1, 0));
                           AlignmentChart.Add(new Anymae(Atoms.Phasmus, 1,-1));
                          AlignmentChart.Add(new Anymae(Atoms.Illustra, 0, 1));
         AlignmentChart.Add(new Anymae(Brimstone.API.VanillaAtoms.salt, 0, 0));
                            AlignmentChart.Add(new Anymae(Atoms.Turpis, 0,-1));
                            AlignmentChart.Add(new Anymae(Atoms.Inops, -1, 1));
        AlignmentChart.Add(new Anymae(Brimstone.API.VanillaAtoms.mors, -1, 0));
                           AlignmentChart.Add(new Anymae(Atoms.Aegero, -1,-1));

        // Cardinal <-> Heavenly
        CardinalChart.Add(new CardinalPair(Brimstone.API.VanillaAtoms.fire, Atoms.Void));
        CardinalChart.Add(new CardinalPair(Brimstone.API.VanillaAtoms.earth, Atoms.Body));
        CardinalChart.Add(new CardinalPair(Brimstone.API.VanillaAtoms.water, Atoms.Mind));
        CardinalChart.Add(new CardinalPair(Brimstone.API.VanillaAtoms.air, Atoms.Soul));

    }

    public static bool AnymaeFromAttributes(int morality, int grace, out AtomType anymae)
    {
        anymae = default;

        foreach(var entry in AlignmentChart)
        {
            if (entry.Morality == morality && entry.Grace == grace)
            {
                anymae = entry.Alignment;
                return true;
            }

        }
        return false;
    }

    public static bool AttributesFromAnymae(AtomType anymae, out int morality, out int grace)
    {
        morality = 0;
        grace = 0;

        foreach (var entry in AlignmentChart)
        {
            if (entry.Alignment == anymae)
            {
                morality = entry.Morality;
                grace = entry.Grace;
                return true;
            }

        }
        return false;
    }

    public static bool SwapCardinalPairing(AtomType cardinal, out AtomType cardinalSwapped, out bool isHeavenly)
    {
        cardinalSwapped = default;
        isHeavenly = false;
        foreach (var pairing in CardinalChart)
        {
            if (pairing.Earthly == cardinal)
            {
                cardinalSwapped = pairing.Heavenly;
                return true;
            }
            if (pairing.Heavenly == cardinal)
            {
                cardinalSwapped = pairing.Earthly;
                isHeavenly = true;
                return true;
            }
        }
        return false;
    }
}
