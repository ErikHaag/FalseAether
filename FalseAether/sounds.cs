using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace FalseAether
{
    internal static class Sounds
    {


        public static Sound Absolution;
        public static Sound Empowerment;
        public static Sound Inquisition;
        public static Sound Polarization;

        public static void LoadSounds()
        {
            Absolution = Brimstone.API.GetSound(MainClass.contentPath, "sounds/absolution").method_1087();
            Empowerment = Brimstone.API.GetSound(MainClass.contentPath, "sounds/empowerment").method_1087();
            Inquisition = Brimstone.API.GetSound(MainClass.contentPath, "sounds/inquisition").method_1087();
            Polarization = Brimstone.API.GetSound(MainClass.contentPath, "sounds/polarization").method_1087();
         

            FieldInfo field = typeof(class_11).GetField("field_52", BindingFlags.Static | BindingFlags.NonPublic);
            Dictionary<string, float> volumeDictionary = (Dictionary<string, float>)field.GetValue(null);

            volumeDictionary.Add("absolution", 0.5f);
            volumeDictionary.Add("empowerment", 0.3f);
            volumeDictionary.Add("inquisition", 0.3f);
            volumeDictionary.Add("polarization", 0.3f);
            

            On.class_201.method_540 += Sounds.Method_540;
        }

        public static void Unload()
        {
            On.class_201.method_540 -= Sounds.Method_540;
        }

        public static void Method_540(On.class_201.orig_method_540 orig, class_201 self)
        {
            orig(self);
            Absolution.field_4062 = false;
            Empowerment.field_4062 = false;
            Inquisition.field_4062 = false;
            Polarization.field_4062 = false;
            
        }
    }
}