using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shop
    {
        List<Potion> PotionsList { get; set; }
        List<Weapon> WeaponsList { get; set; }
        List<Armor> ArmorList { get; set; }
        public Game Game { get; set; }
        public Hero Hero { get; set; }
        public Armor Armor { get; set; }
        public Potion Potion { get; set; }
        public Weapon Weapon { get; set; }
        public int ShopGold { get; set; }


        public Dictionary<string, object> ItemCatalog { get; set; }
        public Dictionary<string, object> HeroItems { get; set; }

        public Shop(Game game, Hero Hero)
        {
            this.PotionsList = new List<Potion>();
            this.WeaponsList = new List<Weapon>();
            this.ArmorList = new List<Armor>();
            this.Hero = Hero;
            this.Game = game;
            this.ItemCatalog = new Dictionary<string, object>();
            this.HeroItems = new Dictionary<string, object>();
            this.ShopGold = 1000;


            StockShop();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to my shop! What would you like to do?");
            Console.WriteLine("1. Buy Item");
            Console.WriteLine("2. Sell Item");
            Console.WriteLine("3. Leave Store");
            var input = Console.ReadLine();
            if (input == "1")
            {
                this.BuyItem();
            }
            else if (input == "2")
            {
                this.SellItem();
            }
            else if (input == "3")
            {
                this.Game.Main();
            }
        }

        private void StockShop()
        {
            for (var loop = 1; loop <= 1; loop++)
            {
                this.PotionsList.Add(new Potion("Healing Potion", 5));
                this.PotionsList.Add(new Potion("Healing Potion+", 10));
                this.PotionsList.Add(new Potion("Healing Potion++", 15));

                this.WeaponsList.Add(new Weapon("Sword", 10, 2, 3));
                this.WeaponsList.Add(new Weapon("Axe", 12, 3, 4));
                this.WeaponsList.Add(new Weapon("LongSword", 20, 5, 7));

                this.ArmorList.Add(new Armor("WoodenArmor", 10, 2, 3));
                this.ArmorList.Add(new Armor("MetalArmor", 20, 5, 7));
            }
        }

        public void ShowShopInventory()
        {

            ItemCatalog.Clear();

            ListWeapons();
            ListArmors();
            ListPotions();
        }

        public void ShowHeroInventory()
        {

            HeroItems.Clear();

            ListHeroWeapons();
            ListHeroArmors();
            ListHeroPotions();
        }

        public void BuyItem()
        {
            ShowShopInventory();

            var itemDictNum = ("");
            Console.Write("Enter the code of the item you would like to purchase.");
            itemDictNum = Console.ReadLine();

            if (ItemCatalog.ContainsKey(itemDictNum))
            {
                CheckOut(itemDictNum);
            }
            else if (!ItemCatalog.ContainsKey(itemDictNum))
            {
                Console.WriteLine("Please Enter a Valid Code.");
                Start();
            }


        }

        public void CheckOut(string itemDictNum)
        {
            switch (itemDictNum.Substring(0, 1))
            {
                case "a":
                    var armor = (Armor)ItemCatalog[itemDictNum];

                    if (Hero.Gold >= armor.OriginalValue)
                    {
                        Hero.Gold -= armor.OriginalValue;
                        ArmorList.Remove(armor);
                        Hero.ArmorsBag.Add(armor);
                        Console.WriteLine($"You bought a {armor.Name} for {armor.OriginalValue} gold");
                        Start();

                    }
                    else
                    {
                        Console.WriteLine($"You do not have enough gold to purchase {armor.Name}");
                        Start();
                    }

                    break;

                case "p":
                    var potion = (Potion)ItemCatalog[itemDictNum];

                    if (Hero.Gold >= potion.OriginalValue)
                    {
                        Hero.Gold -= potion.OriginalValue;
                        PotionsList.Remove(potion);
                        Hero.PotionsBag.Add(potion);
                        Console.WriteLine($"You bought a {potion.Name} for {potion.OriginalValue} gold");
                        Start();


                    }
                    else
                    {
                        Console.WriteLine($"You do not have enough gold to purchase {potion.Name}");
                        Start();
                    }

                    break;

                case "w":
                    var weapon = (Weapon)ItemCatalog[itemDictNum];

                    if (Hero.Gold >= weapon.OriginalValue)
                    {
                        Hero.Gold -= weapon.OriginalValue;
                        WeaponsList.Remove(weapon);
                        Hero.WeaponsBag.Add(weapon);
                        Console.WriteLine($"You bought a {weapon.Name} for {weapon.OriginalValue} gold");
                        Start();

                    }
                    else
                    {
                        Console.WriteLine($"You do not have enough gold to purchase {weapon.Name}");
                        Start();
                    }

                    break;
            }
        }

        public void SellItem()
        {
            ShowHeroInventory();

            var heroItemNum = "";
            Console.Write("Enter the code of the item you would like to sell.");
            heroItemNum = Console.ReadLine();

            if (HeroItems.ContainsKey(heroItemNum))
            {
                switch (heroItemNum.Substring(0, 1))
                {
                    case "a":
                        var armor = (Armor)HeroItems[heroItemNum];

                        if (ShopGold >= armor.ResellValue)
                        {
                            Hero.Gold += armor.ResellValue;
                            Hero.ArmorsBag.Remove(armor);
                            this.ArmorList.Add(armor);
                            Console.WriteLine($"You sold a {armor.Name} for {armor.ResellValue} gold");
                            Start();
                        }
                        else
                        {
                            Console.WriteLine($"Shop does not have enough gold to purchase {armor.Name}");
                            Start();
                        }
                        break;

                    case "p":
                        var potion = (Potion)HeroItems[heroItemNum];

                        if (ShopGold >= potion.ResellValue)
                        {
                            Hero.Gold += potion.ResellValue;
                            Hero.PotionsBag.Remove(potion);
                            this.PotionsList.Add(potion);
                            Console.WriteLine($"You sold a {potion.Name} for {potion.ResellValue} gold");
                            Start();
                        }
                        else
                        {
                            Console.WriteLine($"Shop does not have enough gold to purchase {potion.Name}");
                            Start();
                        }
                        break;

                    case "w":
                        var weapon = (Weapon)HeroItems[heroItemNum];

                        if (ShopGold >= weapon.ResellValue)
                        {
                            Hero.Gold += weapon.ResellValue;
                            Hero.WeaponsBag.Remove(weapon);
                            this.WeaponsList.Add(weapon);
                            Console.WriteLine($"You sold a {weapon.Name} for {weapon.ResellValue} gold");
                            Start();
                        }
                        else
                        {
                            Console.WriteLine($"Shop does not have enough gold to purchase {weapon.Name}");
                            Start();
                        }
                        break;
                }
            }
            else if (!ItemCatalog.ContainsKey(heroItemNum))
            {
                Console.WriteLine("Please Enter a Valid Code");
                Start();
            }


        }

        public void ListWeapons()
        {
            Console.WriteLine("Weapons:");
            var count = 1;
            foreach (var weapon in WeaponsList.OrderBy(w => w.OriginalValue))
            {
                Console.WriteLine($"w{count}. {weapon.Name} - Original Value: {weapon.OriginalValue}, Resell Value: {weapon.ResellValue}");
                ItemCatalog.Add($"w{count}", weapon);
                count++;
            }
            Console.WriteLine();
        }

        public void ListArmors()
        {
            Console.WriteLine("Armors:");
            var count = 1;
            foreach (var armor in ArmorList.OrderBy(a => a.OriginalValue))
            {
                Console.WriteLine($"a{count}. {armor.Name} - Original Value: {armor.OriginalValue}, Resell Value: {armor.ResellValue}");
                ItemCatalog.Add($"a{count}", armor);
                count++;
            }
            Console.WriteLine();
        }

        public void ListPotions()
        {
            Console.WriteLine("Potions:");
            var count = 1;
            foreach (var potion in PotionsList.OrderBy(p => p.OriginalValue))
            {
                Console.WriteLine($"p{count}. {potion.Name} - Original Value: {potion.OriginalValue}, Resell Value: {potion.ResellValue}");
                ItemCatalog.Add($"p{count}", potion);
                count++;
            }
            Console.WriteLine();
        }

        public void ListHeroWeapons()
        {
            Console.WriteLine("Weapons:");
            var count = 1;
            foreach (var weapon in Hero.WeaponsBag.OrderBy(w => w.OriginalValue))
            {
                Console.WriteLine($"w{count}. {weapon.Name} - Original Value: {weapon.OriginalValue}, Resell Value: {weapon.ResellValue}");
                HeroItems.Add($"w{count}", weapon);
                count++;
            }
            Console.WriteLine();
        }

        public void ListHeroArmors()
        {
            Console.WriteLine("Armors:");
            var count = 1;
            foreach (var armor in Hero.ArmorsBag.OrderBy(a => a.OriginalValue))
            {
                Console.WriteLine($"a{count}. {armor.Name} - Original Value: {armor.OriginalValue}, Resell Value: {armor.ResellValue}");
                HeroItems.Add($"a{count}", armor);
                count++;
            }
            Console.WriteLine();
        }

        public void ListHeroPotions()
        {
            Console.WriteLine("Potions:");
            var count = 1;
            foreach (var potion in Hero.PotionsBag.OrderBy(p => p.OriginalValue))
            {
                Console.WriteLine($"p{count}. {potion.Name} - Original Value: {potion.OriginalValue}, Resell Value: {potion.ResellValue}");
                HeroItems.Add($"p{count}", potion);
                count++;
            }
            Console.WriteLine();

        }



        
    }
}















