using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class BinaryTNode
    {
        //change by object weapon parameter
        public Weapon w;
        public BinaryTNode left, right;
        public BinaryTNode(Weapon we) {
            w = we;
            left = null;
            right = null;
        }
    }
}
