using System;
using System.Collections.Generic;
using System.Text;
using FantasyGame1.GameItems;

namespace FantasyGame1
{
    public abstract class Character
    {
        private string _Name;
        private int _MaxHealth;
        private int _Health;
        private bool _IsAlive;
        private int _Money;
        private float _PhysicalDamage;
        private float _PhysicalDefense;
        private float _Speed;
        private float _Accuracy;
        private Armour _EquippedArmour;
        private Weapon _EquippedWeapon;
        private Weapon _SecondaryWeapon;
        private Inventory _Inventory;
        private Character _CurrentTarget;



        //private int _SwordSkill;
        //private int _SpearSkill;

        protected Character(string name, int maxHealth, int health, bool isAlive, int money, float physicalDamage, float physicalDefense, float accuracy, float speed, Weapon equippedWeapon, Armour equippedArmour)
        {
            _Name = name;
            _MaxHealth = maxHealth;
            _Health = health;
            _IsAlive = isAlive;
            _Money = money;
            _PhysicalDamage = physicalDamage;
            _PhysicalDefense = physicalDefense;
            _Accuracy = accuracy;
            _Speed = speed;
            _Inventory = new Inventory();
            _EquippedWeapon = equippedWeapon;
            _EquippedArmour = equippedArmour;
        }

        public string Name { get => _Name; set => _Name = value; } 
        public int MaxHealth { get => _MaxHealth; set => _MaxHealth = value; }
        public int Health { get => _Health; set => _Health = value; }
        public bool IsAlive { get => _IsAlive; set => _IsAlive = value; }
        public int Money { get => _Money; set => _Money = value; }
        public float PhysicalDamage { get => _PhysicalDamage; set => _PhysicalDamage = value; }
        public float PhysicalDefense { get => _PhysicalDefense; set => _PhysicalDefense = value; }
        public float Speed { get => _Speed; set => _Speed = value; }
        public Inventory Inventory { get => _Inventory; }
        public float Accuracy { get => _Accuracy; set => _Accuracy = value; }
        public Armour EquippedArmour { get => _EquippedArmour; set => _EquippedArmour = value; }
        public Weapon EquippedWeapon { get => _EquippedWeapon; set => _EquippedWeapon = value; }
        public Character CurrentTarget { get => _CurrentTarget; set => _CurrentTarget = value; }
        public Weapon SecondaryWeapon { get => _SecondaryWeapon; set => _SecondaryWeapon = value; }




        public static float AffectedAttributeValue;
        public float AffectedPhysicalDamage;
        public float AffectedPhysicalDefense;
        public float AffectedSpeed;
        public float AffectedAccuracy;


        public static void AttributeAffector(float passedInValue)
        {
            while (true)
            {
                Random random = new Random();
                double val = random.NextDouble();
                if (val > 0.6)
                {
                    float newVal = (float)(passedInValue * val);
                    AffectedAttributeValue = (float)newVal;
                    return;
                }
            }
        }


        public static void AffectAttributes(Character pCharacter)
        {
            AttributeAffector(pCharacter.PhysicalDamage);
            pCharacter.AffectedPhysicalDamage = AffectedAttributeValue;
            AttributeAffector(pCharacter.PhysicalDefense);
            pCharacter.AffectedPhysicalDefense = AffectedAttributeValue;
            AttributeAffector(pCharacter.Speed);
            pCharacter.AffectedSpeed = AffectedAttributeValue;
            AttributeAffector(pCharacter.Accuracy);
            pCharacter.AffectedAccuracy = AffectedAttributeValue;
        }


        public void Speak(string speech)
        {
            string colour = null;
            if (this.GetType() == typeof(Player))
            {
                colour = "DarkGreen";
            }
            else if (this.GetType() == typeof(Accomplice))
            {
                colour = "Cyan";
            }            

            ProgUtilities.WriteTextWithSkip(Name + ": " + speech, colour);
        }




        public void Heal(int amountToHealBy)
        {
            _Health += amountToHealBy;

            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }


        public void TakeDamage(int damageToTake)
        {
            _Health -= damageToTake;
        }


   
    }


    public class Player : Character
    {
        //attacks will be made if the dice roll is higher than the stat
        public Player(string name, int maxHealth, int health, bool isAlive, int money, float physicalDamage, float physicalDefense, float accuracy, float speed, Weapon equippedWeapon, Armour equippedArmour) : base(name, maxHealth, health, isAlive, money, physicalDamage, physicalDefense,  accuracy, speed, equippedWeapon, equippedArmour)
        {

        }


        public void CheckInventory()
        {

        }

        public void OpenMenu()
        {

        }
    }

    public abstract class NPC : Character
    {
        public NPC(string name, int maxHealth, int health, bool isAlive, int money, float physicalDamage, float physicalDefense, float accuracy, float speed, Weapon equippedWeapon, Armour equippedArmour) : base(name, maxHealth, health, isAlive, money, physicalDamage, physicalDefense, accuracy, speed, equippedWeapon, equippedArmour)
        {

        }

        public void DropMoney(Player pPlayer)
        {
            pPlayer.Money += this.Money;
        }
    }

    public class Enemy : NPC
    {
        int TargetSelectIndex;
        public Enemy(string name, int maxHealth, int health, bool isAlive, int money, float physicalDamage, float physicalDefense, float accuracy, float speed, Weapon equippedWeapon, Armour equippedArmour) : base(name, maxHealth, health, isAlive, money, physicalDamage, physicalDefense, accuracy, speed, equippedWeapon, equippedArmour)
        {

        }
    }

    public class Narrator : NPC
    {
        public Narrator(string name, int maxHealth, int health, bool isAlive, int money, float physicalDamage, float physicalDefense, float accuracy, float speed, Weapon equippedWeapon, Armour equippedArmour) : base(name, maxHealth, health, isAlive, money, physicalDamage, physicalDefense, accuracy, speed, equippedWeapon, equippedArmour)
        {

        }

        public void Narrate(string speech)
        {
            ProgUtilities.WriteTextWithSkip(speech, "Yellow");
        }
    }

    public class Accomplice : NPC
    {
        public Accomplice(string name, int maxHealth, int health, bool isAlive, int money, float physicalDamage, float physicalDefense, float accuracy, float speed, Weapon equippedWeapon, Armour equippedArmour) : base(name, maxHealth, health, isAlive, money, physicalDamage, physicalDefense, accuracy, speed, equippedWeapon, equippedArmour)
        {

        }
    }

    public class Neutral : NPC
    {
        public Neutral(string name, int maxHealth, int health, bool isAlive, int money, float physicalDamage, float physicalDefense, float accuracy, float speed, Weapon equippedWeapon, Armour equippedArmour) : base(name, maxHealth, health, isAlive, money, physicalDamage, physicalDefense, accuracy, speed, equippedWeapon, equippedArmour)
        {

        }
    }
}
