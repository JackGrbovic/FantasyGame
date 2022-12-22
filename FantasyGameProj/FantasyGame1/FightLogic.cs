using System;
using System.Collections.Generic;
using System.Text;
using FantasyGame1.GameItems;
using System.Linq;
using System.Collections.ObjectModel;
using FantasyGame1.Scenarios;
using System.Data;

namespace FantasyGame1
{
    public class FightLogic
    {
        Random random = new Random();
        public static List<Character> currentEnemiesInBattle = new List<Character>();
        public static List<Character> currentFriendliesInBattle = new List<Character>();

        public void AddCharactersToBattleScenario(List<Character> charactersToAdd)
        {
            foreach (Character pCharacter in charactersToAdd)
            {
                if (pCharacter is Enemy)
                {
                    currentEnemiesInBattle.Add(pCharacter);
                }
                if (pCharacter is Accomplice | pCharacter is Player)
                {
                    currentFriendliesInBattle.Add(pCharacter);
                }
            }
        }

        
        public void BattleScenario(Character pPlayer)
        {
            bool battleOn = true;
            while (battleOn == true)
            {
                ProgUtilities.WriteText("What will you do?");
                SetMoves(pPlayer);
                char playerMoveInput = DisplayAndSelectMove(pPlayer as Player);
                WhoGoesFirst();
                Character e;
                for (int i = 0; i < orderOfMoves.Count; i++)
                {
                    e = orderOfMoves[i];

                    if (e is Enemy | e is Accomplice)
                    {
                        NPCSelectTarget(e);
                    }

                    if (e is Player & e.CurrentTarget == null)
                    {
                        ReassignTarget(e);
                    }
                    if (e is Player & e.CurrentTarget.IsAlive == false)
                    {
                        ReassignTarget(e);
                    }

                    if (e.CurrentTarget.IsAlive == true)
                    {
                        SetActionText(e);
                        if (e is Player)
                        {
                            ExecuteMove(e, playerMoveInput);
                        }
                        else
                        {
                            ExecuteMove(e);
                        }
                    }
                    LiveOrDie(e);

                }
                ClearOrderList();

                if (currentEnemiesInBattle.Count > 0)
                {
                    battleOn = true;
                }
                else
                {
                    battleOn = false;
                    ProgUtilities.WriteText("You did it, you won the fight!");
                    for (int i = 0; i < currentFriendliesInBattle.Count; i++)
                    {
                        currentFriendliesInBattle[i].CurrentTarget = null;
                    }
                }
                for (int i = 0; i < currentFriendliesInBattle.Count; i++)
                {
                    if (currentFriendliesInBattle[i].IsAlive == false)
                    {
                        battleOn = false;
                        ProgUtilities.WriteText("One of you died, and neither can finish this long journey alone.");
                        ProgUtilities.LaunchGame();
                    }
                }
            }
        }


        public void LiveOrDie(Character pCharacter)
        {
            if (pCharacter.CurrentTarget.IsAlive == true)
            {
                if (pCharacter.CurrentTarget.Health < 1)
                {
                    pCharacter.CurrentTarget.IsAlive = false;
                    ProgUtilities.WriteText(pCharacter.CurrentTarget.Name + " died.");
                    orderOfMoves.Remove(pCharacter.CurrentTarget);
                    currentEnemiesInBattle.Remove(pCharacter.CurrentTarget);
                }
            }
        }


        public void ReassignTarget(Character pCharacter)
        {
            if (pCharacter is Enemy)
            {
                if (pCharacter.CurrentTarget.Health < 1)
                {
                    foreach (Character friendly in orderOfMoves)
                    {
                        if (friendly is Accomplice | friendly is Player)
                        {
                            pCharacter.CurrentTarget = friendly;
                            return;
                        }
                    }
                }
            }

            if (pCharacter is Accomplice | pCharacter is Player)
            {
                if (orderOfMoves.Count > 2 & orderOfMoves.Count < 5)
                {
                    if (pCharacter.CurrentTarget == null)
                    {
                        foreach (Character enemy in orderOfMoves)
                        {
                            if (enemy is Enemy)
                            {
                                pCharacter.CurrentTarget = enemy;
                                return;
                            }
                        }
                    }
                }
            }

            if (pCharacter is Accomplice | pCharacter is Player)
            {
                if (orderOfMoves.Count > 2 & orderOfMoves.Count < 4)
                {
                    if (pCharacter.CurrentTarget.IsAlive == false)
                    {
                        foreach (Character enemy in orderOfMoves)
                        {
                            if (enemy is Enemy)
                            {
                                pCharacter.CurrentTarget = enemy;
                                return;
                            }
                        }
                    }
                }
            }
        }





        public void PlayerSelectTarget(Character pPlayer)
        {
            for (int i = 0; i < currentEnemiesInBattle.Count; i ++)
            {
                ProgUtilities.WriteText(i + 1 + ". " + currentEnemiesInBattle[i].Name);
            }

            char targetInput = Console.ReadKey().KeyChar;
            switch (targetInput)
            {
                case '1':
                    pPlayer.CurrentTarget = currentEnemiesInBattle[0];
                        break;
                case '2':
                    pPlayer.CurrentTarget = currentEnemiesInBattle[1];
                    break;
            }
            Console.WriteLine();
        }


        public void NPCSelectTarget(Character targetSelector)
        {
            if (targetSelector is Enemy)
            {
                if (currentFriendliesInBattle.Count < 2)
                {
                    targetSelector.CurrentTarget = currentFriendliesInBattle[0];
                }
                else
                {
                    int randomNo = random.Next(1, 11);
                    if (randomNo > 5)
                    {
                        targetSelector.CurrentTarget = currentFriendliesInBattle[0];
                    }
                    else
                    {
                        targetSelector.CurrentTarget = currentFriendliesInBattle[1];
                    }
                }
            }
            else
            {
                if (currentEnemiesInBattle.Count < 2)
                {
                    if (currentEnemiesInBattle.Count > 0)
                    {
                        targetSelector.CurrentTarget = currentEnemiesInBattle[0];
                    }
                    else return;
                }
                else
                {
                    int randomNo = random.Next(1, 11);
                    if (randomNo > 5)
                    {
                        targetSelector.CurrentTarget = currentEnemiesInBattle[0];
                    }
                    else
                    {
                        targetSelector.CurrentTarget = currentEnemiesInBattle[0];
                    }
                }
            }
            
        }

    
        
        string playerOption1;
        string playerOption2;
        public void SetMoves(Character pAttacker)
        {
            if (pAttacker.EquippedWeapon.ItemTypeID == 2000) 
            {
                playerOption1 = "Nock and loose.";
            }
            if (pAttacker.EquippedWeapon.ItemTypeID == 2020)
            {
                playerOption1 = "Slash and stab.";
            }
            if (pAttacker.EquippedWeapon.ItemTypeID == 2030)
            {
                playerOption1 = "Feint and lunge.";
            }
            if (pAttacker.EquippedWeapon.ItemTypeID == 2040)
            {
                playerOption1 = "Bash and swing.";
            }
            for (int i = 0; i < pAttacker.Inventory.InventoryList.Count; i++)
            {
                if (pAttacker.Inventory.InventoryList[i] is Weapon)
                {
                    playerOption2 = "Switch to " + pAttacker.Inventory.InventoryList[i].Name + ".";
                }
            }
            
        }

        public char DisplayAndSelectMove(Player pPlayer)
        {
            ProgUtilities.WriteText("1. " + playerOption1);
            ProgUtilities.WriteText("2. " + playerOption2);
            char playerMoveInput = Console.ReadKey().KeyChar;

            if (playerMoveInput == '1')
            {
                PlayerSelectTarget(pPlayer);
            }
            if (playerMoveInput == '2')
            {
                pPlayer.CurrentTarget = null;
            }
            return playerMoveInput;
        }






        int weaponToSwitchToIndex;
        string action;
        public void SetActionText(Character pAttacker)
        {
            if (pAttacker.CurrentTarget != null)
            {
                if (pAttacker.EquippedWeapon.ItemTypeID == 2000)
                {
                    action = pAttacker.Name + " nocked an arrow and loosed it at " + pAttacker.CurrentTarget.Name + ".";
                }
                if (pAttacker.EquippedWeapon.ItemTypeID == 2020)
                {
                    action = pAttacker.Name + " stabbed and slashed at " + pAttacker.CurrentTarget.Name + ".";
                }
                if (pAttacker.EquippedWeapon.ItemTypeID == 2030)
                {
                    action = pAttacker.Name + " feinted and lunged at " + pAttacker.CurrentTarget.Name + ".";
                }
                if (pAttacker.EquippedWeapon.ItemTypeID == 2040)
                {
                    action = pAttacker.Name + " bashed and swung at " + pAttacker.CurrentTarget.Name + ".";
                }
            }
        }







        public void ExecuteMove(Character pAttacker, char playerMoveInput = '1')
        {
            if (pAttacker is Accomplice | pAttacker is Enemy)
            {
                ProgUtilities.WriteText(action);
                MakeAttack(pAttacker, pAttacker.CurrentTarget);
            }

            if (pAttacker is Player)
            {
                switch (playerMoveInput)
                {
                    case '1':
                        ProgUtilities.WriteText(action);
                        MakeAttack(pAttacker, pAttacker.CurrentTarget);
                        break;

                    case '2':
                        for (int i = 0; i < pAttacker.Inventory.InventoryList.Count; i++)
                        {
                            if (pAttacker.Inventory.InventoryList[i] is Weapon)
                            {
                                action = pAttacker.Name + " switched weapons to " + pAttacker.Inventory.InventoryList[i].Name + ".";
                                break;
                            }
                        }
                        ProgUtilities.WriteText(action);
                        SwitchWeapons(pAttacker);
                        break;
                }
            }
            
        }





        public void SwitchWeapons(Character pCharacter)
        {
            pCharacter.Inventory.InventoryList.Insert(0, pCharacter.EquippedWeapon);
            pCharacter.EquippedWeapon = (Weapon)pCharacter.Inventory.InventoryList[weaponToSwitchToIndex + 1];
            pCharacter.Inventory.InventoryList.Remove(pCharacter.Inventory.InventoryList[weaponToSwitchToIndex + 1]);
        }





        List<Character> orderOfMoves = new List<Character>();
        public void WhoGoesFirst()
        {
            Queue<Character> candidatesToSort = new Queue<Character>();
            Character e = null;
            foreach (Enemy enemy in currentEnemiesInBattle)
            {
                e = null;
                e = orderOfMoves.Where(x => x.Name == enemy.Name).FirstOrDefault();
                if (e == null)
                    orderOfMoves.Add(enemy);
            }

            foreach (Character friendly in currentFriendliesInBattle)
            {
                e = null;
                e = orderOfMoves.Where(x => x.Name == friendly.Name).FirstOrDefault();
                if (e == null)
                    orderOfMoves.Add(friendly);
            }

            //Marked for SOC
            foreach (Character pCharacter in orderOfMoves)
            {
                Character.AffectAttributes(pCharacter);
            }

            orderOfMoves = orderOfMoves.OrderByDescending(x => x.AffectedSpeed).ToList();
            #region
            //int falseCount = 0;
            //bool? iIsTheFastest = null;

            //while (orderOfMoves.Count > 0)
            //{
            //    for (int i = 0; i < orderOfMoves.Count; i++)
            //    {
            //        for (int j = 0; j < orderOfMoves.Count; j++)
            //        {
            //            if (orderOfMoves[i].AffectedSpeed >= orderOfMoves[j].AffectedSpeed)
            //            {
            //                iIsTheFastest = true;
            //            }
            //            else
            //            {
            //                falseCount++;
            //            }
            //        }

            //        if (falseCount > 0)
            //        {
            //            iIsTheFastest = false;
            //        }

            //        if (iIsTheFastest == true)
            //        {
            //            candidatesToSort.Enqueue(orderOfMoves[i]);
            //            iIsTheFastest = null;
            //            orderOfMoves.Remove(orderOfMoves[i]);
            //        }
            //        falseCount = 0;
            //    }
            //}

            //foreach (Character character in candidatesToSort)
            //{
            //    orderOfMoves.Add(character);
            //}
            #endregion
        }



        public void ClearOrderList()
        {
            orderOfMoves.Clear();
        }




        
        public void MakeAttack(Character pAttacker, Character pDefender)
        {
            
            int damageDealt;
            bool successfulHit;

            if (pAttacker.AffectedAccuracy > 0.25f)
            {
                successfulHit = true;
                if (successfulHit && pAttacker.CurrentTarget != null)
                {
                    Console.Write(pAttacker.Name + " landed their attack");
                    if (pDefender.EquippedArmour is LightMail)
                    {
                        damageDealt = (int)(pAttacker.AffectedPhysicalDamage * pAttacker.EquippedWeapon.DamageToLightMail);
                        pDefender.Health -= damageDealt;
                    }
                    else if (pDefender.EquippedArmour is HeavyMail)
                    {
                        damageDealt = (int)(pAttacker.AffectedPhysicalDamage * pAttacker.EquippedWeapon.DamageToHeavyPlate);
                        pDefender.Health -= damageDealt;
                    }
                    else if (pDefender.EquippedArmour is LightPlate)
                    {
                        damageDealt = (int)(pAttacker.AffectedPhysicalDamage * pAttacker.EquippedWeapon.DamageToLightPlate);
                        pDefender.Health -= damageDealt;
                    }
                    else if (pDefender.EquippedArmour is HeavyPlate)
                    {
                        damageDealt = (int)(pAttacker.AffectedPhysicalDamage * pAttacker.EquippedWeapon.DamageToHeavyPlate);
                        pDefender.Health -= damageDealt;
                    }
                    else
                    {
                        damageDealt = (int)(pAttacker.AffectedPhysicalDamage * pAttacker.EquippedWeapon.DamageToFlesh);
                        pDefender.Health -= damageDealt;
                    }
                    ProgUtilities.WriteText(" and hit " + pDefender.Name + " for " + damageDealt + " points of damage!");
                }
                
                else if (successfulHit == false)
                {
                    ProgUtilities.WriteText($"{pAttacker.Name} missed their attack!");
                }
                Console.ReadLine();
            }
        }

        
        
        //--- These willnot be used in simple version of game---//
        
        //public void CalculateFatigue(Character pAttacker, Armour pAttackerEquippedArmour, Weapon pCharacterEquippedWeapon)
        //{

        //}


        //public void PresentOptions()
        //{
        //    //This will present the options you have available to you in the battle
        //}


        //public void BlockAttack()
        //{

        //}


        //public void ParryAttack()
        //{

        //}


    }
}
