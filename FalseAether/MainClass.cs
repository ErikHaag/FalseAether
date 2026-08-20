using Quintessential;
namespace FalseAether;

public class MainClass : QuintessentialMod
{
    public const string LoggerPrefix = "False Aether: ";
    public static readonly string InquisitionPermission = "FalseAether:Inquisition";
    public static readonly string EmpowermentPermission = "FalseAether:Empowerment";
    public static readonly string PolarizationPermission = "FalseAether:Polarization";
    public static readonly string TrueSightPermission = "FalseAether:TrueSight";
    public static readonly string AbsolutionPermission = "FalseAether:Absolution";
    public static readonly string OlympusPermission = "FalseAether:Olympus";
    public static readonly string ReductionPermission = "FalseAether:Reduction";
    public static readonly string CuringPermission = "FalseAether:Curing";
    public static readonly string SympathyPermission = "FalseAether:Sympathy";
    public static readonly string EnchantmentPermission = "FalseAether:Enchantment";

    public static string contentPath;

    public override void Load() {
        Logger.Log(LoggerPrefix + "Oh I am salting it man I am salting it so hard.");
    }
    
    public override void LoadPuzzleContent() {
        contentPath = Brimstone.API.GetContentPath("FalseAether").method_1087();
        Logger.Log(LoggerPrefix + "Creating the Grace");
        Atoms.LoadAtoms();
        Logger.Log(LoggerPrefix + "Charting It Up!");
        LookupTable.SetupCharts();
        Logger.Log (LoggerPrefix + "There are some loose tweakers we need to wrangle");
        Glyphs.AddHooks();
        Logger.Log(LoggerPrefix + "Glyph time");
        Glyphs.LoadGlyphs();
        QApi.AddPuzzlePermission(InquisitionPermission, "Glyph of Inquisition", "False Aether: Gracing Anymae");
        QApi.AddPuzzlePermission(PolarizationPermission, "Glyph of Polarization", "False Aether: Gracing Anymae");
        QApi.AddPuzzlePermission(AbsolutionPermission, "Glyph of Absolution", "False Aether: Gracing Anymae");
        QApi.AddPuzzlePermission(EmpowermentPermission, "Glyph of Empowerment", "False Aether: Gracing Anymae");
        QApi.AddPuzzlePermission(TrueSightPermission, "Glyph of True Sight", "False Aether: Gracing Anymae");
        QApi.AddPuzzlePermission(CuringPermission, "Glyph of Curing", "False Aether: Gracing Anymae");
        QApi.AddPuzzlePermission(SympathyPermission, "Glyph of Sympathy", "False Aether: Gracing Anymae");
        QApi.AddPuzzlePermission(EnchantmentPermission, "Glyph of Enchantment", "False Aether: Heavenlies and Earthlies");
        QApi.AddPuzzlePermission(OlympusPermission, "Glyph of Olympus", "False Aether: Erepiessence and Ether");
        QApi.AddPuzzlePermission(ReductionPermission, "Glyph of Reduction", "False Aether: Erepiessence and Ether");
        Logger.Log(LoggerPrefix + "Listening for sounds");
        Sounds.LoadSounds();
    }
    
    public override void PostLoad()
    {
    
    }
    
    public override void Unload() {
        Glyphs.RemoveHooks();
    }
}
