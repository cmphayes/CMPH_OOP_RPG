using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Gold { get; set; }

        public Monster() { }

        public Monster(string Name, int Strength, int Defense, int HP, int Gold)
        {
            this.Name = Name;
            this.Strength = Strength;
            this.Defense = Defense;
            this.OriginalHP = HP;
            this.CurrentHP = HP;
            this.Gold = Gold;
                       
        }


    }
    
}