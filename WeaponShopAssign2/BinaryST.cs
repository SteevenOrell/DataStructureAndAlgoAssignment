using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class BinaryST
    {
       public BinaryTNode root;
       private BinaryTNode visit;
       
        public BinaryST() {
            root = null;

        }
        public void insertion(Weapon we) {
            
            
            root = insertionHelp(we, root);
        }

        private BinaryTNode insertionHelp(Weapon we, BinaryTNode curr) {

            if (curr == null) {
                return new BinaryTNode(we);
            }

            if (curr.w.weaponName.CompareTo(we.weaponName) < 0) { curr.left = insertionHelp(we, curr.left); }
            if (curr.w.weaponName.CompareTo(we.weaponName) > 0) { curr.right = insertionHelp(we, curr.right); }
            return curr; 
        }

        public Weapon Search(string name)
        {


            Weapon w = searchHelp(name, root);
            return w;
        }

        private Weapon searchHelp(string n, BinaryTNode curr)
        {

            if (curr == null)
            {

                return null;
            }

            if (curr.w.weaponName == n) { return curr.w; }
            if (curr.w.weaponName.CompareTo(n) < 0) { return searchHelp(n,curr.left); }
            return searchHelp(n, curr.right);
        }

        public void inOrder() {
            inOrderTrav(root);
        }

        private void inOrderTrav(BinaryTNode b) {
            if (b == null) { return; }
            inOrderTrav(b.left);
            Console.WriteLine(b.w.weaponName);
            inOrderTrav(b.right);
        }

        public void delete(string s) {

            root = deletehelp(s, root); //affect root
        }
        public BinaryTNode deletehelp(string s, BinaryTNode root) {
            
            if (root== null) { return null; }
            if (root.w.weaponName == s)
            {
                if (root.left == null && root.right == null) { return null;  } //case one

                else
                {
                    if (root.left != null && root.right == null) { return root.left; }            //cases two
                    else if (root.right != null && root.left == null) { return root.right; }

                    else
                    {
                        BinaryTNode successor = root.right; //case three
                        while (successor != null)
                        {
                            successor = successor.left;
                        }
                        root.w = successor.w;
                       root.right = deletehelp(successor.w.weaponName, root.right);
                    }
                    
                }
            }

            if (root.w.weaponName.CompareTo(s) < 0) { root.left = deletehelp(s, root.left); }
           else if (root.w.weaponName.CompareTo(s) > 0) { root.right = deletehelp(s, root.right); }
            return root;
        }

        
    }
}
