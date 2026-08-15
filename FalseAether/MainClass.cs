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

    public static string contentPath;

    public override void Load() {
        Logger.Log(LoggerPrefix + "Oh I am salting it man I am salting it so hard.");
    }
    
    public override void LoadPuzzleContent() {
        contentPath = Brimstone.API.GetContentPath("FalseAether").method_1087();
        Logger.Log(LoggerPrefix + "Creating the Grace");
        Atoms.LoadAtoms();
        Logger.Log(LoggerPrefix + "Charting It Up!");
        LookupTable.setupAlignmentChart();
        Logger.Log(LoggerPrefix + "Glyph time");
        Glyphs.LoadGlyphs();
        QApi.AddPuzzlePermission(InquisitionPermission, "Glyph of Inquisition", "False Aether: Gracing Anymae");
        QApi.AddPuzzlePermission(PolarizationPermission, "Glyph of Polarization", "False Aether: Gracing Anymae");
        QApi.AddPuzzlePermission(AbsolutionPermission, "Glyph of Absolution", "False Aether: Gracing Anymae");
        QApi.AddPuzzlePermission(EmpowermentPermission, "Glyph of Empowerment", "False Aether: Gracing Anymae");
        QApi.AddPuzzlePermission(TrueSightPermission, "Glyph of True Sight", "False Aether: Gracing Anymae");
        Logger.Log(LoggerPrefix + "Listening for sounds");
        Sounds.LoadSounds();
    }
    
    public override void PostLoad()
    {
    
    }
    
    public override void Unload() {
    
    }
}
