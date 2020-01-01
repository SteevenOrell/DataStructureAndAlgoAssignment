using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class WeaponNode
    {
        public Weapon weap;
        public WeaponNode next;
        public WeaponNode(Weapon w)
        {
            weap = w;  
            next = null;

        }
    }
}
