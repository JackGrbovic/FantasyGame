using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyGame1
{
    class DamageModifierTable
    {
        private List<string> Weapons = new List<string>() { "Sword", "Arrow", "Spear", "Mace" };
        private List<string> Armour = new List<string>() { "Leather", "Light Mail", "Light Plate", "Heavy Mail", "Heavy Plate" };
        string[,] modVals = new string[4, 5];
        //here we've created a list for the element types and an array that forms a table for the crossover of our element types
        //and how they affect each other

        public DamageModifierTable()
        {
            modVals = new string[4, 5];
            //this is a multidimensional array with 5 rows and 5 columns

            modVals[0, 1] = "Leather";
            modVals[0, 2] = "Light Mail";
            modVals[0, 3] = "Light Plate";
            modVals[0, 4] = "Heavy Mail";
            modVals[0, 5] = "Heavy Plate";
            //this is puts strings in columns 1,2,3 and 4 on the topline which is row 0

            modVals[1, 0] = "Sword";
            modVals[2, 0] = "Arrow";
            modVals[3, 0] = "Spear";
            modVals[4, 0] = "Mace";

            //this does the inverse, putting those same names on column 0 at rows 1,2,3 and 4

            modVals[1, 1] = "1";
            modVals[1, 2] = "1";
            modVals[1, 3] = "1";
            modVals[1, 4] = "1";
            //this assigns a string value of 1 to the crossovers of normal and normal, normal and fire, normal and frost and normal and thunder

            modVals[2, 1] = "1";
            modVals[2, 2] = "1";
            modVals[2, 3] = "1.5";
            modVals[2, 4] = ".5";
            //this assigns a string value of 1 to the crossovers of fire to normal, fire to fire, 1.5x from fire to frost and 0.5 times from fire to thunder

            modVals[3, 1] = "1";
            modVals[3, 2] = ".5";
            modVals[3, 3] = "1";
            modVals[3, 4] = "1.5";
            //this assigns a string value of 1 to the crossover of frost and normal, 0.5 from frost to fire, 1 from frost to frost and 1.5 from frost to thunder

            modVals[4, 1] = "1";
            modVals[4, 2] = "1.5";
            modVals[4, 3] = ".5";
            modVals[4, 4] = "1";
            //this assigns a stringvalue of 1 to the crossover of thunder to normal, 1.5 from thunder to fire, 0.5 from thunder to frost and 1 from thunder to thunder
        }
    }

    public static class ArmourTypes
    {
        public static object LightMail;
    }
}
