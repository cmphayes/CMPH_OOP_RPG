using System;
using System.Linq;
namespace OOP_RPG
{
    public class Potion : IItem {

        public string Name { get; set; }
        public int HP { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Potion() { }

        public Potion(string name, int hp)
        {
            this.Name = name;
            this.HP = hp;
        }

        public Potion(string name, int hp, int originalValue, int resellValue)
        {
            this.Name = name;
            this.HP = hp;
            this.ResellValue = resellValue;
            this.OriginalValue = originalValue;
        }
    }
}

