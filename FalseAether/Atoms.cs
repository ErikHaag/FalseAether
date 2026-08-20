using Quintessential;
namespace FalseAether;

public static class Atoms
{
    public static AtomType Erepiessence, Body, Mind, Soul, Void, Ether;
    public static AtomType Magis, Daedrum, Celest;
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

        Body = Brimstone.API.CreateCardinalAtom(
            ID: 241,
            modName: "FalseAether",
            name: "Body",
            pathToBase: "textures/atoms/erikhaag/FalseAether/body_base",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/body_symbol",
            pathToShadow: "textures/atoms/erikhaag/FalseAether/body_shadow"
            );
        Mind = Brimstone.API.CreateCardinalAtom(
            ID: 242,
            modName: "FalseAether",
            name: "Mind",
            pathToBase: "textures/atoms/erikhaag/FalseAether/mind_base",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/mind_symbol",
            pathToShadow: "textures/atoms/erikhaag/FalseAether/mind_shadow"
            );
        Void = Brimstone.API.CreateCardinalAtom(
            ID: 243,
            modName: "FalseAether",
            name: "Void",
            pathToBase: "textures/atoms/erikhaag/FalseAether/void_base",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/void_symbol",
            pathToShadow: "textures/atoms/erikhaag/FalseAether/void_shadow"
            );
        Soul = Brimstone.API.CreateCardinalAtom(
            ID: 244,
            modName: "FalseAether",
            name: "Soul",
            pathToBase: "textures/atoms/erikhaag/FalseAether/soul_base",
            pathToFog: "textures/atoms/erikhaag/FalseAether/soul_fog",
            pathToBase2: "textures/atoms/erikhaag/FalseAether/soul_base2",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/soul_symbol",
            pathToShadow: "textures/atoms/erikhaag/FalseAether/soul_shadow"
            );

        Erepiessence = Brimstone.API.CreateQuintessenceAtom(
            ID: 245,
            modName: "FalseAether",
            name: "Erepiessence",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/erepi_symbol",
            pathToColors: "textures/atoms/erikhaag/FalseAether/erepi_colors",
            pathToBase: "textures/atoms/erikhaag/FalseAether/erepi_base",
            pathToRimlight: "textures/atoms/erikhaag/FalseAether/erepi_rimlight",
            pathToShadow: "textures/atoms/erikhaag/FalseAether/erepi_shadow"
            );
        Celest = Brimstone.API.CreateNormalAtom(
            ID: 246,
            modName: "FalseAether",
            name: "Celest",
            pathToSymbol: "textures/atoms/erikhaag/FalseAether/potash_symbol",
            pathToDiffuse: "textures/atoms/erikhaag/FalseAether/potash_diffuse",
            pathToShade: "textures/atoms/erikhaag/FalseAether/potash_shade"
            );


        QApi.AddAtomType(Magis);
        QApi.AddAtomType(Daedrum);
        QApi.AddAtomType(Inops);
        QApi.AddAtomType(Illustra);
        QApi.AddAtomType(Capax);
        QApi.AddAtomType(Aegero);
        QApi.AddAtomType(Turpis);
        QApi.AddAtomType(Phasmus);
        
        QApi.AddAtomType(Celest);

        QApi.AddAtomType(Body);
        QApi.AddAtomType(Void);
        QApi.AddAtomType(Mind);
        QApi.AddAtomType(Soul);

        QApi.AddAtomType(Erepiessence);
    }

}
