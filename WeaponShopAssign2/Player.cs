using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class Player
    {
        public string name;
        public Backpack backpack;
  
        public double money;

        public Player(string n, double m)
        {
            name = n;
            money = m;
            
            backpack = new Backpack();
        }

        public void buy(Weapon w)
        {
                Console.WriteLine(w.weaponName + " bought...");
                backpack.addLast(w);
                
                Console.Write(backpack.presentWeight);
            
        }
        public void withdraw(double amt)
        {
            money = money - amt;
        }

        public bool inventoryFull()
        {
            bool full = false;
            if (backpack.presentWeight == 10) full = true;
            return full;
        }


        public string printCharacter()
        {
            string s = " Name:"+name+"\n Money:"+money+"\n";
           s+= printBackpack()+"\n";
            return s;
        }

        public string printBackpack()
        {
           
            string s = " "+name+", you own " + backpack.presentWeight +" Weapons:\n";
           s += backpack.printElements()+"\n";
            return s;
        }
    }
}
