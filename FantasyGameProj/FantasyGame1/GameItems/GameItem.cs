using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyGame1.GameItems
{
    
    //This class has several properties. ItemID will assign aunique value to each type of item
    //for example we'll have LongSword be 1001 and ShortSword be 1002
    //in this class we have a constructor
    public class GameItem
    {
        private int _Index;
        private int _ItemTypeID;
        private string _Name;
        private int _Price;

        public GameItem(int index, int itemTypeID, string name, int price)
        {
            _Index = index;
            _ItemTypeID = itemTypeID;
            _Name = name;
            _Price = price;
        }

        public int ID { get => _Index; }
        public int ItemTypeID { get => _ItemTypeID; set => _ItemTypeID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public int Price { get => _Price; set => _Price = value; }
    }
}
