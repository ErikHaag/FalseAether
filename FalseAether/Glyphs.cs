//#define tweaker
using Quintessential;
using System.Collections.Generic;
using System.Linq;
using PartType = class_139;

namespace FalseAether;

public static class Glyphs
{
    internal static ValueTweaker tweaker;
    public static void AddHooks()
    {
        // If you should get any mail with the subject "STINKY CHEESE", delete it immediately.

        Quintessential.Logger.Log(MainClass.LoggerPrefix + "Hooking");
        tweaker = new ValueTweaker(false);
        #if tweaker
        tweaker.Enabled = true;
        #endif
    }


    public static void RemoveHooks()
    {
        Quintessential.Logger.Log(MainClass.LoggerPrefix + "Unhooking");
        tweaker.Unload();
    }



    public static PartType Inquisition;
    public static readonly HexIndex InquisitionMagisBowl = new(0, 0);
    public static readonly HexIndex InquisitionDaedrumBowl = new(1, 0);

    public static PartType PortalingOut;
    public static readonly HexIndex PortalingIris = new(0, 0);

    public static PartType PortalingIn;
    public static readonly HexIndex PortalingInput = new(0, 0);

    public static PartType Polarization;
    public static readonly HexIndex PolarizationImmoralBowl = new(0, 0);
    public static readonly HexIndex PolarizationMoralBowl = new(1, 0);

    public static PartType Absolution;
    public static readonly HexIndex AbsolutionImmoralBowl = new(0, 0);
    public static readonly HexIndex AbsolutionMoralBowl = new(1, 0);


    public static PartType Empowerment;
    public static readonly HexIndex EmpowermentAnymaeBowl = new(-1, 0);
    public static readonly HexIndex EmpowermentPowerBowl = new(1, 0);

    public static PartType TrueSight;

    public static PartType Curing;
    public static readonly HexIndex CuringBowl = new(0, 0);
    public static readonly HexIndex CuringHole1 = new(0, -1);
    public static readonly HexIndex CuringHole2 = new(1, -1);

    public static PartType Sympathy;
    public static readonly HexIndex SympathyBowl = new(0, 0);
    public static readonly HexIndex SympathyHole1 = new(1, 0);
    public static readonly HexIndex SympathyHole2 = new(1, -1);
    public static readonly HexIndex SympathyHole3 = new(2, -1);

    public static PartType Reconstruction;
    public static readonly HexIndex QuintLikeBowl = new(0, 0);
    public static readonly HexIndex CelestBowl1 = new(-1, -1);
    public static readonly HexIndex CelestBowl2 = new(2, -1);
    public static readonly HexIndex ReconstructionPowerHole = new(1, -2);

    public static PartType Enchantment;
    public static readonly HexIndex EnchantmentInCard = new(-1, 0);
    public static readonly HexIndex EnchantmentCardHost = new(0, 0);
    public static readonly HexIndex EnchantmentHeavOut = new(1, 0);

    public static PartType Olympus;
    public static readonly HexIndex OlympusOut = new(0, 0);
    public static readonly HexIndex OlympusIn1 = new(0, -1);
    public static readonly HexIndex OlympusIn2 = new(1, -1);
    public static readonly HexIndex OlympusIn3 = new(0, -2);
    public static readonly HexIndex OlympusIn4 = new(2, -2);
    public static readonly HexIndex[] OlympusInputs = new HexIndex[] { OlympusIn1, OlympusIn2, OlympusIn3, OlympusIn4 };

    public static PartType Reduction;
    public static readonly HexIndex ReductionBodyOut = new(0, 1);
    public static readonly HexIndex ReductionMindOut = new(1, 1);
    public static readonly HexIndex ReductionIn = new(0, 0);
    public static readonly HexIndex ReductionSoulOut = new(1, -1);
    public static readonly HexIndex ReductionVoidOut = new(2, -1);

    public static PartType Incantation;
    public static readonly HexIndex EtherOut1 = new(-1, 0);
    public static readonly HexIndex SaltOut = new(0, 0);
    public static readonly HexIndex EtherOut2 = new(1, 0);
    public static readonly HexIndex ErepiBowl = new(1, -2);

    public static void LoadGlyphs()
    {
        /*
         * Note: 
         * method_528 = Rotating with light rendering
         * method_529 = NOT rotating with light rendering
         */

        #region Part type definitions and renderers
        #region Gracing Anymae
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
            Vector2 pivot = new(41f, 48f);
            renderer.method_523(class_238.field_1989.field_90.field_255.field_288, new Vector2(-1f, -1f), pivot, 0);
            renderer.method_529(Textures.Inquisition.MagisBowl, InquisitionMagisBowl, Vector2.Zero);
            renderer.method_529(Textures.Inquisition.DaedrumBowl, InquisitionDaedrumBowl, Vector2.Zero);
        });

        Reconstruction = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Reconstruction",
            name: "Glyph of Reconstruction",
            description: "The glyph of reconstrucion changes quintessence to erepiessence and vice versa using magis or daedrum, and must have a celest on the two side bowls.",
            cost: 35,
            glow: Textures.Select.ReconstructionGlow,
            stroke: Textures.Select.ReconstructionStroke,
            icon: Textures.Icons.Reconstruction,
            hoveredIcon: Textures.Icons.ReconstructionHovered,
            usedHexes: new HexIndex[] { QuintLikeBowl, CelestBowl1, new(0, -1), new(1, -1), CelestBowl2, ReconstructionPowerHole },
            customPermission: MainClass.ReconstructionPermission
            );
        QApi.AddPartTypeToPanel(Reconstruction, false);
        QApi.AddPartType(Reconstruction, static (part, pos, editor, renderer) =>
        {
            Vector2 pivot = new(164, 190);
            renderer.method_523(Textures.Reconstruction.Base, new Vector2(-1, -1), pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicBowl, QuintLikeBowl, Vector2.Zero);
            //renderer.method_529(Textures.Polarization.PolarizationEngraving, PolarizationImmoralBowl, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicBowl, CelestBowl1, Vector2.Zero);
            renderer.method_529(Textures.Holes.Celest, CelestBowl1, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicBowl, CelestBowl2, Vector2.Zero);
            renderer.method_529(Textures.Holes.Celest, CelestBowl2, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicHole, ReconstructionPowerHole, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.PowerGlow, ReconstructionPowerHole, Vector2.Zero);

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
            Vector2 pivot = new(41f, 48f);
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
            Vector2 pivot = new(41f, 48f);
            renderer.method_523(Textures.Absolution.Base, new Vector2(-1f, -1f), pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicBowl, AbsolutionImmoralBowl, Vector2.Zero);
            renderer.method_529(Textures.Absolution.Engravings, AbsolutionImmoralBowl, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicBowl, AbsolutionMoralBowl, Vector2.Zero);
            renderer.method_529(Textures.Absolution.Engravings, AbsolutionMoralBowl, Vector2.Zero);
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
            Vector2 pivot = new(123f, 48f);
            renderer.method_523(Textures.Empowerment.Base, new Vector2(0f, -1f), pivot, 0);
            renderer.method_528(Textures.Empowerment.AnymaeBowl, EmpowermentAnymaeBowl, Vector2.Zero);
            renderer.method_529(Textures.Empowerment.SaltSymbol, EmpowermentAnymaeBowl, Vector2.Zero);
            renderer.method_528(Textures.Empowerment.PowerBowl, EmpowermentPowerBowl, Vector2.Zero);
            renderer.method_529(Textures.Empowerment.PowerSymbol, EmpowermentPowerBowl, Vector2.Zero);
        });

        Incantation = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Incantation",
            name: "Glyph of Incantation",
            description: "The glyph of incantation discharges an erepiessence into two salt and two ether.",
            cost: 25,
            glow: Textures.Select.IncantationGlow,
            stroke: Textures.Select.IncantationStroke,
            icon: Textures.Icons.Incantation,
            hoveredIcon: Textures.Icons.IncantationHovered,
            usedHexes: new HexIndex[] { ErepiBowl, EtherOut1, EtherOut2, SaltOut, new(0, -1), new(1, -1) },
            customPermission: MainClass.IncantationPermission
            );
        QApi.AddPartTypeToPanel(Incantation, false);
        QApi.AddPartType(Incantation, static (part, pos, editor, renderer) =>
        {
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out class_236 partDataWrapper, out float time);
            Vector2 pivot = new(123, 190);
            Vector2 offset = new(-1, -1);
            renderer.method_523(Textures.Incantation.Base, offset, pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicBowl, ErepiBowl, Vector2.Zero);

            int frame = 15;
            Vector2 risingOffset = partDataWrapper.field_1984 + Brimstone.API.HexIndexToVector2(SaltOut).Rotated(partDataWrapper.field_1985);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_272, EtherOut1, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_272, SaltOut, Vector2.Zero);
            renderer.method_528(class_238.field_1989.field_90.field_228.field_272, EtherOut2, Vector2.Zero);

            renderer.method_521(class_238.field_1989.field_90.field_196, new Vector2(-23f + 82f, 24f));
            renderer.method_521(class_238.field_1989.field_90.field_196, new Vector2(-23f, 24f));
            Molecule output = null;
            bool afterIrisOpens = false;
            if (pss.field_2743)
            {
                frame = class_162.method_404((int)(class_162.method_411(1f, -1f, time) * 16), 0, 15);
                output = new();
                output.method_1105(new Atom(pss.field_2744[0]), EtherOut1.Rotated(pss.field_2726));
                output.method_1105(new Atom(pss.field_2744[1]), SaltOut);
                output.method_1105(new Atom(pss.field_2744[2]), EtherOut2.Rotated(pss.field_2726));
                output.method_1111(enum_126.Standard, EtherOut1.Rotated(pss.field_2726), SaltOut);
                output.method_1111(enum_126.Standard, SaltOut, EtherOut2.Rotated(pss.field_2726));
                afterIrisOpens = time > 0.5;
                if (!afterIrisOpens)
                {
                    Editor.method_925(output, risingOffset, new(0, 0), 0f, 1f, time, 1f, false, null);
                }
            }
            renderer.method_529(Textures.Irises.Ether[frame], EtherOut1, Vector2.Zero);
            renderer.method_529(class_238.field_1989.field_90.field_246[frame], SaltOut, Vector2.Zero);
            renderer.method_529(Textures.Irises.Ether[frame], EtherOut2, Vector2.Zero);
            renderer.method_526(Textures.Incantation.OutputAboveIris, SaltOut, Vector2.Zero, new Vector2(122f, 41f), 0);
            if (afterIrisOpens)
            {
                Editor.method_925(output, risingOffset, new(0, 0), 0f, 1f, time, 1f, false, null);
            }
        });

        PortalingIn = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-PortalingIn",
            name: "Glyph of Portaling (Inlet)",
            description: "The glyph of portaling is a multi part glyph. Any atoms dropped into an inlet lead to the outlet (if present), otherwise it does nothing.",
            cost: 5,
            glow: Textures.Select.SingleGlow,
            stroke: Textures.Select.SingleStroke,
            icon: Textures.Icons.Portaling,
            hoveredIcon: Textures.Icons.PortalingHovered,
            usedHexes: new HexIndex[] { PortalingInput },
            customPermission: MainClass.PortalingPermission
            );
        QApi.AddPartTypeToPanel(PortalingIn, false);
        QApi.AddPartType(PortalingIn, static (part, pos, editor, renderer) =>
        {
            Vector2 centre = new(41f, 49f);
            renderer.method_523(Textures.TrueSight.TrueSightBase, new Vector2(-1, -1), centre, 0f);
            renderer.method_529(Textures.TrueSight.TrueSightEye, new(0, 0), Vector2.Zero);

        });
        PortalingOut = Brimstone.API.CreateSimpleGlyph(


            ID: "FalseAether-PortalingOut",
            name: "Glyph of Portaling (Outlet)",
            description: "The glyph of portaling is a multi part glyph. Any atoms dropped into an inlet lead to the outlet (if present), otherwise it does nothing.",
            cost: 30,
            glow: Textures.Select.SingleGlow,
            stroke: Textures.Select.SingleStroke,
            icon: Textures.Icons.Portaling,
            hoveredIcon: Textures.Icons.PortalingHovered,
            usedHexes: new HexIndex[] { PortalingIris },
            customPermission: MainClass.PortalingPermission2
            );
        PortalingOut.field_1552 = true;
        QApi.AddPartTypeToPanel(PortalingOut, false);
        QApi.AddPartType(PortalingOut, static (part, pos, editor, renderer) =>
        {
            Vector2 centre = new(41f, 49f);
            renderer.method_523(Textures.TrueSight.TrueSightBase, new Vector2(-1, -1), centre, 0f);
            renderer.method_529(Textures.TrueSight.TrueSightEye, new(0, 0), Vector2.Zero);

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
            Vector2 centre = new(41f, 49f);
            renderer.method_523(Textures.TrueSight.TrueSightBase, new Vector2(-1, -1), centre, 0f);
            renderer.method_529(Textures.TrueSight.TrueSightEye, new(0, 0), Vector2.Zero);

        });

        Curing = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Curing",
            name: "Glyph of Curing",
            description: "The glyph of curing sacrifices a pair of celest to reduce any non-neutral anymae to salt.",
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
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out class_236 partDataWrapper, out float time);
            Vector2 pivot = new(82, 119);
            renderer.method_523(Textures.Curing.Base, new Vector2(-1, -1), pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicBowl, CuringBowl, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.PolarEngraving, CuringBowl, Vector2.Zero);
            foreach (HexIndex hole in new HexIndex[] { CuringHole1, CuringHole2 })
            {
                renderer.method_528(Textures.SharedTextures.BasicHole, hole, Vector2.Zero);
                class_135.method_272(Textures.Holes.Celest, (Brimstone.API.HexIndexToVector2(hole).Rotated(partDataWrapper.field_1985) + partDataWrapper.field_1984 - (Textures.Holes.Celest.field_2056.ToVector2() / 2)).Rounded());
            }
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
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out class_236 partDataWrapper, out float time);
            Vector2 pivot = new(164, 119);
            renderer.method_523(Textures.Sympathy.Base, new Vector2(-1, -1), pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicBowl, SympathyBowl, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.PolarEngraving, SympathyBowl, Vector2.Zero);
            foreach (HexIndex hole in new HexIndex[] { SympathyHole1, SympathyHole2, SympathyHole3 })
            {
                renderer.method_528(Textures.SharedTextures.BasicHole, hole, Vector2.Zero);
                class_135.method_272(Textures.Holes.Salt, (Brimstone.API.HexIndexToVector2(hole).Rotated(partDataWrapper.field_1985) + partDataWrapper.field_1984 - (Textures.Holes.Salt.field_2056.ToVector2() / 2)).Rounded());
            }
        });

        #endregion
        #region Heavenlies and Earthlies

        Enchantment = Brimstone.API.CreateSimpleGlyph(

            ID: "FalseAether-Enchantment",
            name: "Glyph of Enchantment",
            description: "The glyph of enchantment uses two matching earthly cardinals or salt to produce one corresponding heavenly cardinal or two celest.",
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
            Vector2 pivot = new(123f, 48f);
            renderer.method_523(Textures.Enchantment.Base, new Vector2(0f, -1f), pivot, 0);
            renderer.method_528(Textures.SharedTextures.BasicHole, EnchantmentInCard, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.CardinalsGlow, EnchantmentInCard, Vector2.Zero);
            renderer.method_528(Textures.SharedTextures.BasicBowl, EnchantmentCardHost, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.CardinalsEngraved, EnchantmentCardHost, Vector2.Zero);
            renderer.method_528(Textures.Enchantment.CrazyIris, EnchantmentHeavOut, Vector2.Zero);

            // todo: replace this with actual engraved texture
            renderer.method_529(Textures.Olympus.MindInactive, EnchantmentHeavOut, Vector2.Zero);
            renderer.method_529(Textures.Olympus.BodyInactive, EnchantmentHeavOut, Vector2.Zero);
            renderer.method_529(Textures.Olympus.SoulInactive, EnchantmentHeavOut, Vector2.Zero);
            renderer.method_529(Textures.Olympus.VoidInactive, EnchantmentHeavOut, Vector2.Zero);
            renderer.method_529(Textures.SharedTextures.DividerEngraving, EnchantmentHeavOut, Vector2.Zero);
        });

        #endregion
        #region Erepiessence and Ether
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
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out class_236 partDataWrapper, out float time);
            Vector2 pivot = new(123, 190);
            Vector2 offset = new(-1, -1);
            renderer.method_523(Textures.Olympus.Base, offset, pivot, 0);

            // bitwise operations!
            int atomsPresent = 0;

            foreach (HexIndex h in OlympusInputs)
            {
                foreach (Molecule m in editor.method_507().method_483())
                {
                    if (m.method_1100().Count == 1 && m.method_1100().TryGetValue(part.method_1184(h), out Atom a))
                    {
                        AtomType aT = a.field_2275;
                        if (aT == Atoms.Body)
                        {
                            atomsPresent |= 0b0001;

                        }
                        else if (aT == Atoms.Mind)
                        {
                            atomsPresent |= 0b0010;
                        }
                        else if (aT == Atoms.Soul)
                        {
                            atomsPresent |= 0b0100;

                        }
                        else if (aT == Atoms.Void)
                        {
                            atomsPresent |= 0b1000;
                        }
                    }
                }
            }

            foreach (HexIndex hole in OlympusInputs)
            {
                renderer.method_528(Textures.SharedTextures.BasicHole, hole, Vector2.Zero);
                renderer.method_529(((atomsPresent & 1) == 0) ? Textures.Olympus.BodyActive : Textures.Olympus.BodyInactive, hole, Vector2.Zero);
                renderer.method_529(((atomsPresent & 2) == 0) ? Textures.Olympus.MindActive : Textures.Olympus.MindInactive, hole, Vector2.Zero);
                renderer.method_529(((atomsPresent & 4) == 0) ? Textures.Olympus.SoulActive : Textures.Olympus.SoulInactive, hole, Vector2.Zero);
                renderer.method_529(((atomsPresent & 8) == 0) ? Textures.Olympus.VoidActive : Textures.Olympus.VoidInactive, hole, Vector2.Zero);
                renderer.method_529(Textures.SharedTextures.DividerGlow, hole, Vector2.Zero);
            }
            Brimstone.API.DrawIris(renderer, partDataWrapper, OlympusOut, time, Textures.Irises.Erepiessence, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);
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
            usedHexes: new HexIndex[] { ReductionBodyOut, ReductionMindOut, ReductionIn, ReductionSoulOut, ReductionVoidOut },
            customPermission: MainClass.ReductionPermission
            );
        QApi.AddPartTypeToPanel(Reduction, false);
        QApi.AddPartType(Reduction, static (part, pos, editor, renderer) =>
        {
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out var pss, out var partDataWrapper, out var time);
            Vector2 pivot = new(164, 119);
            Vector2 offset = new(-1, -1);
            renderer.method_523(Textures.Reduction.Base, offset, pivot, 0);
            Brimstone.API.DrawIris(renderer, partDataWrapper, ReductionBodyOut, time, Textures.Irises.Body, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);
            Brimstone.API.DrawIris(renderer, partDataWrapper, ReductionMindOut, time, Textures.Irises.Mind, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[1]) : struct_18.field_1431);
            Brimstone.API.DrawIris(renderer, partDataWrapper, ReductionSoulOut, time, Textures.Irises.Soul, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[2]) : struct_18.field_1431);
            Brimstone.API.DrawIris(renderer, partDataWrapper, ReductionVoidOut, time, Textures.Irises.Void, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[3]) : struct_18.field_1431);
            renderer.method_528(Textures.SharedTextures.BasicHole, ReductionIn, Vector2.Zero);
            class_135.method_272(Textures.Holes.Erepiessence, (Brimstone.API.HexIndexToVector2(ReductionIn).Rotated(partDataWrapper.field_1985) + partDataWrapper.field_1984 - (Textures.Holes.Erepiessence.field_2056.ToVector2() / 2)).Rounded());
        });

        #endregion
        #endregion
        LoadGlyphBehavior();
    }

    public static void LoadGlyphBehavior() {
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

            else if (type == Reconstruction)
            {
                if (!(sim.FindAtomRelative(part, QuintLikeBowl).method_99(out AtomReference QuintSubject) && sim.FindAtomRelative(part, CelestBowl1).method_99(out AtomReference Celest1) && sim.FindAtomRelative(part, CelestBowl2).method_99(out AtomReference Celest2) && sim.FindAtomRelative(part, ReconstructionPowerHole).method_99(out AtomReference Input)))
                {
                    return;
                }
                if (Input.field_2281 || Input.field_2282)
                {
                    return;
                }
                if (!(Celest1.field_2280 == Celest2.field_2280 && Celest1.field_2280 == Atoms.Celest))
                {
                    return;
                }
                if (!(QuintSubject.field_2280 == Atoms.Erepiessence || QuintSubject.field_2280 == Brimstone.API.VanillaAtoms.quintessence))
                {
                    return;
                }
                if (!(Input.field_2280 == Atoms.Magis || Input.field_2280 == Atoms.Daedrum))
                {
                    return;
                }

                if (QuintSubject.field_2280 == Brimstone.API.VanillaAtoms.quintessence && Input.field_2280 == Atoms.Magis)
                {
                    Brimstone.API.ChangeAtom(QuintSubject, Atoms.Erepiessence);
                    QuintSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)1,
                        QuintSubject.field_2280,
                        class_238.field_1989.field_81.field_614,
                        30

                        
                    );
                    Brimstone.API.PlaySound(sim, Sounds.Reconstruction_Quint_Erepi);

                }
                else if (QuintSubject.field_2280 == Atoms.Erepiessence && Input.field_2280 == Atoms.Daedrum)
                {
                    Brimstone.API.ChangeAtom(QuintSubject, Brimstone.API.VanillaAtoms.quintessence);
                    QuintSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)1,
                        QuintSubject.field_2280,
                        class_238.field_1989.field_81.field_614,
                        30
                    );
                    Brimstone.API.PlaySound(sim, Sounds.Reconstruction_Erepi_Quint);
                }

                if (Input.field_2280 == Atoms.Magis)
                {
                    Brimstone.API.ChangeAtom(Celest1, Atoms.Ether);
                    Brimstone.API.ChangeAtom(Celest2, Atoms.Ether);
                    Celest1.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)1,
                        Celest1.field_2280,
                        class_238.field_1989.field_81.field_614,
                        30
                    );
                    Celest2.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)1,
                        Celest2.field_2280,
                        class_238.field_1989.field_81.field_614,
                        30
                    );
                    Brimstone.API.PlaySound(sim, Sounds.Reconstruction_Celest_Ether);
                }
                else
                {
                    Brimstone.API.ChangeAtom(Celest1, Salt);
                    Brimstone.API.ChangeAtom(Celest2, Salt);
                    Celest1.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        Celest1.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
                    Celest2.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        Celest2.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
                    Brimstone.API.PlaySound(sim, Sounds.Reconstruction_Celest_Salt);
                }

                Brimstone.API.RemoveAtom(Input);
                Brimstone.API.DrawFallingAtom(seb, Input);


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
                if (!LookupTables.AttributesFromAnymae(ImmoralSubject.field_2280, out int morality, out int grace))
                {
                    return;
                }
                if (!(ImmoralSubject.field_2280 == Atoms.Illustra || ImmoralSubject.field_2280 == Atoms.Turpis))
                {
                    return;
                }
                LookupTables.AnymaeFromAttributes(morality - 1, grace, out AtomType NewImmoral);
                LookupTables.AnymaeFromAttributes(morality + 1, grace, out AtomType NewMoral);

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
            else if (type == Absolution)
            {
                if (!(sim.FindAtomRelative(part, AbsolutionImmoralBowl).method_99(out AtomReference immoralSubject) && sim.FindAtomRelative(part, AbsolutionMoralBowl).method_99(out AtomReference moralSubject)))
                {
                    return;
                }
                if (!LookupTables.AttributesFromAnymae(moralSubject.field_2280, out int morality, out int grace) || !LookupTables.AttributesFromAnymae(immoralSubject.field_2280, out int morality2, out int grace2))
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

                LookupTables.AnymaeFromAttributes(0, grace, out AtomType immoralAbsolved);
                LookupTables.AnymaeFromAttributes(0, grace, out AtomType moralAbsolved);

                Brimstone.API.PlaySound(sim, Sounds.Absolution);

                Brimstone.API.ChangeAtom(moralSubject, moralAbsolved);
                Brimstone.API.ChangeAtom(immoralSubject, immoralAbsolved);

                immoralSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        immoralSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
                moralSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        moralSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
            }
            else if (type == Empowerment)
            {
                if (!(sim.FindAtomRelative(part, EmpowermentAnymaeBowl).method_99(out AtomReference anymaeSubject) && sim.FindAtomRelative(part, EmpowermentPowerBowl).method_99(out AtomReference powerSubject)))
                {
                    return;
                }
                int deltaGrace = 0;

                if (powerSubject.field_2280 == Atoms.Magis)
                {
                    deltaGrace = 1;
                }
                else if (powerSubject.field_2280 == Atoms.Daedrum)
                {
                    deltaGrace = -1;
                }
                else
                {
                    return;
                }

                if (!LookupTables.AttributesFromAnymae(anymaeSubject.field_2280, out int morality, out int grace) || !LookupTables.AnymaeFromAttributes(morality, grace + deltaGrace, out AtomType NewAnymae))
                {
                    return;
                }

                Brimstone.API.ChangeAtom(powerSubject, Brimstone.API.VanillaAtoms.salt);
                Brimstone.API.ChangeAtom(anymaeSubject, NewAnymae);

                Brimstone.API.PlaySound(sim, Sounds.Empowerment);

                anymaeSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        anymaeSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
                powerSubject.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        powerSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
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
                if (!LookupTables.AttributesFromAnymae(TBCured.field_2280, out int morality, out int grace))
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
                if (!LookupTables.AttributesFromAnymae(SympSubject.field_2280, out int morality, out int grace))
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

                LookupTables.AnymaeFromAttributes(morality * -1, grace, out AtomType NewMorality);

                Brimstone.API.ChangeAtom(SympSubject, NewMorality);
                Brimstone.API.PlaySound(sim, Sounds.Sympathy);

                SympSubject.field_2279.field_2276 = new class_168(
                    seb,
                    (enum_7)0,
                    (enum_132)0,
                    SympSubject.field_2280,
                    class_238.field_1989.field_81.field_611,
                    30
                );


            }
            else if (type == Enchantment)
            {


                bool madeCelest = false;
                if (sim.FindAtomRelative(part, EnchantmentHeavOut).method_1085())
                {
                    return;
                }
                if (!(sim.FindAtomRelative(part, EnchantmentInCard).method_99(out AtomReference Intake) && sim.FindAtomRelative(part, EnchantmentCardHost).method_99(out AtomReference host)))
                {
                    return;
                }
                if (Intake.field_2281 || Intake.field_2282)
                {
                    return;
                }
                if (!(Intake.field_2280 == host.field_2280))
                {
                    return;
                }

                AtomType SwappedCardinal = default;

                if (Intake.field_2280 == Salt)
                {
                    SwappedCardinal = Atoms.Celest;
                    madeCelest = true;
                }

                else if ((!LookupTables.SwapCardinalPairing(Intake.field_2280, out SwappedCardinal, out bool isHeavenly)) || isHeavenly)
                {
                    return;
                }

                Brimstone.API.RemoveAtom(Intake);
                Brimstone.API.DrawFallingAtom(seb, Intake);

                pss.field_2743 = true;
                Brimstone.API.AddAtom(sim, part, EnchantmentHeavOut, SwappedCardinal);
                host.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        host.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );


                seb.field_3936.Add(new class_228(
                    seb,
                    (enum_7)1,
                    Brimstone.API.HexIndexToVector2(part.method_1184(EnchantmentHeavOut)) + new Vector2(80, 0),
                    class_238.field_1989.field_90.field_240,
                    30,
                    Vector2.Zero,
                    0
                ));
                if (madeCelest)
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

                Brimstone.API.ChangeAtom(host, !madeCelest ? Salt : Atoms.Celest);
                Brimstone.API.PlaySound(sim, !madeCelest ? Sounds.Enchantment : Sounds.EnchantmentCelest);
            }
            else if (type == Incantation)
            {
                if (first)
                {


                    if (sim.FindAtomRelative(part, EtherOut1).method_1085() || sim.FindAtomRelative(part, EtherOut2).method_1085() || sim.FindAtomRelative(part, SaltOut).method_1085())
                    {
                        return;
                    }
                    if (!sim.FindAtomRelative(part, ErepiBowl).method_99(out AtomReference EBowl))
                    {
                        return;
                    }
                    if (!(EBowl.field_2280 == Atoms.Erepiessence))
                    {
                        return;
                    }

                    
                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[3] { Atoms.Ether, Salt, Atoms.Ether };
                    Brimstone.API.ChangeAtom(EBowl, Salt);
                    EBowl.field_2279.field_2276 = new class_168
                    (
                        seb,
                        (enum_7)0,
                        (enum_132)0,
                        EBowl.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
                    seb.field_3935.Add(new class_228
                            (
                                seb,
                                (enum_7)1,
                                Brimstone.API.HexIndexToVector2(part.method_1184(ErepiBowl)) + new Vector2(147, 47),
                                class_238.field_1989.field_90.field_242,
                                30,
                                Vector2.Zero,
                                0
                            )
                        );
                    Brimstone.API.PlaySound(sim, Sounds.Incantation);
                }
                else if (pss.field_2743)
                {

                    Molecule output = new();
                    output.method_1105(new Atom(pss.field_2744[0]), part.method_1184(EtherOut1));
                    output.method_1105(new Atom(pss.field_2744[1]), part.method_1184(SaltOut));
                    output.method_1105(new Atom(pss.field_2744[2]), part.method_1184(EtherOut2));

                    // is thaat the 1 of 1 of 1 of1 ???!!
                    output.method_1111(enum_126.Standard, part.method_1184(EtherOut1), part.method_1184(SaltOut));
                    output.method_1111(enum_126.Standard, part.method_1184(SaltOut), part.method_1184(EtherOut2));

                    sim.field_3823.Add(output);
                }

            }
            else if (type == Olympus)
            {
                if (first)
                {
                    if (sim.FindAtomRelative(part, OlympusOut).method_1085())
                    {
                        return;
                    }

                    bool absents = false;
                    AtomReference[] holeAtoms = OlympusInputs.Select((h) =>
                    {
                        bool exists = sim.FindAtomRelative(part, h).method_99(out AtomReference atomReference);
                        absents |= !exists;
                        return atomReference;
                    }).ToArray();

                    if (absents)
                    {
                        return;
                    }

                    int specialAtomNumber = 0; // we use this to tell if we have all 4 unique heavenly cardinals

                    foreach (AtomReference holeAtom in holeAtoms)
                    {
                        if (holeAtom.field_2281 || holeAtom.field_2282)
                        {
                            return;
                        }

                        if (holeAtom.field_2280 == Atoms.Body)
                        {
                            specialAtomNumber |= 0b0001;

                        }
                        else if (holeAtom.field_2280 == Atoms.Mind)
                        {
                            specialAtomNumber |= 0b0010;
                        }
                        else if (holeAtom.field_2280 == Atoms.Soul)
                        {
                            specialAtomNumber |= 0b0100;

                        }
                        else if (holeAtom.field_2280 == Atoms.Void)
                        {
                            specialAtomNumber |= 0b1000;
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (specialAtomNumber != 0b1111)
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
            else if (type == Reduction)
            {
                if (first)
                {
                    if (sim.FindAtomRelative(part, ReductionBodyOut).method_1085() || sim.FindAtomRelative(part, ReductionMindOut).method_1085() || sim.FindAtomRelative(part, ReductionSoulOut).method_1085() || sim.FindAtomRelative(part, ReductionVoidOut).method_1085())
                    {
                        return;
                    }
                    if (!sim.FindAtomRelative(part, ReductionIn).method_99(out AtomReference intake))
                    {
                        return;
                    }
                    if (intake.field_2281 || intake.field_2282)
                    {
                        return;
                    }
                    if (intake.field_2280 != Atoms.Erepiessence)
                    {
                        return;
                    }

                    Brimstone.API.RemoveAtom(intake);
                    Brimstone.API.DrawFallingAtom(seb, intake);
                    Brimstone.API.PlaySound(sim, Sounds.Reduction);
                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[4] { Atoms.Body, Atoms.Mind, Atoms.Soul, Atoms.Void };
                }
                else if (pss.field_2743)
                {

                    Brimstone.API.AddAtom(sim, part, ReductionBodyOut, pss.field_2744[0]);
                    Brimstone.API.AddAtom(sim, part, ReductionMindOut, pss.field_2744[1]);
                    Brimstone.API.AddAtom(sim, part, ReductionSoulOut, pss.field_2744[2]);
                    Brimstone.API.AddAtom(sim, part, ReductionVoidOut, pss.field_2744[3]);
                }
            }


        });

        QApi.RunAfterCycle((sim, first) =>
        {

            if (first)
            {
                return;
            }
            List<Atom> atoms = new();
            foreach (Molecule m in sim.field_3823)
            {
                if (m.method_1100().Keys.Count() < 2)
                {
                    continue;
                }

                foreach (var atomAndPosition in m.method_1100())
                {
                    if (atomAndPosition.Value.field_2275 != Atoms.Ether)
                    {
                        continue;
                    }
                    foreach (HexIndex offset in HexIndex.AdjacentOffsets)
                    {
                        HexIndex etherPos = atomAndPosition.Key;
                        HexIndex neighbPos = etherPos + offset;
                        var bond = Brimstone.API.FindBondType(m, etherPos, neighbPos);
                        if (bond != enum_126.None && m.method_1100().Keys.Contains(neighbPos))
                        {
                            var atomNeighboor = m.method_1100()[neighbPos];
                            if (atomNeighboor.field_2275 == Atoms.Ether)
                            {
                                atoms.Add(atomAndPosition.Value);
                            }
                        }
                    }
                }

            }
            if (atoms.Any())
            {
                Brimstone.API.PlaySound(sim, Sounds.EtherPoof);
            }
            foreach (Atom a in atoms)
            {
                a.field_2275 = Brimstone.API.VanillaAtoms.salt;
                a.field_2276 = new class_168
                    (
                        sim.field_3818,
                        (enum_7)0,
                        (enum_132)0,
                        Atoms.Ether,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
            }

        });

    }


}
