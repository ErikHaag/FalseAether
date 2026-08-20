// #define tweaker
using Brimstone;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.Utils;
using Quintessential;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartType = class_139;

namespace FalseAether;

public static class Glyphs
{

#if tweaker
    private static ValueTweaker tweaker;
#endif
    public static void AddHooks()
    {
        // If you should get any mail with the subject "STINKY CHEESE", delete it immediately.

        Quintessential.Logger.Log(MainClass.LoggerPrefix + "Hooking");
#if tweaker
        tweaker = new ValueTweaker();
        IL.SolutionEditorBase.method_1984 += ValueTweakerPhage;
#endif


    }


    public static void RemoveHooks()
    {
        Quintessential.Logger.Log(MainClass.LoggerPrefix + "Unhooking");



#if tweaker
        IL.SolutionEditorBase.method_1984 -= ValueTweakerPhage;
#endif

    }

#if tweaker
    private static void ValueTweakerPhage(ILContext context)
    {
        ILCursor gremlin = new(context);

        if (!gremlin.TryGotoNext(MoveType.After,
            instr => instr.MatchLdloc(4),
            instr => instr.MatchCallvirt("SolutionEditorBase", "method_1993"),
            instr => instr.MatchLdloc(9)))
        {
            throw new Exception("Could not find part draw loop");
        }

        if (!gremlin.TryGotoNext(MoveType.After,
            instr => instr.OpCode == OpCodes.Blt_S,
            instr => instr.MatchLdloc(3),
            instr => instr.MatchStloc(26)))
        {
            throw new Exception("Could not find end of loop");
        }
        gremlin.EmitDelegate(() =>
        {
            tweaker.Update();
            tweaker.Display(new(500, 500));
        });

    }
#endif



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

    public static PartType Curing;
    public static readonly HexIndex CuringBowl = new HexIndex(0, 0);
    public static readonly HexIndex CuringHole1 = new HexIndex(0, -1);
    public static readonly HexIndex CuringHole2 = new HexIndex(1, -1);

    public static PartType Sympathy;
    public static readonly HexIndex SympathyBowl = new HexIndex(0, 0);
    public static readonly HexIndex SympathyHole1 = new HexIndex(1, 0);
    public static readonly HexIndex SympathyHole2 = new HexIndex(1, -1);
    public static readonly HexIndex SympathyHole3 = new HexIndex(2, -1);

    public static PartType Olympus;
    public static readonly HexIndex OlympusOut = new HexIndex(0, 0);
    public static readonly HexIndex OlympusIn1 = new HexIndex(0, -1);
    public static readonly HexIndex OlympusIn2 = new HexIndex(1, -1);
    public static readonly HexIndex OlympusIn3 = new HexIndex(0, -2);
    public static readonly HexIndex OlympusIn4 = new HexIndex(2, -2);

    public static PartType Reduction;
    public static readonly HexIndex ReductionOut1 = new HexIndex(0, 1);
    public static readonly HexIndex ReductionOut2 = new HexIndex(1, 1);
    public static readonly HexIndex ReductionIn = new HexIndex(0, 0);
    public static readonly HexIndex ReductionOut3 = new HexIndex(1, -1);
    public static readonly HexIndex ReductionOut4 = new HexIndex(2, -1);

    public static PartType Empowerment;
    public static readonly HexIndex EmpowermentAnymaeBowl = new HexIndex(-1, 0);
    public static readonly HexIndex EmpowermentPowerBowl = new HexIndex(1, 0);

    public static PartType Enchantment;
    public static readonly HexIndex EnchantmentInCard = new HexIndex(-1, 0);
    public static readonly HexIndex EnchantmentCardHost = new HexIndex(0, 0);
    public static readonly HexIndex EnchantmentHeavOut = new HexIndex(1, 0);

    public static void LoadGlyphs()
    {
        /*
         * Note: 
         * method_528 = Rotating with light rendering
         * method_529 = NOT rotating with light rendering
         */
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
            customPermission: MainClass.InquisitionPermission
            );
        QApi.AddPartTypeToPanel(Inquisition, false);
        QApi.AddPartType(Inquisition, static (part, pos, editor, renderer) =>
        {
            Vector2 pivot = new Vector2(41f, 48f);
            renderer.method_523(class_238.field_1989.field_90.field_255.field_288, new Vector2(-1f, -1f), pivot, 0);
            renderer.method_529(Textures.Inquisition.MagisBowl, InquisitionMagisBowl, Vector2.Zero);
            renderer.method_529(Textures.Inquisition.DaedrumBowl, InquisitionDaedrumBowl, Vector2.Zero);
        });

        Curing = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Curing",
            name: "Glyph of Curing",
            description: "The glyph of curing sacrifices a pair of potash to reduce any non-neutral anymae to salt.",
            cost: 10,
            glow: Textures.Select.CuringGlow,
            stroke: Textures.Select.CuringStroke,
            icon: Textures.Icons.Curing,
            hoveredIcon: Textures.Icons.CuringHovered,
            usedHexes: new HexIndex[] { CuringBowl, CuringHole1, CuringHole2 },
            customPermission: MainClass.CuringPermission
            );
        QApi.AddPartTypeToPanel(Curing, false);
        QApi.AddPartType(Curing, static (part, pos, editor, renderer) =>
        {
            Vector2 pivot = new Vector2(82, 119);
            renderer.method_523(Textures.Curing.Base, new Vector2(-1, -1), pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicBowl, CuringBowl, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.PolarEngraving, CuringBowl, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicHole, CuringHole1, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.PotashGlow, CuringHole1, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicHole, CuringHole2, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.PotashGlow, CuringHole2, Vector2.Zero);
            // renderer.method_529(Textures.Inquisition.MagisBowl, InquisitionMagisBowl, Vector2.Zero);
            // renderer.method_529(Textures.Inquisition.DaedrumBowl, InquisitionDaedrumBowl, Vector2.Zero);
        });

        Sympathy = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Sympathy",
            name: "Glyph of Sympathy",
            description: "The glyph of sympathy sacrifices three salt to reverse any non-neutral anymae's morality without affecting their grace.",
            cost: 50,
            glow: Textures.Select.SympathyGlow,
            stroke: Textures.Select.SympathyStroke,
            icon: Textures.Icons.Sympathy,
            hoveredIcon: Textures.Icons.SympathyHovered,
            usedHexes: new HexIndex[] { SympathyBowl, SympathyHole1, SympathyHole2, SympathyHole3 },
            customPermission: MainClass.SympathyPermission
            );
        QApi.AddPartTypeToPanel(Sympathy, false);
        QApi.AddPartType(Sympathy, static (part, pos, editor, renderer) =>
        {
            Vector2 pivot = new Vector2(164, 119);
            renderer.method_523(Textures.Sympathy.Base, new Vector2(-1, -1), pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicBowl, SympathyBowl, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.PolarEngraving, SympathyBowl, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicHole, SympathyHole1, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.SaltGlow, SympathyHole1, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicHole, SympathyHole2, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.SaltGlow, SympathyHole2, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicHole, SympathyHole3, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.SaltGlow, SympathyHole3, Vector2.Zero);
            // renderer.method_529(Textures.Inquisition.MagisBowl, InquisitionMagisBowl, Vector2.Zero);
            // renderer.method_529(Textures.Inquisition.DaedrumBowl, InquisitionDaedrumBowl, Vector2.Zero);
        });





        Olympus = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Olympus",
            name: "Glyph of Olympus",
            description: "The glyph of olympus assembles the four heavenly cardinals into erepiessence.",
            cost: 20,
            glow: Textures.Select.EuniGlow,
            stroke: Textures.Select.EuniStroke,
            icon: Textures.Icons.Olympus,
            hoveredIcon: Textures.Icons.OlympusHovered,
            usedHexes: new HexIndex[] { OlympusOut, OlympusIn1, OlympusIn2, OlympusIn3, OlympusIn4 },
            customPermission: MainClass.OlympusPermission
            );
        QApi.AddPartTypeToPanel(Olympus, false);
        QApi.AddPartType(Olympus, static (part, pos, editor, renderer) =>
        {
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out var pss, out var partDataWrapper, out var time);
            Vector2 pivot = new Vector2(123, 190);
            Vector2 offset = new(-1, -1);
            renderer.method_523(Textures.Olympus.Base, offset, pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicHole, OlympusIn1, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Body, OlympusIn1, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Mind, OlympusIn1, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Soul, OlympusIn1, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Void, OlympusIn1, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.DividerGlow, OlympusIn1, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicHole, OlympusIn2, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Mind, OlympusIn2, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Body, OlympusIn2, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Soul, OlympusIn2, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Void, OlympusIn2, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.DividerGlow, OlympusIn2, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicHole, OlympusIn3, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Mind, OlympusIn3, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Soul, OlympusIn3, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Body, OlympusIn3, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Void, OlympusIn3, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.DividerGlow, OlympusIn3, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicHole, OlympusIn4, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Mind, OlympusIn4, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Body, OlympusIn4, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Soul, OlympusIn4, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Void, OlympusIn4, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.DividerGlow, OlympusIn4, Vector2.Zero);
            Brimstone.API.DrawIris(renderer, partDataWrapper, OlympusOut, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);

            // renderer.method_529(Textures.Inquisition.DaedrumBowl, InquisitionDaedrumBowl, Vector2.Zero);
        });
        Reduction = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Reduction",
            name: "Glyph of Reduction",
            description: "The glyph of reduction reduces erepiessence into the four heavenly cardinals.",
            cost: 20,
            glow: Textures.Select.EdispGlow,
            stroke: Textures.Select.EdispStroke,
            icon: Textures.Icons.Reduction,
            hoveredIcon: Textures.Icons.ReductionHovered,
            usedHexes: new HexIndex[] { ReductionOut1, ReductionOut2, ReductionIn, ReductionOut3, ReductionOut4 },
            customPermission: MainClass.ReductionPermission
            );
        QApi.AddPartTypeToPanel(Reduction, false);
        QApi.AddPartType(Reduction, static (part, pos, editor, renderer) =>
        {
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out var pss, out var partDataWrapper, out var time);
            Vector2 pivot = new Vector2(164, 119);
            Vector2 offset = new(-1, -1);
            renderer.method_523(Textures.Reduction.Base, offset, pivot, 0);
            Brimstone.API.DrawIris(renderer, partDataWrapper, ReductionOut4, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[3]) : struct_18.field_1431);
            renderer.method_529(Textures.Reduction.VoidGlow, ReductionOut4, Vector2.Zero);
            Brimstone.API.DrawIris(renderer, partDataWrapper, ReductionOut3, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[2]) : struct_18.field_1431);
            renderer.method_529(Textures.Reduction.SoulGlow, ReductionOut3, Vector2.Zero);
            Brimstone.API.DrawIris(renderer, partDataWrapper, ReductionOut2, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[1]) : struct_18.field_1431);
            renderer.method_529(Textures.Reduction.SoulGlow, ReductionOut2, Vector2.Zero);
            Brimstone.API.DrawIris(renderer, partDataWrapper, ReductionOut1, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);
            renderer.method_529(Textures.Reduction.BodyGlow, ReductionOut1, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicHole, ReductionIn, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.ErepiGlow, ReductionIn, Vector2.Zero);
        });





        Polarization = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Polarization",
            name: "Glyph of Polarization",
            description: "The glyph of polarization takes a pair of illustra or turpis anymae, and influences them to the edges of morality.",
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
            renderer.method_529(Textures.Polarization.PolarizationMorsTint, PolarizationImmoralBowl, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicBowl, PolarizationMoralBowl, Vector2.Zero);
            renderer.method_529(Textures.Polarization.PolarizationEngraving, PolarizationMoralBowl, Vector2.Zero);
            renderer.method_529(Textures.Polarization.PolarizationVitaeTint, PolarizationMoralBowl, Vector2.Zero);
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
            renderer.method_523(Textures.Absolution.Base, new Vector2(-1f, -1f), pivot, 0);
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

        Enchantment = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Enchantment",
            name: "Glyph of Enchantment",
            description: "The glyph of enchantment uses two matching earthly cardinals or salt to produce one corresponding heavenly cardinal or two potash.",
            cost: 20,
            glow: Textures.Select.LineGlow,
            stroke: Textures.Select.LineStroke,
            icon: Textures.Icons.Enchantment,
            hoveredIcon: Textures.Icons.EnchantmentHovered,
            usedHexes: new HexIndex[] { EnchantmentInCard, EnchantmentCardHost, EnchantmentHeavOut },
            customPermission: MainClass.EnchantmentPermission
            );
        QApi.AddPartTypeToPanel(Enchantment, false);
        QApi.AddPartType(Enchantment, static (part, pos, editor, renderer) =>
        {
            Vector2 pivot = new Vector2(123f, 48f);
            renderer.method_523(Textures.Enchantment.Base, new Vector2(0f, -1f), pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicHole, EnchantmentInCard, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.CardinalsGlow, EnchantmentInCard, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicBowl, EnchantmentCardHost, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.CardinalsEngraved, EnchantmentCardHost, Vector2.Zero);
            renderer.method_528(Textures.Enchantment.CrazyIris, EnchantmentHeavOut, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Mind, EnchantmentHeavOut, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Body, EnchantmentHeavOut, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Soul, EnchantmentHeavOut, Vector2.Zero);
            renderer.method_529(Textures.Olympus.Void, EnchantmentHeavOut, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.DividerEngraving, EnchantmentHeavOut, Vector2.Zero);
        });

        /*
         * 
         * Hex Method names:
         * (Bowl && Hole) == method_99
         * Iris == method_1085
         * WAS THAT THE GLYPH OF 85?!!??!
         * 
         * 
         * Detect if help or part of mol:
         * 
         * 
         */
        QApi.RunDuringCycle(static (sim, part, pss, first) =>
        {
            SolutionEditorBase seb = sim.field_3818;
            PartType type = part.method_1159();
            AtomType Salt = Brimstone.API.VanillaAtoms.salt;
            if (type == Inquisition)
            {
                if (!(sim.FindAtomRelative(part, InquisitionMagisBowl).method_99(out AtomReference MagisSubject) && sim.FindAtomRelative(part, InquisitionDaedrumBowl).method_99(out AtomReference DaedrumSubject)))
                {
                    return;
                }
                if (!(MagisSubject.field_2280 == Brimstone.API.VanillaAtoms.salt && DaedrumSubject.field_2280 == Brimstone.API.VanillaAtoms.salt))
                {
                    return;
                }
                MagisSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        MagisSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
                DaedrumSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        DaedrumSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
                Brimstone.API.ChangeAtom(MagisSubject, Atoms.Magis);
                Brimstone.API.ChangeAtom(DaedrumSubject, Atoms.Daedrum);

                Brimstone.API.PlaySound(sim, Sounds.Inquisition);
            }

            else if (type == Curing)
            {

                if (!(sim.FindAtomRelative(part, CuringBowl).method_99(out AtomReference TBCured) && sim.FindAtomRelative(part, CuringHole1).method_99(out AtomReference Sac1) && sim.FindAtomRelative(part, CuringHole2).method_99(out AtomReference Sac2)))
                {
                    return;
                }
                if (Sac1.field_2281 || Sac1.field_2282)
                {
                    return;
                }
                if (Sac2.field_2281 || Sac2.field_2282)
                {
                    return;
                }
                if (!(Sac1.field_2280 == Sac2.field_2280) || (!(Sac1.field_2280 == Atoms.Celest)))
                {
                    return;
                }
                if (!LookupTable.AttributesFromAnymae(TBCured.field_2280, out int morality, out int grace))
                {
                    return;
                }
                if (morality == 0 && grace == 0)
                {
                    return;
                }
                Brimstone.API.RemoveAtom(Sac1);
                Brimstone.API.RemoveAtom(Sac2);
                Brimstone.API.DrawFallingAtom(seb, Sac1);
                Brimstone.API.DrawFallingAtom(seb, Sac2);

                Brimstone.API.ChangeAtom(TBCured, Brimstone.API.VanillaAtoms.salt);
                Brimstone.API.PlaySound(sim, Sounds.Curing);

                TBCured.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        TBCured.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );

            }
            else if (type == Sympathy)
            {


                if (!(sim.FindAtomRelative(part, SympathyBowl).method_99(out AtomReference SympSubject) && sim.FindAtomRelative(part, SympathyHole1).method_99(out AtomReference Sac1) && sim.FindAtomRelative(part, SympathyHole2).method_99(out AtomReference Sac2) && sim.FindAtomRelative(part, SympathyHole3).method_99(out AtomReference Sac3)))
                {
                    return;
                }
                if (Sac1.field_2281 || Sac1.field_2282)
                {
                    return;
                }
                if (Sac2.field_2281 || Sac2.field_2282)
                {
                    return;
                }
                if (Sac3.field_2281 || Sac3.field_2282)
                {
                    return;
                }
                if (!(Sac1.field_2280 == Sac2.field_2280) && !(Sac1.field_2280 == Sac3.field_2280) && !(Sac1.field_2280 == Brimstone.API.VanillaAtoms.salt))
                {
                    return;
                }
                if (!LookupTable.AttributesFromAnymae(SympSubject.field_2280, out int morality, out int grace))
                {
                    return;
                }
                if (morality == 0)
                {
                    return;
                }
                Brimstone.API.RemoveAtom(Sac1);
                Brimstone.API.RemoveAtom(Sac2);
                Brimstone.API.RemoveAtom(Sac3);
                Brimstone.API.DrawFallingAtom(seb, Sac1);
                Brimstone.API.DrawFallingAtom(seb, Sac2);
                Brimstone.API.DrawFallingAtom(seb, Sac3);

                LookupTable.AnymaeFromAttributes(morality * -1, grace, out AtomType NewMorality);

                Brimstone.API.ChangeAtom(SympSubject, NewMorality);
                Brimstone.API.PlaySound(sim, Sounds.Sympathy);

                SympSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        SympSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );


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

                ImmoralSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        ImmoralSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
                MoralSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        MoralSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
            }

            else if (type == Enchantment)
            {


                bool madePotash = false;
                if ((sim.FindAtomRelative(part, EnchantmentHeavOut).method_1085()))
                {
                    return;
                }
                if (!(sim.FindAtomRelative(part, EnchantmentInCard).method_99(out AtomReference Intake) && sim.FindAtomRelative(part, EnchantmentCardHost).method_99(out AtomReference Host)))
                {
                    return;
                }
                if (Intake.field_2281 || Intake.field_2282)
                {
                    return;
                }
                if (!(Intake.field_2280 == Host.field_2280))
                {
                    return;
                }

                AtomType SwappedCardinal = default;

                if (Intake.field_2280 == Salt)
                {
                    SwappedCardinal = Atoms.Celest;
                    madePotash = true;
                }

                else if ((!LookupTable.SwapCardinalPairing(Intake.field_2280, out SwappedCardinal, out bool isHeavenly)) || isHeavenly)
                {
                    return;
                }

                Brimstone.API.RemoveAtom(Intake);
                Brimstone.API.DrawFallingAtom(seb, Intake);

                pss.field_2743 = true;
                Brimstone.API.AddAtom(sim, part, EnchantmentHeavOut, SwappedCardinal);
                Host.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        Host.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );


                seb.field_3936.Add(new class_228
                        (
                            seb,
                            (enum_7)1,
                            Brimstone.API.HexIndexToVector2(part.method_1184(EnchantmentHeavOut)) + new Vector2(80, 0),
                            class_238.field_1989.field_90.field_240,
                            30,
                            Vector2.Zero,
                            0
                        )
                    );
                if (madePotash)
                {
                    foreach (var offset in new HexIndex[] { EnchantmentHeavOut, EnchantmentCardHost })
                    {
                        seb.field_3935.Add(new class_228
                            (
                                seb,
                                (enum_7)1,
                                Brimstone.API.HexIndexToVector2(part.method_1184(offset)) + new Vector2(147, 47),
                                class_238.field_1989.field_90.field_242,
                                30,
                                Vector2.Zero,
                                0
                            )
                        );
                    }
                }




                Brimstone.API.ChangeAtom(Host, !madePotash ? Salt : Atoms.Celest);
                Brimstone.API.PlaySound(sim, !madePotash ? Sounds.Enchantment : Sounds.EnchantmentPotash);






            }

            else if (type == Reduction)
            {
                if (first)
                {
                    if ((sim.FindAtomRelative(part, ReductionOut1).method_1085()) || (sim.FindAtomRelative(part, ReductionOut2).method_1085()) || (sim.FindAtomRelative(part, ReductionOut3).method_1085()) || (sim.FindAtomRelative(part, ReductionOut4).method_1085()))
                    {
                        return;
                    }
                    if (!(sim.FindAtomRelative(part, ReductionIn).method_99(out AtomReference Intake)))
                    {
                        return;
                    }
                    if (Intake.field_2281 || Intake.field_2282)
                    {
                        return;
                    }
                    if (Intake.field_2280 == Atoms.Erepiessence)
                    {
                        Brimstone.API.RemoveAtom(Intake);
                        Brimstone.API.DrawFallingAtom(seb, Intake);
                        Brimstone.API.PlaySound(sim, Sounds.Reduction);
                        pss.field_2743 = true;
                        pss.field_2744 = new AtomType[4] { Atoms.Body, Atoms.Mind, Atoms.Soul, Atoms.Void };
                    }
                    else
                    {
                        return;
                    }
                }
                else if (pss.field_2743)
                {

                    Brimstone.API.AddAtom(sim, part, ReductionOut1, pss.field_2744[0]);
                    Brimstone.API.AddAtom(sim, part, ReductionOut2, pss.field_2744[1]);
                    Brimstone.API.AddAtom(sim, part, ReductionOut3, pss.field_2744[2]);
                    Brimstone.API.AddAtom(sim, part, ReductionOut4, pss.field_2744[3]);
                }
            }

            else if (type == Olympus)
            {
                if (first)
                {
                    if ((sim.FindAtomRelative(part, OlympusOut).method_1085()))
                    {
                        return;
                    }
                    if (!(sim.FindAtomRelative(part, OlympusIn1).method_99(out AtomReference In1) && sim.FindAtomRelative(part, OlympusIn2).method_99(out AtomReference In2) && sim.FindAtomRelative(part, OlympusIn3).method_99(out AtomReference In3) && sim.FindAtomRelative(part, OlympusIn4).method_99(out AtomReference In4)))
                    {
                        return;
                    }

                    int specialAtomNumber = 1; // we use this to tell if we have all 4 unique heavenly cardinals

                    AtomReference[] holeAtoms = new AtomReference[] { In1, In2, In3, In4 };
                    foreach (AtomReference HoleAtom in holeAtoms)
                    {
                        if (HoleAtom.field_2281 || HoleAtom.field_2282)
                        {
                            return;
                        }

                        if (HoleAtom.field_2280 == Atoms.Body)
                        {
                            specialAtomNumber *= 2;

                        }
                        else if (HoleAtom.field_2280 == Atoms.Soul)
                        {
                            specialAtomNumber *= 3;

                        }
                        else if (HoleAtom.field_2280 == Atoms.Mind)
                        {
                            specialAtomNumber *= 5;

                        }
                        else if (HoleAtom.field_2280 == Atoms.Void)
                        {
                            specialAtomNumber *= 7;

                        }
                        else
                        {
                            return;
                        }
                    }

                    if (specialAtomNumber != 210)
                    {
                        return;
                    }


                    foreach (AtomReference holeAtom in holeAtoms)
                    {
                        Brimstone.API.RemoveAtom(holeAtom);
                        Brimstone.API.DrawFallingAtom(seb, holeAtom);
                    }
                    Brimstone.API.PlaySound(sim, Sounds.Olympus);
                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[] { Atoms.Erepiessence };


                }

                else if (pss.field_2743)
                {

                    Brimstone.API.AddAtom(sim, part, OlympusOut, pss.field_2744[0]);
                }
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

                ImmoralSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        ImmoralSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
                MoralSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        MoralSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
            }
            else if (type == Empowerment)
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

                if (!LookupTable.AttributesFromAnymae(AnymaeSubject.field_2280, out int morality, out int grace) || !LookupTable.AnymaeFromAttributes(morality, grace + deltaGrace, out AtomType NewAnymae))
                {
                    return;
                }

                Brimstone.API.ChangeAtom(PowerSubject, Brimstone.API.VanillaAtoms.salt);
                Brimstone.API.ChangeAtom(AnymaeSubject, NewAnymae);

                Brimstone.API.PlaySound(sim, Sounds.Empowerment);

                AnymaeSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        AnymaeSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
                PowerSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        PowerSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
            }
        });
    }

}
