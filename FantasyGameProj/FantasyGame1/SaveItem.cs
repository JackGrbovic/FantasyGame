using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyGame1
{
    class SaveItem
    {
        private string _ClassName;
        private object _Data;

        public string ClassName { get => _ClassName; set => _ClassName = value; }
        public object Data { get => _Data; set => _Data = value; } 
        

        public SaveItem(object data)
        {
            _Data = data;
            _ClassName = data.GetType().ToString();
        }
    }
}
