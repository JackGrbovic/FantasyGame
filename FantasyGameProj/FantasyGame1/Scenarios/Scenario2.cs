using FantasyGame1.GameItems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FantasyGame1.Scenarios
{
    class Scenario2
    {
        
        public static List<Object> objectsInScenario = new List<Object>();

        public Scenario2(List<Object> itemsToLoad)
        {
            objectsInScenario = itemsToLoad;
        }


        static List<Character> characterList = new List<Character>();
        public static void AddObjectsToScenario2()
        {
            for (int i = 0; i < objectsInScenario.Count; i++)
            {
                if (objectsInScenario[i] is Character)
                {
                    characterList.Add((Character)objectsInScenario[i]);
                }
            }
        }



        public void Launch()
        {
            Accomplice accomplice = null;
            Player player = null;
            for (int i = 0; i < characterList.Count; i++)
            {
                if (characterList[i] is Accomplice)
                {
                    accomplice = (Accomplice)characterList[i];
                }
                if (characterList[i] is Player)
                {
                    player = (Player)characterList[i];
                }
            }
            Scenario2Story(accomplice, player);
        }


        public Character CharacterIs(Character pCharacter)
        {
            Character returnCharacter = null;
            if (pCharacter is Accomplice)
            {
                returnCharacter = (Accomplice)pCharacter;
            }
            if (pCharacter is Player)
            {
                returnCharacter = (Player)pCharacter;
            }
            return returnCharacter;
        }


        public static void Scenario2Story(Accomplice vin, Player aldwin)
        {
            Narrator narrator = new Narrator("Narrator", 1, 1, true, 1, 1, 1, 1, 1, null, null);
            ProgUtilities.DistributeObjectsInScenario(objectsInScenario, characterList);
            AddObjectsToScenario2();
            Console.WriteLine("Scenario 2 Loaded");
            Thread.Sleep(1000);
            Console.Clear();

            if (aldwin.Health < 50)
            {
                narrator.Narrate("You didn’t get out of that unscathed. You took some damage but were more or less alright.");
            }
            else
            {
                narrator.Narrate("You got out of that alright. But count yourself lucky.");
            }
            ProgUtilities.MoveOn();

            if (vin.Health < 50)
            {
                narrator.Narrate("Vin was scratched up but still able and sound of mind and mostly of body.");
            }
            else
            {
                narrator.Narrate("Vin himself was fine.");
            }
            ProgUtilities.MoveOn();

            narrator.Narrate("You both studied the corpses that lay before you.");
            ProgUtilities.MoveOn();
            vin.Speak("Good heavens. That was very close. If any more of them are about we may not be so lucky.");
            ProgUtilities.MoveOn();
            aldwin.Speak("We don't need luck. We need to pick up the pace and get ourselves to that damned holdfast right now.");
            ProgUtilities.MoveOn();
            aldwin.Speak("Agreed?");
            ProgUtilities.MoveOn();
            vin.Speak("What about the tower?");
            ProgUtilities.MoveOn();
            narrator.Narrate("You forgot about that damned tower.");
            ProgUtilities.MoveOn();
            narrator.Narrate("You nodded and followed Vin to the flaming structure.");
            ProgUtilities.MoveOn();
            narrator.Narrate("It was still blazing despite the rain coming down on it.");
            ProgUtilities.MoveOn();
            narrator.Narrate("Wood from the roof shifted and fell down, into the heart of the fire. You were sure that the top section of the structure would entirely collapse soon.");
            ProgUtilities.MoveOn();
            aldwin.Speak("Vin, whoever's in there is dead or beyond saving. We're still alive. We need to cherish that fact and put it to good use.");
            ProgUtilities.MoveOn();
            narrator.Narrate("Vin reluctantly nodded.");
            ProgUtilities.MoveOn();
            vin.Speak("Come, let's make haste.");
            ProgUtilities.MoveOn();
            narrator.Narrate("You started back down the same road, leaving the rain to gradually wash away the flesh of the men you had both slain.");
            ProgUtilities.MoveOn();
            narrator.Narrate("What lay ahead was hopefully a warm welcome and a warmer bed.");
            ProgUtilities.MoveOn();
            vin.Speak("ALDWIN!");
            ProgUtilities.MoveOn();
            narrator.Narrate("You saw a second guard tower burning in the distance, and five men before you.");
            ProgUtilities.MoveOn();
            narrator.Narrate("One of them nocked an arrow and two of them drew sowrds. One took out a mace, and the other had just finished stringing his bow to nock an arrow to the string.");
            ProgUtilities.MoveOn();
            Console.Clear();
            narrator.Narrate("This is the end of the game so far. Thanks for playing/testing.");

            ProgUtilities.UpdateGameFlag(objectsInScenario, 3);
        }

    }

}    
