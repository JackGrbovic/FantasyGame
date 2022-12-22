using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyGame1.GameItems
{
    public abstract class Armour : GameItem
    {
        
        float _SpeedDecrease;
        
        Random random = new Random();

        protected Armour(int index, int itemTypeID, string name, int price, float speedDecrease) : base(index, itemTypeID, name, price)
        {
            _SpeedDecrease = speedDecrease;
        }
        
        public float SpeedDecrease { get => _SpeedDecrease; set => _SpeedDecrease = value; }
    }


    class LightMail : Armour
    {
        public LightMail() : base(1001, 1000, "Light Mail", 50, 0.4f)
        {

        }
    }


    class HeavyMail : Armour
    {
        public HeavyMail() : base(1002, 1000, "Heavy Mail", 50, 1.2f)
        {

        }
    }


    class LightPlate : Armour
    {
        public LightPlate() : base(1003, 1000, "Light Plate", 50, 0.4f)
        {

        }
    }


    class HeavyPlate : Armour
    {
        public HeavyPlate() : base(1004, 1000, "Heavy Plate", 50, 1.2f)
        {

        }
    }
}
