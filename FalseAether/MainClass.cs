using Quintessential;
namespace FalseAether;

public class MainClass : QuintessentialMod
{
    public const string LoggerPrefix = "False Aether: ";

    public override void Load() {
        Logger.Log(LoggerPrefix + "Oh I am salting it man I am salting it so hard.");
    }
    
    public override void LoadPuzzleContent() {
        Logger.Log(LoggerPrefix + "Creating the Grace");
        Atoms.LoadAtoms();
    }
    
    public override void PostLoad()
    {
    
    }
    
    public override void Unload() {
    
    }
}
