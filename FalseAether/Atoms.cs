using Quintessential;
namespace FalseAether;

public static class Atoms
{
    public static AtomType Erepiessence, Body, Mind, Soul, Void, Ether;
    public static AtomType Magis, Daedrum;
    public static AtomType Illustra, Inops, Capax, Turpis, Phasmus, Aegero;

    public static void LoadAtoms()
    {
        //Load Magis and Daedrum
        Magis = Brimstone.API.CreateNormalAtom(
            ID: 233,
            modName: "FalseAether",
            name: "Magis",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/magis_symbol",
            pathToDiffuse: "textures/atoms/erikhaag/FalseAether/magis_diffuse", 
            pathToShade: "textures/atoms/erikhaag/FalseAether/magis_shade"
            );
        Daedrum = Brimstone.API.CreateNormalAtom(
            ID: 234,
            modName: "FalseAether",
            name: "Daedrum",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/daedrum_symbol",
            pathToDiffuse: "textures/atoms/erikhaag/FalseAether/daedrum_diffuse",
            pathToShade: "textures/atoms/erikhaag/FalseAether/daedrum_shade"
            );
        QApi.AddAtomType(Magis);
        QApi.AddAtomType(Daedrum);
    }

}
