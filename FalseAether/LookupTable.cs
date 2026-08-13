using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalseAether
{
    internal static class LookupTable
    {
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
        
        internal static List<Anymae> AlignmentChart = new List<Anymae>();
        public static void setupAlignmentChart()
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
    }
}
