using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Game
    {
        public Hero Hero { get; set; }
        public Monster Monster { get; set; }
        
        public Game() {
            this.Hero = new Hero();
        }
            
        public void Start() {
            Console.WriteLine();
            Console.WriteLine("Welcome hero!");
            Console.WriteLine();
            Console.WriteLine("Please enter your name:");
            this.Hero.Name = Console.ReadLine();
            Console.WriteLine("Hello " + Hero.Name);
            Console.WriteLine();
            Console.WriteLine("You begin your adventure in a small village.");
            Console.WriteLine();
            this.Main();
        }
        
        public void Main() {
            Console.WriteLine("What Would You Like To Do?");
            Console.WriteLine();
            Console.WriteLine("1. View Hero Stats");
            Console.WriteLine("2. View Hero Inventory");
            Console.WriteLine("3. Explore");
            Console.WriteLine("4. Go to Shop");
            var input = Console.ReadLine();
            if (input == "1") {
                this.Stats();
            }
            else if (input == "2") {
                this.Inventory();
            }
            else if (input == "3") {
                this.Explore();
            }
            else if (input == "4") {
                this.Shop();
            }
            else { 
                return;
            }
        }
        
        public void Stats()
        {
            Hero.ShowStats();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.Main();
        }
        
        public void Inventory()
        {
            Hero.ShowInventory();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.Main();
        }
        
        public void Fight()
        {
            //var myMonster = new Monster();
            var fight = new Fight(Hero, this);
            fight.Start();
        }

       // public void Explore()
        {
            //var myMonster = new Monster();
            var explore = new Explore (Hero, this);
            explore.Start();
        }

        public void Shop()
        {
            var shop = new Shop(this, Hero);
            shop.Start();
        }


    }
}