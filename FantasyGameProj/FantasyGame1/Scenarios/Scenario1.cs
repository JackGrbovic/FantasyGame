using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FantasyGame1.GameFlags;
using FantasyGame1.GameItems;
using System.Linq;
using System.Numerics;

namespace FantasyGame1.Scenarios
{
    class Scenario1
    {
        //add all objects to this list to pass into save method
        public static List<Object> objectsInScenario = new List<Object>();

        public Scenario1(List<Object> itemsToLoad)
        {
            objectsInScenario = itemsToLoad;
        }

        static List<Character> characterList = new List<Character>();
        public static void AddObjectsToScenario1()
        {
            Bow enemyBow = new Bow();
            Enemy enemyArcher = new Enemy("Vemon the Archer", 70, 50, true, 40, 10f, 10, 0.8f, 0.8f, enemyBow, null);
            characterList.Add(enemyArcher);

            Mace enemyMace = new Mace();
            HeavyMail enemyArmour = new HeavyMail();
            Enemy enemyMelee = new Enemy("Drak the Loud", 70, 50, true, 40, 10, 10, 0.8f, 0.8f, enemyMace, null); ;
            characterList.Add(enemyMelee);

            Bow playerWeapon = new Bow();
            Spear playerSpear = new Spear();
            LightMail playerArmour = new LightMail();
            Player player = new Player("Aldwin", 100, 100, true, 50, 10, 10, 1f, 1.1f, playerWeapon, playerArmour);
            player.Inventory.InventoryList.Add(playerSpear);
            characterList.Add(player);

            Sword accompliceSword = new Sword();
            LightPlate accompliceArmour = new LightPlate();
            Accomplice accomplice = new Accomplice("Vin", 100, 100, true, 50, 20, 20, 1f, 10.1f, accompliceSword, accompliceArmour);
            characterList.Add(accomplice);
        }



        public void Launch()
        {
            Intro();
        }

        public static void Intro()
        {
            Narrator narrator = new Narrator("Narrator", 1, 1, true, 1, 1, 1, 1, 1, null, null);
            ProgUtilities.DistributeObjectsInScenario(objectsInScenario, characterList);
            AddObjectsToScenario1();
            Console.WriteLine("Scenario 1 Loaded");
            Thread.Sleep(1000);
            Console.Clear();

            ProgUtilities.WriteText("Use the enter key to progress through text, and number inputs when prompted to make a decision.");
            ProgUtilities.MoveOn();
            Console.Clear();

            narrator.Narrate("At this point, you barely took note of the rain that soaked through your cloak, your clothes and began to intrude into your skin.");
            ProgUtilities.MoveOn();
            narrator.Narrate("Vin walked beside you, his mid length golden hair, darkened and matted by travel, clinging to his face.");
            ProgUtilities.MoveOn();
            narrator.Narrate("Fog drifted in the fields of grass that burst from either side of the mossy ruins of low stone walls that lined parts of the road you walked down.");
            ProgUtilities.MoveOn();
            narrator.Narrate("They extended a couple hundred yards each side. On the left, it was walled off by a big rocky ridge. It rose up, spotted with verdant banks, and gave way to a harsh stone decline on the other side. Green blades of grass and shoots of purple fog bowed their heads to their benevolent and powerful master of the waters that came down upon them.");
            ProgUtilities.MoveOn();
            narrator.Narrate("On the right, the stretch was finished with nothing but air. The field gave way to sloped cliffs that melted into other dunes of grass to be met with more cliffs further down, and more cliffs beyond that.");
            ProgUtilities.MoveOn();
            narrator.Narrate("Something was presenting itself ahead. A watchtower came closer and closer to the both of you. It stood looming in the distance, slowly disrobing from the mist that hung around it.");
            ProgUtilities.MoveOn();
            narrator.Narrate("It was about thirty feet tall atop a peak in the ridge, and had a defined mud and stone trail leading down to meet with the main road.");
            ProgUtilities.MoveOn();
            narrator.Narrate("It rose from its foundations in a square base of stone, all the way to the top, which was tipped with a pointed and sloped timber roof that the rain slid along into strong streams from the corners of the roof, smacking on the ground far below. ");
            ProgUtilities.MoveOn();
            narrator.Narrate("The tower looked down onto the half valley that you and Vin walked. Smoke sifted upward through the gaps in the rain from a dark nest at the top of the stone bricks.");
            ProgUtilities.MoveOn();
            narrator.Narrate("The nest and the arrow slits that line its belly, sides and back, watched you as you walked by.");
            ProgUtilities.MoveOn();
            narrator.Narrate("As you got closer the smoke grew thicker. You started to see flames leaping up, licking at the roof.");
            ProgUtilities.MoveOn();
            narrator.Narrate("You shot a look at Vin, and pulled your bow from its dry bag and strung it. Vin undressed his longsword, zipping it from its scabbard. You nocked an arrow and walked warily forward, darting your eyes around everything before you.");
            ProgUtilities.MoveOn();
            narrator.Narrate("A whip in the air let you know that an arrow missed your face by inches. Immediately you both saw the culprit. He stood just off the road.");
            ProgUtilities.MoveOn();
            narrator.Narrate("Vin held his shield up and you took cover as best you could behind the stone wall. Vin began to approach as a man in a rugged cloak climbed up from the cliff face on the right hand side and began to charge at Vin with his axe held high, screaming as he ran.");


            FightLogic fightLogic = new FightLogic();
            fightLogic.AddCharactersToBattleScenario(characterList);
            for (int i = 0; i < FightLogic.currentFriendliesInBattle.Count; i++)
            {
                if (FightLogic.currentFriendliesInBattle[i] is Player)
                {
                    fightLogic.BattleScenario(FightLogic.currentFriendliesInBattle[i]);
                }
            }

            for (int i = 0; i < objectsInScenario.Count; i++)
            {
                if (objectsInScenario[i] is Character)
                {
                    objectsInScenario.Remove(objectsInScenario[i]);
                }
            }

            objectsInScenario.AddRange(FightLogic.currentFriendliesInBattle);
            ProgUtilities.UpdateGameFlag(objectsInScenario, 2);
            ProgUtilities.PlayerSaveGame(objectsInScenario);
            objectsInScenario.Clear();
            ProgUtilities.LoadChosenSave(ProgUtilities.currentSaveLoaded);
            ProgUtilities.DetermineScenario();
        }

    }
}
