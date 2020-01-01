using System;

namespace WeaponShopAssign2
{
    class Program
    {

        static void menu() {
            Console.Write("1) Add Items to shop\n" +
                "2) Delete Items from the shop\n" +
                "3) Buy from the Shop\n" +
                "4) View backpack\n" +
                "5) View Player\n" +
                "6) Exit\n");

        }
        static int checkChoice() {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > 6 && choice < 1) {
                Console.Clear();
                menu();
                Console.WriteLine("Please enter a correct choice :");

            }
            return choice;
        }

        static int checkIntInput(string s)
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Clear();
                Console.WriteLine(s);
            }
            return input;
        }
        static double checkDoubleInp(string s)
        {
            double input;
            while (!double.TryParse(Console.ReadLine(), out input))
            {
                Console.Clear();
                Console.WriteLine(s);

            }
            return input;
        }
        public static void addWeapons(BinaryST b)
        {
            Console.WriteLine("***********WELCOME TO THE WEAPON ADDING MENU*********");

            string weaponName; int weaponRange; int weaponDamage; double weaponWeight; double weaponCost;
            Console.WriteLine("Please enter the NAME of the Weapon ('end' to quit):");
            weaponName = Console.ReadLine();
            while (weaponName.CompareTo("end") != 0)
            {
                Console.WriteLine("Please enter a correct Range of the Weapon(0 - 10):");
                weaponRange = checkIntInput(" * **********WELCOME TO THE WEAPON ADDING MENU * ********\nPlease enter a correct Range of the Weapon (0-10):");
                Console.WriteLine("Please enter the Damage of the Weapon:");
                weaponDamage = checkIntInput("* **********WELCOME TO THE WEAPON ADDING MENU * ********\nPlease enter a correct Damage of the Weapon:");
                Console.WriteLine("Please enter the Weight of the Weapon (in pounds):");
                weaponWeight = checkDoubleInp("* **********WELCOME TO THE WEAPON ADDING MENU * ********\nPlease enter the Weight of the Weapon (in pounds):");
                Console.WriteLine("Please enter the Cost of the Weapon:");
                weaponCost = checkDoubleInp("* **********WELCOME TO THE WEAPON ADDING MENU * ********\nPlease enter the Cost of the Weapon:");
                Weapon w = new Weapon(weaponName, weaponRange, weaponDamage, weaponWeight, weaponCost);
                b.insertion(w);
                Console.Clear();
                Console.WriteLine("Please enter the NAME of another Weapon ('end' to quit):");
                weaponName = Console.ReadLine();
            }
        }

        public static void delete(BinaryST b){
            string s;
            Console.WriteLine("**********DELETE AN ITEM************");
            b.inOrder();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Please enter the NAME of the Weapon ('end' to quit):");
            
            s = Console.ReadLine();
            while (s != "end")
            {
                b.delete(s);
                //message successfull
                Console.Clear();
                Console.WriteLine("**********DELETE AN ITEM************");
                b.inOrder();
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Please enter the NAME of another Weapon ('end' to quit):");
                s = Console.ReadLine();
            }
}
        public static void buyWeapon(BinaryST b, Player p)
        {
            string choice;
            Console.WriteLine("WELCOME TO THE WEAPON STORE!!!!");
            b.inOrder();
            Console.WriteLine(" You have "+p.money+" money.");
            Console.WriteLine("Please select a weapon to buy('end' to quit):");
            choice=Console.ReadLine();
            while (choice.CompareTo("end") != 0 && !p.inventoryFull())
            {
                Weapon w = b.Search(choice);
                if (w != null)
                {
                    if (w.cost > p.money)
                    {
                        Console.WriteLine("Insufficient funds to buy "+w.weaponName );
                    }
                    else
                    {
                        p.buy(w);  //
                        p.withdraw(w.cost);
                    }
                }
                else
                {
                    Console.WriteLine(" ** "+choice+" not found!! **" );
                }
                Console.Clear();
                Console.WriteLine("Please select another weapon to buy('end' to quit):");
                choice = Console.ReadLine();
            }
            Console.WriteLine();
        }

       
        static void footForFunc(string s) {
            Console.WriteLine("Please enter end to quit: ");
            string choice = Console.ReadLine();
            while (choice.CompareTo("end") !=0) {
                Console.Clear();
                Console.Write(s + "Please enter end to quit: ");
                choice = Console.ReadLine(); 
                 }


        }
        
        static void Main(string[] args)
        {
            string pname;
            Console.WriteLine("Please enter Player name:");
            pname=Console.ReadLine();
            Player pl= new Player(pname,45);
            BinaryST bst = new BinaryST();
            //HashTable ht= new HashTable(101);

            menu();
            int choice = checkChoice();
            while (choice != 6)
            {
                if (choice == 1)
                {
                    Console.Clear();
                    addWeapons(bst);
                }
                if (choice == 2) { Console.Clear();
                    
                    delete(bst);
                }
                if (choice == 3) { Console.Clear(); buyWeapon(bst, pl); }
                if (choice == 4) {
                    Console.Clear();
                    Console.Write(pl.printBackpack());
                    footForFunc(pl.printBackpack());
                }
                if (choice == 5) {
                    Console.Clear();
                    Console.Write(pl.printCharacter());
                    footForFunc(pl.printCharacter());
                }
                Console.Clear();
                menu();
                choice = checkChoice();
            }
            

        }
    }
}
