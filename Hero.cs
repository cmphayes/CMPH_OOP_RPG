using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {

        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public Game Game { get; set; }
        public int Gold { get; set; }
        public int Speed { get; set; }
        public Weapon Weapon { get; set; }
        public Potion Potion { get; set; }
        public Armor Armor { get; set; }

        public List<Armor> ArmorsBag { get; set; }
        public List<Weapon> WeaponsBag { get; set; }
        public List<Potion> PotionsBag { get; set; }

        public Dictionary<string, object> HeroWeaponCatalog { get; set; }
        public Dictionary<string, object> HeroArmorCatalog { get; set; }
        public Dictionary<string, object> HeroPotionsCatalog { get; set; }





        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero(Game game)
        {
            this.ArmorsBag = new List<Armor>();
            this.WeaponsBag = new List<Weapon>();
            this.PotionsBag = new List<Potion>();
            this.HeroWeaponCatalog = new Dictionary<string, object>();
            this.HeroArmorCatalog = new Dictionary<string, object>();
            this.HeroPotionsCatalog = new Dictionary<string, object>();
            this.Strength = 10;
            this.Defense = 10;
            this.OriginalHP = 30;
            this.CurrentHP = 30;
            this.Gold = 100;
            this.Speed = 5;
            this.Game = game;
            Weapon = Weapon;
            Armor = Armor;
            Potion = Potion; 


        }



        //These are the Methods of our Class.
        public void ShowStats()
        {
            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
            Console.WriteLine("Speed: " + this.Speed);
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.Game.Main();
        }

        public void ShowInventory()
        {
            Console.WriteLine("*****  INVENTORY ******");
            
            Console.WriteLine("Weapons: ");
            foreach (var Weapon in this.WeaponsBag)
            {
                    Console.WriteLine(Weapon.Name + " of " + Weapon.Strength + " Strength");
            }            
            Console.WriteLine("Armors: ");
            foreach (var Armor in this.ArmorsBag)
            {
                Console.WriteLine(Armor.Name + " of " + Armor.Defense + " Defense");
            }
            Console.WriteLine("Potions: ");
            foreach (var Potion in this.PotionsBag)
            {
                    Console.WriteLine(Potion.Name + " of " + Potion.HP + " HP");
            }
            
            Console.WriteLine("What Would You Like To Do?");
            Console.WriteLine("1.) Equip A Weapon.");
            Console.WriteLine("2.) Equip An Armor");
            Console.WriteLine("3.) Drink Potion");
            Console.WriteLine("4.) Unequip An Item.");
            Console.WriteLine("5.) Continue Adventure");
            var MenuSelection = Console.ReadLine();
            if (MenuSelection == "1")
            {
                Console.WriteLine("Which Item Would You Like To Equip?");
                ListHeroWeapons();
                var WeaponSelect = "";
                WeaponSelect = Console.ReadLine();
                if (HeroWeaponCatalog.ContainsKey(WeaponSelect))
                {

                    var NewWeapon = (Weapon)HeroWeaponCatalog[WeaponSelect];
                    EquipWeapon(NewWeapon);

                }
                else if (!HeroWeaponCatalog.ContainsKey(WeaponSelect))
                {
                    Console.WriteLine("Please Enter a Valid Code.");
                    ShowInventory();
                }

            }
            else if (MenuSelection == "2")
            {

                Console.WriteLine("Which Item Would You Like To Equip?");
                ListHeroArmor();
                var ArmorSelect = "";
                ArmorSelect = Console.ReadLine();
                if (HeroArmorCatalog.ContainsKey(ArmorSelect))
                {
                    var NewArmor = (Armor)HeroArmorCatalog[ArmorSelect];
                    EquipArmor(NewArmor);
                }
                else if (!HeroArmorCatalog.ContainsKey(ArmorSelect))
                {
                    Console.WriteLine("Please Enter a Valid Code.");
                    ShowInventory();
                }
            }
            else if (MenuSelection == "3")
            {
                Console.WriteLine("Which Potion Would You Like to Drink?");
                ListHeroPotions();
                var PotionSelect = "";
                PotionSelect = Console.ReadLine();
                if (HeroPotionsCatalog.ContainsKey(PotionSelect))
                {
                    var NewPotion = (Potion)HeroPotionsCatalog[PotionSelect];
                    PotionsBag.Remove(NewPotion);
                    this.CurrentHP += NewPotion.HP;
                }
                else if (!HeroPotionsCatalog.ContainsKey(PotionSelect))
                {
                    Console.WriteLine("Please Enter a Valid Code.");
                    ShowInventory();
                }
            }
            else if (MenuSelection == "4")
            {

                
                    Console.WriteLine("Which Item Would You Like To Unequip?");
                    Console.WriteLine($"1.){EquippedWeapon.Name} {EquippedWeapon.Strength} Strength");
                    Console.WriteLine($"2.){EquippedArmor.Name} {EquippedArmor.Defense} Defense");
                    Console.WriteLine($"3.)Continue Adventure");
                    var UnequipVar = Console.Read();

                    switch (UnequipVar)
                    {
                        case 1:

                            UnEquipWeapon(Weapon);

                            break;

                        case 2:

                            UnEquipArmor(Armor);

                            break;

                        case 3:

                            ShowInventory();

                            break;

                        case 5:

                            Game.Main();

                            break;
                    }
                
            }         
            
            else if (MenuSelection == "5")
            {

                Game.Main();


            }
            else
            {
                Game.Main();
            }

            


        }



        public void EquipWeapon(Weapon weapon)
        {
            if (EquippedWeapon == null)
            {
                this.EquippedWeapon = weapon;
                WeaponsBag.Remove(weapon);
                Strength += weapon.Strength;
                Console.WriteLine($"You Are Now Weilding a {weapon.Name} For + {weapon.OriginalValue} Strength");
                Console.WriteLine();
                ShowInventory();
            }
            else
            {
                Console.WriteLine("You already have a weapon equipped.");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Back to Inventory.");
                Console.WriteLine("2. Continue Adventure.");
                Console.WriteLine("3. Back To Town.");

                var input = Console.ReadLine();
                if (input == "1")
                {
                    this.ShowInventory();
                }
                else if (input == "2")
                {
                    var explore = new Explore(this, Game);
                    explore.Start();
                }
                else if (input == "3")
                {
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ReadKey();
                    this.Game.Main();
                }
            }

        }


        public void EquipArmor(Armor armor)
        {
            if (EquippedArmor == null)
            {
                this.EquippedArmor = armor;
                ArmorsBag.Remove(armor);
                Defense += armor.Defense;
                Speed -= armor.Defense;
                Console.WriteLine($"You Are Now Wearing {armor.Name} For + {armor.OriginalValue} Defense");
                Console.WriteLine();

                ShowInventory();
            }
            else
            {
                Console.WriteLine("You already have a weapon equipped.");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Back to Inventory.");
                Console.WriteLine("2. Continue Adventure.");
                Console.WriteLine("3. Back To Town.");

                var input = Console.ReadLine();
                if (input == "1")
                {
                    this.ShowInventory();
                }
                else if (input == "2")
                {
                    var explore = new Explore(this, Game);
                    explore.Start();
                }
                else if (input == "3")
                {
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ReadKey();
                    this.Game.Main();
                }
            }
        }






            public void UnEquipWeapon(Weapon EquippedWeapon)
            {
                if (EquippedWeapon != null)
                {
                    WeaponsBag.Add(EquippedWeapon);
                    Strength -= EquippedWeapon.Strength;
                    this.EquippedWeapon = null;
                    Console.WriteLine($"You Are Now Longer Weilding a {EquippedWeapon.Name} For + {EquippedWeapon.Strength} Strength");
                    Console.WriteLine();
                    ShowInventory();
                }
                else
                {
                    Console.WriteLine("You do not have a weapon equipped.");
                    Console.WriteLine();
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Back to Inventory.");
                    Console.WriteLine("2. Continue Adventure.");
                    Console.WriteLine("3. Back To Town.");

                    var input = Console.ReadLine();
                    if (input == "1")
                    {
                        this.ShowInventory();
                    }
                    else if (input == "2")
                    {
                        var explore = new Explore(this, Game);
                        explore.Start();
                    }
                    else if (input == "3")
                    {
                        Console.WriteLine("Press any key to return to main menu.");
                        Console.ReadKey();
                        this.Game.Main();
                    }

                }
            }
        






        public void UnEquipArmor(Armor EquippedArmor)
        {
            if (EquippedArmor != null)
            {
                ArmorsBag.Add(EquippedArmor);
                Defense -= EquippedArmor.Defense;
                Speed += EquippedArmor.Defense;
                this.EquippedArmor = null;
                Console.WriteLine($"You Are No Longer Wearing {EquippedArmor.Name} For + {EquippedArmor.Defense} Defense");
                Console.WriteLine();

                ShowInventory();
            }
            else
            {
                Console.WriteLine("You Do Not Have Armor Equipped.");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Back to Inventory.");
                Console.WriteLine("2. Continue Adventure.");
                Console.WriteLine("3. Back To Town.");

                var input = Console.ReadLine();
                if (input == "1")
                {
                    this.ShowInventory();
                }
                else if (input == "2")
                {
                    var explore = new Explore(this, Game);
                    explore.Start();
                }
                else if (input == "3")
                {
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ReadKey();
                    this.Game.Main();
                }
            }

            }




            //public void EquipWeapon(Weapon)
            //{
            //    if(WeaponsBag.Any())
            //    {
            //        this.EquippedWeapon = this.WeaponsBag[0];
            //    }
            //}

            //public void EquipArmor(Armor)
            //{
            //    if(ArmorsBag.Any()) {
            //        this.EquippedArmor = this.ArmorsBag[0];
            //    }
            //}
        

        public void ListHeroWeapons()
        {
            Console.WriteLine("Weapons:");

            var WeaponCount = 1;
            foreach (var wl in this.WeaponsBag)
            {
                Console.WriteLine($"{WeaponCount}.) {wl.Name} - Original Value: {wl.OriginalValue}, Resell Value: {wl.ResellValue}");
                HeroWeaponCatalog.Add($"{WeaponCount}", wl);
                WeaponCount++;
            }
            Console.WriteLine();
        }

        public void ListHeroArmor()
        {
            Console.WriteLine("Armor:");

            var ArmorCount = 1;
            foreach (var al in this.ArmorsBag)
            {
                Console.WriteLine($"{ArmorCount}.) {al.Name} - Original Value: {al.OriginalValue}, Resell Value: {al.ResellValue}");
                HeroArmorCatalog.Add($"{ArmorCount}", al);
                ArmorCount++;
            }
            Console.WriteLine();

        }

        public void ListHeroPotions()
        {
            Console.WriteLine("Potions:");

            var PotionCount = 1;
            foreach (var pl in this.PotionsBag)
            {
                Console.WriteLine($"{PotionCount}.) {pl.Name} - Original Value: {pl.OriginalValue}, Resell Value: {pl.ResellValue}");
                HeroPotionsCatalog.Add($"{PotionCount}", pl);
                PotionCount++;
            }
            Console.ReadLine();

        }
    }
}


                    
                
            
        

    


    





    
