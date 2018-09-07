using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {
        List<Monster> MonstersList { get; set; }
        List<Weapon> LootWeaponList { get; set; }
        List<Potion> LootPotionList { get; set; }
        List<Armor> LootArmorList { get; set; }

        public Game Game { get; set; }
        public Hero Hero { get; set; }
        public Monster Monster { get; set; }
        public Armor Armor { get; set; }
        public Potion Potion { get; set; }
        public Weapon Weapon { get; set; }

        public Fight(Hero Hero, Game Game)
        {
            this.MonstersList = new List<Monster>();
            this.LootWeaponList = new List<Weapon>();
            this.LootPotionList = new List<Potion>();
            this.LootArmorList = new List<Armor>();

            this.Monster = new Monster();
            this.Hero = Hero;
            this.Game = Game;

            StockMonsters();
            StockWeaponLoot();
            StockArmorLoot();
            StockPotionsLoot();
        }
        
        public void StockMonsters()
        {
            for (var loop = 1; loop <= 3; loop++)
            {
                this.MonstersList.Add(new Monster("Wolf", 9, 8, 20, 5));
                this.MonstersList.Add(new Monster("Goblin", 10, 10, 10, 10));
                this.MonstersList.Add(new Monster("Ghost", 5, 2, 1, 15));
                this.MonstersList.Add(new Monster("Ghoul", 15, 15, 8, 20));
                this.MonstersList.Add(new Monster("Zombie", 15, 15, 8, 21));
            }
        }

        private void StockWeaponLoot()
        {
            for (var loop = 1; loop <= 1; loop++)
            {
                this.LootWeaponList.Add(new Weapon("Sword", 10, 2, 3));
                this.LootWeaponList.Add(new Weapon("Axe", 12, 3, 4));
                this.LootWeaponList.Add(new Weapon("LongSword", 20, 5, 7));                
            }
        }

        private void StockArmorLoot()
        {
            for (var loop = 1; loop <= 1; loop++)
            {
                this.LootArmorList.Add(new Armor("WoodenArmor", 10, 2, 3));
                this.LootArmorList.Add(new Armor("MetalPotion", 20, 5, 7));
            }
        }

        private void StockPotionsLoot()
        {
            for (var loop = 1; loop <= 1; loop++)
            {
                this.LootPotionList.Add(new Potion("Healing Potion", 5));
                this.LootPotionList.Add(new Potion("Healing Potion+", 10));
                this.LootPotionList.Add(new Potion("Healing Potion++", 15));
            }
        }

        public void Start() {
            //This is how we are fighting the first monster in the list
            //var Monster = this.Monsters[0];

            //This is how we are fighting th last monster
            // var Monster = this.Monsters[this.Monsters.Count -1];

            //Fight first monster with less than 20 hp
            //var Monster = this.Monsters.FirstOrDefault(m => m.currentHP < 20);

            //Fight first monster with str of at least 11
            //var Monster = this.MonstersList.FirstOrDefault(m => m.Strength >= 11);

            //Fight random monster
            //var Monster = this.MonstersList[Random.Next(0, this.MonstersList.Count)];
            //this.Monster = this.Monsters[random.Next(0, this.Monsters.Count)];
            Random RandomMonster = new Random();
            var Monster = (Monster)MonstersList[RandomMonster.Next(MonstersList.Count)];



            Console.WriteLine("You've encountered a " + Monster.Name + "! " + Monster.Strength + " Strength/" + Monster.Defense + " Defense/" +
            Monster.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Run");

            var input = Console.ReadLine();
            if (input == "1") {
                this.HeroTurn();
            }
            else { 
                this.Game.Main();
            }
        }
        
        public void HeroTurn()
        {
           var compare = Hero.Strength - Monster.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
               this.Monster.CurrentHP -= damage;
           }
           else{
               damage = compare;
               this.Monster.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(this.Monster.CurrentHP <= 0){
               this.Win();
           }
           else
           {
               this.MonsterTurn();
           }
           
        }
        
        public void MonsterTurn(){
           var Monster = this.Monster;
           int damage;
           var compare = Monster.Strength - Hero.Defense;
           if(compare <= 0) {
               damage = 1;
               Hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               Hero.CurrentHP -= damage;
           }
           Console.WriteLine(Monster.Name + " does " + damage + " damage!");
           if(Hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win() {
            var Monster = this.Monster;
            Console.WriteLine($"{Monster.Name} has been defeated! You win the battle!");
            this.Hero.Gold += this.Monster.Gold;
            Random Random = new Random();
            switch (Random.Next(0, 5))
            {
                case 1:
                    Random PotionDrop = new Random();
                    var potion = (Potion)LootPotionList[PotionDrop.Next(LootPotionList.Count)];
                    Hero.PotionsBag.Add(Potion);
                    Console.WriteLine($"You found a {potion.Name}");
                    break;

                case 2:
                    Random WeaponDrop = new Random();
                    var weapon = (Weapon)LootWeaponList[WeaponDrop.Next(LootWeaponList.Count)];
                    Hero.WeaponsBag.Add(Weapon);
                    Console.WriteLine($"You found a {weapon.Name}");
                    break;

                case 3:
                    Random ArmorDrop = new Random();
                    var armor = (Armor)LootArmorList[ArmorDrop.Next(LootArmorList.Count)];
                    Hero.ArmorsBag.Add(Armor);
                    Console.WriteLine($"You found a {armor.Name}");
                    break;

                case 4:
                    Console.WriteLine("You loot nothing of value.");
                    break;


            }
            Console.WriteLine($"You win {this.Monster.Gold} gold");
            Console.WriteLine($"Your gold is now {this.Hero.Gold}");
            Hero.Gold += Monster.Gold;

            var explore = new Explore(Hero, Game);
            explore.Start();
        }
        
        public void Lose() {
            Console.WriteLine("You pass out in the wilderness but wake up back in town.");
            Game.Main();
        }


        
    }
    
}