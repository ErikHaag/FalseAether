
using Quintessential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartType = class_139;

namespace FalseAether;

public static class Glyphs
{
    public static PartType Inquisition;
    public static readonly HexIndex InquisitionMagisBowl = new HexIndex(0, 0);
    public static readonly HexIndex InquisitionDaedrumBowl = new HexIndex(1, 0);

    public static PartType Polarization;
    public static readonly HexIndex PolarizationImmoralBowl = new HexIndex(0, 0);
    public static readonly HexIndex PolarizationMoralBowl = new HexIndex(1, 0);

    public static PartType TrueSight;


    public static PartType Absolution;
    public static readonly HexIndex AbsolutionImmoralBowl = new HexIndex(0, 0);
    public static readonly HexIndex AbsolutionMoralBowl = new HexIndex(1, 0);

    public static PartType Empowerment;
    public static readonly HexIndex EmpowermentAnymaeBowl = new HexIndex(-1, 0);
    public static readonly HexIndex EmpowermentPowerBowl = new HexIndex(1, 0);

    public static void LoadGlyphs() {
        Inquisition = Brimstone.API.CreateSimpleGlyph(
            
            ID: "FalseAether-Inquisition",
            name: "Glyph of Inquisition",
            description: "The glyph of inquisition graces one salt, and makes the other fall.",
            cost: 10,
            glow: class_238.field_1989.field_97.field_374,
            stroke: class_238.field_1989.field_97.field_375,
            icon: Textures.Icons.Inquisition,
            hoveredIcon: Textures.Icons.InquisitionHovered,
            usedHexes: new HexIndex[] { InquisitionMagisBowl, InquisitionDaedrumBowl },
            customPermission:MainClass.InquisitionPermission    
            );
        QApi.AddPartTypeToPanel(Inquisition, false);
        QApi.AddPartType(Inquisition, static (part, pos, editor, renderer) =>
        {
            Vector2 pivot = new Vector2(41f, 48f);
            renderer.method_523(class_238.field_1989.field_90.field_255.field_288, new Vector2(-1f, -1f), pivot, 0);
            renderer.method_529(Textures.Inquisition.MagisBowl, InquisitionMagisBowl, Vector2.Zero);
            renderer.method_529(Textures.Inquisition.DaedrumBowl, InquisitionDaedrumBowl, Vector2.Zero);
        });

        Polarization = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Polarization",
            name: "Glyph of Polarization",
            description: "The glyph of polarization takes a pair of neutral anymae, and influences them to the edges of morality. (Animismus but better).",
            cost: 35,
            glow: class_238.field_1989.field_97.field_374,
            stroke: class_238.field_1989.field_97.field_375,
            icon: Textures.Icons.Polarization,
            hoveredIcon: Textures.Icons.PolarizationHovered,
            usedHexes: new HexIndex[] { PolarizationImmoralBowl, PolarizationMoralBowl },
            customPermission: MainClass.PolarizationPermission
            );
        QApi.AddPartTypeToPanel(Polarization, false);
        QApi.AddPartType(Polarization, static (part, pos, editor, renderer) =>
        {
            Vector2 pivot = new Vector2(41f, 48f);
            renderer.method_523(Textures.Polarization.PolarizationBase, new Vector2(-1f, -1f), pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicBowl, PolarizationImmoralBowl, Vector2.Zero);
            renderer.method_529(Textures.Polarization.PolarizationEngraving, PolarizationImmoralBowl, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicBowl, PolarizationMoralBowl, Vector2.Zero);
            renderer.method_529(Textures.Polarization.PolarizationEngraving, PolarizationMoralBowl, Vector2.Zero);
        });

        Absolution = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Absolution",
            name: "Glyph of Absolution",
            description: "The glyph of absolution takes a pair of morally displaced anymae, and resolves them of their conflict back to a neutral anymae. (Animismus but backwards).",
            cost: 45,
            glow: class_238.field_1989.field_97.field_374,
            stroke: class_238.field_1989.field_97.field_375,
            icon: Textures.Icons.Absolution,
            hoveredIcon: Textures.Icons.AbsolutionHovered,
            usedHexes: new HexIndex[] { AbsolutionImmoralBowl, AbsolutionMoralBowl },
            customPermission: MainClass.AbsolutionPermission
            );
        QApi.AddPartTypeToPanel(Absolution, false);
        QApi.AddPartType(Absolution, static (part, pos, editor, renderer) =>
        {
            Vector2 pivot = new Vector2(41f, 48f);
            renderer.method_523(class_238.field_1989.field_90.field_255.field_288, new Vector2(-1f, -1f), pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicBowl, AbsolutionImmoralBowl, Vector2.Zero);
            renderer.method_529(Textures.Absolution.Engravings, AbsolutionImmoralBowl, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicBowl, AbsolutionMoralBowl, Vector2.Zero);
            renderer.method_529(Textures.Absolution.Engravings, AbsolutionMoralBowl, Vector2.Zero);
        });


        TrueSight = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-TrueSight",
            name: "Glyph of True Sight",
            description: "When placed anywhere on the board, the glyph of true sight allows the glyph of absolution to absolve any pair of animismus, regardles of grace, as long as their moralities oppose.",
            cost: 30,
            glow: Textures.Select.SingleGlow,
            stroke: Textures.Select.SingleStroke,
            icon: Textures.Icons.TrueSight,
            hoveredIcon: Textures.Icons.TrueSightHovered,
            usedHexes: new HexIndex[] { new(0, 0) },
            customPermission: MainClass.TrueSightPermission
            );
        QApi.AddPartTypeToPanel(TrueSight, false);
        QApi.AddPartType(TrueSight, static (part, pos, editor, renderer) =>
        {
            Vector2 centre = new Vector2(41f, 49f);
            renderer.method_523(Textures.TrueSight.TrueSightBase, new Vector2(-1, -1), centre, 0f);
            renderer.method_529(Textures.TrueSight.TrueSightEye, new(0, 0), Vector2.Zero);

        });


        Empowerment = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Empowerment",
            name: "Glyph of Empowerment",
            description: "The glyph of empowerment imbues grace onto any of the nine anymae through Magis or Daedrum, which are in turn, revived to salt.",
            cost: 20,
            glow: Textures.Select.LineGlow,
            stroke: Textures.Select.LineStroke,
            icon: Textures.Icons.Empowerment,
            hoveredIcon: Textures.Icons.EmpowermentHovered,
            usedHexes: new HexIndex[] { EmpowermentAnymaeBowl, new(0, 0), EmpowermentPowerBowl },
            customPermission: MainClass.EmpowermentPermission
            );
        QApi.AddPartTypeToPanel(Empowerment, false);
        QApi.AddPartType(Empowerment, static (part, pos, editor, renderer) =>
        {
            Vector2 pivot = new Vector2(123f, 48f);
            renderer.method_523(Textures.Empowerment.Base, new Vector2(0f, -1f), pivot, 0);
            renderer.method_528(Textures.Empowerment.AnymaeBowl, EmpowermentAnymaeBowl, Vector2.Zero);
            renderer.method_529(Textures.Empowerment.SaltSymbol, EmpowermentAnymaeBowl, Vector2.Zero);
            renderer.method_528(Textures.Empowerment.PowerBowl, EmpowermentPowerBowl, Vector2.Zero); 
            renderer.method_529(Textures.Empowerment.PowerSymbol, EmpowermentPowerBowl, Vector2.Zero); 
        });

        QApi.RunDuringCycle(static (sim, part, pss, first) =>
        {
            PartType type = part.method_1159();
            if(type == Inquisition)
            {
                if(!(sim.FindAtomRelative(part, InquisitionMagisBowl).method_99(out AtomReference MagisSubject) && sim.FindAtomRelative(part, InquisitionDaedrumBowl).method_99(out AtomReference DaedrumSubject)))
                {
                    return;
                }
                if(!(MagisSubject.field_2280 == Brimstone.API.VanillaAtoms.salt && DaedrumSubject.field_2280 == Brimstone.API.VanillaAtoms.salt))
                {
                    return;
                }
                Brimstone.API.ChangeAtom(MagisSubject, Atoms.Magis);
                Brimstone.API.ChangeAtom(DaedrumSubject, Atoms.Daedrum);

                Brimstone.API.PlaySound(sim, Sounds.Inquisition);
            }

            else if (type == Polarization)
            {
                if (!(sim.FindAtomRelative(part, PolarizationImmoralBowl).method_99(out AtomReference ImmoralSubject) && sim.FindAtomRelative(part, PolarizationMoralBowl).method_99(out AtomReference MoralSubject)))
                {
                    return;
                }
                if (!(ImmoralSubject.field_2280 == MoralSubject.field_2280))
                {
                    return;
                }
                if (!LookupTable.AttributesFromAnymae(ImmoralSubject.field_2280, out int morality, out int grace))
                {
                    return;
                }
                if (!(ImmoralSubject.field_2280 == Atoms.Illustra || ImmoralSubject.field_2280 == Atoms.Turpis))
                {
                    return;
                }
                LookupTable.AnymaeFromAttributes(morality - 1, grace, out AtomType NewImmoral);
                LookupTable.AnymaeFromAttributes(morality + 1, grace, out AtomType NewMoral);

                Brimstone.API.PlaySound(sim, Sounds.Polarization);

                Brimstone.API.ChangeAtom(MoralSubject, NewMoral);
                Brimstone.API.ChangeAtom(ImmoralSubject, NewImmoral);
            }
            else if (type == Absolution)
            {
                if (!(sim.FindAtomRelative(part, AbsolutionImmoralBowl).method_99(out AtomReference ImmoralSubject) && sim.FindAtomRelative(part, AbsolutionMoralBowl).method_99(out AtomReference MoralSubject)))
                {
                    return;
                }
                if (!LookupTable.AttributesFromAnymae(MoralSubject.field_2280, out int morality, out int grace) || !LookupTable.AttributesFromAnymae(ImmoralSubject.field_2280, out int morality2, out int grace2))
                {
                    return;
                }

                if (!(morality + morality2 == 0) || (morality == 0)) 
                {
                    return;
                }
                bool hasTrueSight = sim.field_3818.method_502() // sim.solutioneditorbase.getsolution
                                   .field_3919 // parts
                                   .Any(x => x.method_1159() == TrueSight); // any parts are True Sight
                if (!(grace == grace2) && !hasTrueSight)
                {
                    return;
                }
            
                LookupTable.AnymaeFromAttributes(0, grace, out AtomType ImmoralAbsolved);
                LookupTable.AnymaeFromAttributes(0, grace, out AtomType MoralAbsolved);

                Brimstone.API.PlaySound(sim, Sounds.Absolution);

                Brimstone.API.ChangeAtom(MoralSubject, MoralAbsolved);
                Brimstone.API.ChangeAtom(ImmoralSubject, ImmoralAbsolved);
            }
            else if(type == Empowerment) 
            {
                if (!(sim.FindAtomRelative(part, EmpowermentAnymaeBowl).method_99(out AtomReference AnymaeSubject) && sim.FindAtomRelative(part, EmpowermentPowerBowl).method_99(out AtomReference PowerSubject)))
                {
                    return;
                }
                int deltaGrace = 0;

                if (PowerSubject.field_2280 == Atoms.Magis)
                {
                    deltaGrace = 1;
                }
                else if (PowerSubject.field_2280 == Atoms.Daedrum)
                {
                    deltaGrace = -1;
                }
                else
                {
                    return;
                }

                if(!LookupTable.AttributesFromAnymae(AnymaeSubject.field_2280, out int morality, out int grace) || !LookupTable.AnymaeFromAttributes(morality, grace + deltaGrace, out AtomType NewAnymae)) 
                {
                    return;
                }

                Brimstone.API.ChangeAtom(PowerSubject, Brimstone.API.VanillaAtoms.salt);
                Brimstone.API.ChangeAtom(AnymaeSubject, NewAnymae);

                Brimstone.API.PlaySound(sim, Sounds.Empowerment);
            }
        });
    }

}
