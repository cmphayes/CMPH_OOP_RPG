using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class Explore
    {
        List<Potion> WildernessPotions { get; set; }
        public Game Game { get; set; }
        public Hero Hero { get; set; }
        public Monster Monster { get; set; }
        public Potion Potion { get; set; }

        

        public Explore(Hero Hero, Game Game)
        {
            this.WildernessPotions = new List<Potion>();

            this.Hero = Hero;
            this.Game = Game;
            this.Potion = Potion;

            StockWilderness();
        }

        public void Location1()
        {
            Console.WriteLine();
            Console.WriteLine("You enter a swamp.");
            Console.WriteLine();
            Console.WriteLine("A monster attacks.");
            Console.WriteLine();
            var fight = new Fight(Hero, Game);
            fight.Start();
        }
        public void Location2()
        {
            Console.WriteLine();
            Console.WriteLine("You enter a dungeon.");
            Console.WriteLine();
            var potion = (Potion)WildernessPotions[1];
            Hero.PotionsBag.Add(potion);
            Console.WriteLine("You find a potion.");
            Console.WriteLine();
            Start();
        }
        public void Location3()
        {
            Console.WriteLine();
            Console.WriteLine("You are on the road.");
            Console.WriteLine();
            Console.WriteLine("A monster attacks.");
            Console.WriteLine();
            var fight = new Fight(Hero, Game);
            fight.Start();
        }
        public void Location4()
        {
            Console.WriteLine();
            Console.WriteLine("You enter a forest.");
            Console.WriteLine();
            var potion1 = (Potion)WildernessPotions[1];
            Hero.PotionsBag.Add(potion1);
            Console.WriteLine("You find a potion.");
            Console.WriteLine();
            Start();
        }

        public void StockWilderness()
        {
            for (var loop = 1; loop <= 1; loop++)
            {
                this.WildernessPotions.Add(new Potion("Healing Potion", 5));
                this.WildernessPotions.Add(new Potion("Healing Potion+", 10));
                this.WildernessPotions.Add(new Potion("Healing Potion++", 15));
            }

        }

        public void Start()
        {
            Console.WriteLine();
            Console.WriteLine("Which Direction to Explore?");
            Console.WriteLine();
            Console.WriteLine("1.)North");
            Console.WriteLine("2.)South");
            Console.WriteLine("3.)East");
            Console.WriteLine("4.)West");
            Console.WriteLine("5.)View Hero Inventory");
            Console.WriteLine();

            var input = Console.ReadLine();
            if (input == "1")
            {
                this.North();
            }
            else if (input == "2")
            {
                this.South();
            }
            else if (input == "3")
            {
                this.East();
            }
            else if (input == "4")
            {
                this.West();
            }
            else if (input == "5")
            {
                Inventory();
            }
            else
            {
                Game.Main();
            }
        }

        public void North()
        {
            Random Random = new Random();
            switch (Random.Next(1, 5))
            {
                case 1:
                    Location1();
                    break;
                case 2:
                    Location2();
                    break;
                case 3:
                    Location3();
                    break;
                case 4:
                    Location4();
                    break;

            }
        }
        public void South()
        {
            Random Random = new Random();
            switch (Random.Next(1, 5))
            {
                case 1:
                    Location1();
                    break;
                case 2:
                    Location2();
                    break;
                case 3:
                    Location3();
                    break;
                case 4:
                    Location4();
                    break;

            }
        }
        public void East()
        {
            Random Random = new Random();
            switch (Random.Next(1, 5))
            {
                case 1:
                    Location1();
                    break;
                case 2:
                    Location2();
                    break;
                case 3:
                    Location3();
                    break;
                case 4:
                    Location4();
                    break;

            }
        }
        public void West()
        {
            Random Random = new Random();
            switch (Random.Next(1, 5))
            {
                case 1:
                    Location1();
                    break;
                case 2:
                    Location2();
                    break;
                case 3:
                    Location3();
                    break;
                case 4:
                    Location4();
                    break;

            }






        }

        public void Inventory()
        {
            Hero.ShowInventory();
            Console.WriteLine("Press any key to continue exploring");
            Console.ReadKey();
            Start();
        }
    }
}

