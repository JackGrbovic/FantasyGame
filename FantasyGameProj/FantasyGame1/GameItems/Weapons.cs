using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyGame1.GameItems
{
    public abstract class Weapon : GameItem
    {
        float _DamageToFlesh;
        float _DamageToLightMail;
        float _DamageToLightPlate;
        float _DamageToHeavyMail;
        float _DamageToHeavyPlate;
        float _SpeedDecrease;

        protected Weapon(int iD, int itemTypeID, string name, int price, float damageToFlesh, float damageToLightMail, float damageToLightPlate, float damageToHeavyMail, float damageToHeavyPlate,  float speedDecrease) : base(iD, itemTypeID, name, price)
        {
            _DamageToFlesh = damageToFlesh;
            _DamageToLightMail = damageToLightMail;
            _DamageToLightPlate = damageToLightPlate;
            _DamageToHeavyMail = damageToHeavyMail;
            _DamageToHeavyPlate = damageToHeavyPlate;
            _SpeedDecrease = speedDecrease;
        }
        
        public float DamageToFlesh { get => _DamageToFlesh; set => _DamageToFlesh = value; }
        public float DamageToLightMail { get => _DamageToLightMail; set => _DamageToLightMail = value; }
        public float DamageToLightPlate { get => _DamageToLightPlate; set => _DamageToLightPlate = value; }
        public float DamageToHeavyMail { get => _DamageToHeavyMail; set => _DamageToHeavyMail = value; }
        public float DamageToHeavyPlate { get => _DamageToHeavyPlate; set => _DamageToHeavyPlate = value; }
        public float SpeedDecrease { get => _SpeedDecrease; set => _SpeedDecrease = value; }
    }   
    
    public class Bow : Weapon
    {
        public Bow() : base(2001, 2000, "Bow", 30, 1.5f, 0.8f, 0.7f, 0.4f, 0.3f, 0.2f)
        {
            
        }
    }

    public class Arrow : Weapon
    {
        public Arrow() : base(2011, 2010, "Arrow", 30, 2f, 0.8f, 0.7f, 0.4f, 0.3f, 0.2f)
        {
           
        }
    }

    public class Sword : Weapon
    {
        public Sword() : base(2021, 2020, "Sword", 30, 1.5f, 0.8f, 0.7f, 0.4f, 0.3f, 0.2f)
        {

        }
    }

    public class Spear : Weapon
    {
        public Spear() : base(2031, 2030, "Spear", 30, 1.5f, 0.8f, 0.7f, 0.4f, 0.3f, 0.2f)
        {

        }
    }

    public class Mace : Weapon
    {
        public Mace() : base(2041, 2040, "Mace", 30, 1.5f, 0.8f, 0.7f, 0.4f, 0.3f, 0.2f)
        {

        }
    }
}
