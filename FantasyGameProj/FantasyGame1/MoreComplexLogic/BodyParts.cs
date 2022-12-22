using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyGame1
{
    public abstract class BodyParts
    {
       
    }

    /*static*/class Head
    {
        bool _IsHit;
        public bool IsHit { get => _IsHit; set => _IsHit = value; }
    }

    class Neck
    {
        bool _IsHit;
        public bool IsHit { get => _IsHit; set => _IsHit = value; }
    }

    class Chest
    {
        bool _IsHit;
        public bool IsHit { get => _IsHit; set => _IsHit = value; }
    }

    class Heart
    {
        bool _IsHit;
        public bool IsHit { get => _IsHit; set => _IsHit = value; }
    }

    class LeftArm
    {
        bool _IsHit;
        public bool IsHit { get => _IsHit; set => _IsHit = value; }
    }

    class RightArm
    {
        bool _IsHit;
        public bool IsHit { get => _IsHit; set => _IsHit = value; }
    }

    class LeftLeg
    {
        bool _IsHit;
        public bool IsHit { get => _IsHit; set => _IsHit = value; }
    }

    class RightLeg
    {
        bool _IsHit;
        public bool IsHit { get => _IsHit; set => _IsHit = value; }
    }



    //bodypart logic may go here, if statements for what happens when each one is hit etc
    //neck has a chance of decapitation for swords etc
}
