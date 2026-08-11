using Quintessential;
namespace FalseAether;

public class MainClass : QuintessentialMod
{
    public const string LoggerPrefix = "False Aether: ";

    public override void Load() {
        Logger.Log(LoggerPrefix + "Loading!");
    }
    
    public override void LoadPuzzleContent() {

    }
    
    public override void PostLoad()
    {
    
    }
    
    public override void Unload() {
    
    }
}
