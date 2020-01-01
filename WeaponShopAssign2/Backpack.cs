using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{   // This class implements a backpack as a linked list
    // The backpack can hold any number of weapons as long as maxWeight is not crossed.
    // If an attempt to add a weapon to backpack is rejected due to weight
    class Backpack
    {
        public double maxWeight;
        public double presentWeight;
        public WeaponNode head;
        public Backpack()
        {
            maxWeight = 10;
            presentWeight = 0;
            head = null;

        }

        public bool addLast(Weapon we)
        {
            if (maxWeight > presentWeight)
            {

                WeaponNode newNode = new WeaponNode(we);
                
                if (head == null)
                {
                    head = newNode;
                    presentWeight++;
                    return true;
                }
                WeaponNode curr = head;

                while (curr != null)
                {

                    curr = curr.next;
                }
                curr = newNode;
                presentWeight++;
                return true;
            }
            return false;
        }

        public string printElements()
        {
            
           string s =  " **max weight: " + maxWeight + "\n";

            WeaponNode curr = head;
            while (curr != null)
            {
                s += "Weapon: " + curr.weap.weaponName + "  " + curr.weap.damage + "  " + curr.weap.range + "\n";
                curr = curr.next;
            }

            return s;
        }
    }

   
    
}
