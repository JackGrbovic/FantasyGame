using System;
using System.Collections.Generic;
using System.Text;
using FantasyGame1.GameItems;
using System.Linq;

namespace FantasyGame1
{
    public class Inventory
    {
        private List<GameItem> _InventoryList;

        public Inventory()
        {
            _InventoryList = new List<GameItem>();
        }

        public List<GameItem> InventoryList { get => _InventoryList; }

        public List<Weapon> GetWeapons()
        {
            return _InventoryList.OfType<Weapon>().ToList();
        }
    }
}
