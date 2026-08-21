using Texture = class_256;
namespace FalseAether;

public static class Textures
{
    private const string partsPath = "textures/parts/erikhaag/FalseAether/";
    
    public static class Icons
    {
        public static Texture Inquisition = Brimstone.API.GetTexture(partsPath + "icons/inquisition");
        public static Texture InquisitionHovered = Brimstone.API.GetTexture(partsPath + "icons/inquisition_hovered");

        public static Texture Polarization = Brimstone.API.GetTexture(partsPath + "icons/polarization");
        public static Texture PolarizationHovered = Brimstone.API.GetTexture(partsPath + "icons/polarization_hovered");

        public static Texture Absolution = Brimstone.API.GetTexture(partsPath + "icons/absolution");
        public static Texture AbsolutionHovered = Brimstone.API.GetTexture(partsPath + "icons/absolution_hovered");

        public static Texture Empowerment = Brimstone.API.GetTexture(partsPath + "icons/empowerment");
        public static Texture EmpowermentHovered = Brimstone.API.GetTexture(partsPath + "icons/empowerment_hovered");

        public static Texture TrueSight = Brimstone.API.GetTexture(partsPath + "icons/true_sight");
        public static Texture TrueSightHovered = Brimstone.API.GetTexture(partsPath + "icons/true_sight_hovered");

        public static Texture Enchantment = Brimstone.API.GetTexture(partsPath + "icons/enchantment");
        public static Texture EnchantmentHovered = Brimstone.API.GetTexture(partsPath + "icons/enchantment_hovered");

        public static Texture Curing = Brimstone.API.GetTexture(partsPath + "icons/curing");
        public static Texture CuringHovered = Brimstone.API.GetTexture(partsPath + "icons/curing_hovered");

        public static Texture Sympathy = Brimstone.API.GetTexture(partsPath + "icons/sympathy");
        public static Texture SympathyHovered = Brimstone.API.GetTexture(partsPath + "icons/sympathy_hovered");

        public static Texture Olympus = Brimstone.API.GetTexture(partsPath + "icons/olympus");
        public static Texture OlympusHovered = Brimstone.API.GetTexture(partsPath + "icons/olympus_hovered");
        public static Texture Reduction = Brimstone.API.GetTexture(partsPath + "icons/reduction");
        public static Texture ReductionHovered = Brimstone.API.GetTexture(partsPath + "icons/reduction_hovered");
        
        public static Texture Incantation= Brimstone.API.GetTexture(partsPath + "icons/incantation");
        public static Texture IncantationHovered = Brimstone.API.GetTexture(partsPath + "icons/incantation_hovered");
    }
    
    public static class Select
    {
        public static Texture LineGlow = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/line_glow");
        public static Texture LineStroke = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/line_stroke");

        public static Texture SingleGlow = class_238.field_1989.field_97.field_382;
        public static Texture SingleStroke = class_238.field_1989.field_97.field_383;

        public static Texture EuniGlow = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/EUni/glow");
        public static Texture EuniStroke = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/EUni/stroke");

        public static Texture EdispGlow = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/EDisp/glow");
        public static Texture EdispStroke = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/EDisp/stroke");

        public static Texture CuringGlow = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/Curing/glow");
        public static Texture CuringStroke = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/Curing/stroke");

        public static Texture SympathyGlow = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/Sympathy/glow");
        public static Texture SympathyStroke = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/Sympathy/stroke");
        
        public static Texture IncantationGlow = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/Incantation/glow");
        public static Texture IncantationStroke = Brimstone.API.GetTexture("textures/select/erikhaag/FalseAether/Incantation/stroke");
    }

    public static class SharedTextures 
    {
        public static Texture BasicBowl = class_238.field_1989.field_90.field_170;
        public static Texture BasicHole = Brimstone.API.GetTexture(partsPath + "basic_hole");
        public static Texture PolarEngraving = Brimstone.API.GetTexture(partsPath + "polar_anymae");
        public static Texture PowerGlow = Brimstone.API.GetTexture(partsPath + "power_glow");
        public static Texture PowerEngraving = Brimstone.API.GetTexture(partsPath + "power_symbol");
        public static Texture SaltEngraving = Brimstone.API.GetTexture(partsPath + "symbol_salt");
        public static Texture DividerEngraving = Brimstone.API.GetTexture(partsPath + "engraved_divider");
        public static Texture DividerGlow = Brimstone.API.GetTexture(partsPath + "symbol_divider");
        public static Texture CardinalsGlow = Brimstone.API.GetTexture(partsPath + "cardinals_glow");
        public static Texture CardinalsEngraved = class_238.field_1989.field_90.field_171;

    }

    public static class Holes
    {
        public static Texture Celest = Brimstone.API.GetTexture(partsPath + "celest_hole");
        public static Texture Erepiessence = Brimstone.API.GetTexture(partsPath + "erepiessence_hole");
        public static Texture Salt = class_238.field_1989.field_90.field_228.field_275;

    }

    public static class Bowls
    {
        public static Texture Erepiessence = Brimstone.API.GetTexture(partsPath + "erepiessence_bowl");
    }

    public static class Irises
    {
        public static Texture[] Body = Brimstone.API.GetAnimation(partsPath + "iris_full_body.array", "iris", 16);
        public static Texture[] Erepiessence = Brimstone.API.GetAnimation(partsPath + "iris_full_erepiessence.array", "iris", 16);
        public static Texture[] Ether = Brimstone.API.GetAnimation(partsPath + "iris_full_ether.array", "iris", 16);
        public static Texture[] Mind = Brimstone.API.GetAnimation(partsPath + "iris_full_mind.array", "iris", 16);
        public static Texture[] Soul = Brimstone.API.GetAnimation(partsPath + "iris_full_soul.array", "iris", 16);
        public static Texture[] Void = Brimstone.API.GetAnimation(partsPath + "iris_full_void.array", "iris", 16);
    }


    // Glyph Specific Textures
    public static class Inquisition
    {
        public static Texture MagisBowl = Brimstone.API.GetTexture(partsPath + "Inquisition/magis_bowl");
        public static Texture DaedrumBowl = Brimstone.API.GetTexture(partsPath + "Inquisition/daedrum_bowl");
    }

    public static class Incantation
    {
        public static Texture IncantationBase = Brimstone.API.GetTexture(partsPath + "Incantation/base");
    }
    public static class Polarization
    {
        public static Texture PolarizationEngraving = Brimstone.API.GetTexture(partsPath + "Polarization/polarization_symbol");
        public static Texture PolarizationMorsTint = Brimstone.API.GetTexture(partsPath + "Polarization/polarization_mors_tint");
        public static Texture PolarizationVitaeTint = Brimstone.API.GetTexture(partsPath + "Polarization/polarization_vitae_tint");
        public static Texture PolarizationBase = Brimstone.API.GetTexture(partsPath + "Polarization/polarization_base");
    }

    public static class Enchantment
    {
        public static Texture Base = Brimstone.API.GetTexture(partsPath + "Enchantment/base");
        public static Texture CrazyIris = Brimstone.API.GetTexture(partsPath + "Enchantment/crazy_iris");
    }

    public static class Curing
    {
        public static Texture Base = Brimstone.API.GetTexture(partsPath + "Curing/base");
        
    }
    public static class Absolution
    {
        public static Texture Engravings = Brimstone.API.GetTexture(partsPath + "Absolution/anymae_engraving");
        public static Texture Base = Brimstone.API.GetTexture(partsPath + "Absolution/base");
    }
    public static class Empowerment
    {
        public static Texture Base = Brimstone.API.GetTexture(partsPath + "Empowerment/base");
        public static Texture AnymaeBowl = Brimstone.API.GetTexture(partsPath + "Empowerment/anymae_bowl");
        public static Texture PowerBowl = Brimstone.API.GetTexture(partsPath + "Empowerment/power_bowl");
        public static Texture SaltSymbol = Brimstone.API.GetTexture(partsPath + "Empowerment/salt_engraving");
        public static Texture PowerSymbol = Brimstone.API.GetTexture(partsPath + "Empowerment/power_symbol");
    }
    
    public static class TrueSight
    {
        public static Texture TrueSightBase = Brimstone.API.GetTexture(partsPath + "TrueSight/truesight_base");
        public static Texture TrueSightEye = Brimstone.API.GetTexture(partsPath + "TrueSight/truesight_eye");

    }
    public static class Sympathy
    {
        public static Texture Base = Brimstone.API.GetTexture(partsPath + "Sympathy/base");
    }

    public static class Olympus
    {
        public static Texture Base = Brimstone.API.GetTexture(partsPath + "EUni/base");
        public static Texture BodyActive = Brimstone.API.GetTexture(partsPath + "EUni/body_active");
        public static Texture MindActive = Brimstone.API.GetTexture(partsPath + "EUni/mind_active");
        public static Texture VoidActive = Brimstone.API.GetTexture(partsPath + "EUni/void_active");
        public static Texture SoulActive = Brimstone.API.GetTexture(partsPath + "EUni/soul_active");

        public static Texture BodyInactive = Brimstone.API.GetTexture(partsPath + "EUni/body_inactive");
        public static Texture MindInactive = Brimstone.API.GetTexture(partsPath + "EUni/mind_inactive");
        public static Texture VoidInactive = Brimstone.API.GetTexture(partsPath + "EUni/void_inactive");
        public static Texture SoulInactive = Brimstone.API.GetTexture(partsPath + "EUni/soul_inactive");
    }

    public static class Reduction
    {
        public static Texture Base = Brimstone.API.GetTexture(partsPath + "EDisp/base");

        // potentially remove?
        public static Texture BodyGlow = Brimstone.API.GetTexture(partsPath + "EDisp/body_symbol");
        public static Texture MindGlow = Brimstone.API.GetTexture(partsPath + "EDisp/mind_symbol");
        public static Texture SoulGlow = Brimstone.API.GetTexture(partsPath + "EDisp/soul_symbol");
        public static Texture VoidGlow = Brimstone.API.GetTexture(partsPath + "EDisp/void_symbol");
    }

}
