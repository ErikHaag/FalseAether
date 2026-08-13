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
        Inops = Brimstone.API.CreateNormalAtom(
            ID: 235,
            modName: "FalseAether",
            name: "Inops",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/inops_symbol",
            pathToDiffuse: "textures/atoms/erikhaag/FalseAether/inops_diffuse",
            pathToShade: "textures/atoms/erikhaag/FalseAether/inops_shade"
            );
        Illustra = Brimstone.API.CreateNormalAtom(
            ID: 236,
            modName: "FalseAether",
            name: "Illustra",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/illustra_symbol",
            pathToDiffuse: "textures/atoms/erikhaag/FalseAether/illustra_diffuse",
            pathToShade: "textures/atoms/erikhaag/FalseAether/illustra_shade"
            );
        Capax = Brimstone.API.CreateNormalAtom(
            ID: 237,
            modName: "FalseAether",
            name: "Capax",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/capax_symbol",
            pathToDiffuse: "textures/atoms/erikhaag/FalseAether/capax_diffuse",
            pathToShade: "textures/atoms/erikhaag/FalseAether/capax_shade"
            );
        Aegero = Brimstone.API.CreateNormalAtom(
            ID: 238,
            modName: "FalseAether",
            name: "Aegero",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/aegero_symbol",
            pathToDiffuse: "textures/atoms/erikhaag/FalseAether/aegero_diffuse",
            pathToShade: "textures/atoms/erikhaag/FalseAether/aegero_shade"
            );
        Turpis = Brimstone.API.CreateNormalAtom(
            ID: 239,
            modName: "FalseAether",
            name: "Turpis",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/turpis_symbol",
            pathToDiffuse: "textures/atoms/erikhaag/FalseAether/turpis_diffuse",
            pathToShade: "textures/atoms/erikhaag/FalseAether/turpis_shade"
            );
        Phasmus = Brimstone.API.CreateNormalAtom(
            ID: 240,
            modName: "FalseAether",
            name: "Phasmus",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/phasmus_symbol",
            pathToDiffuse: "textures/atoms/erikhaag/FalseAether/phasmus_diffuse",
            pathToShade: "textures/atoms/erikhaag/FalseAether/phasmus_shade"
            );
        QApi.AddAtomType(Magis);
        QApi.AddAtomType(Daedrum);
        QApi.AddAtomType(Inops);
        QApi.AddAtomType(Illustra);
        QApi.AddAtomType(Capax);
        QApi.AddAtomType(Aegero);
        QApi.AddAtomType(Turpis);
        QApi.AddAtomType(Phasmus);
    }

}
