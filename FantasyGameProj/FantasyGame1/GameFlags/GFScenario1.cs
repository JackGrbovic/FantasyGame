using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyGame1.GameFlags
{
    class GFScenario1
    {
        private bool? checkOnVin;
        public bool? _CheckOnVin { get => checkOnVin; set => checkOnVin = value; }


        

        //these are nullable booleans that are stored here to be used later. They are determined to be true or false
        //with an if statement which is controlled by player choices done by a Console.ReadLine()
    }
}
