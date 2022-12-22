using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyGame1.GameItems
{
    public class GameItemManager
    {
        private int _CurrentID;

        public GameItemManager()
        {
            this._CurrentID = 0;
        }

        public int FetchNextID()
        {
            _CurrentID++;
            return _CurrentID;
        }
    }
}
