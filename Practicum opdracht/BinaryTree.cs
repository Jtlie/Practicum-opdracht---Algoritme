using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum_opdracht
{
    class BinaryTree
    {
        int Klant_ID;
        string Voornaam;
        string Tussenvoegsel;
        string Achternaam;
        int Leeftijd;
        string Geslacht;
        string Plaats;
        string Email;
        BinaryTree left;
        BinaryTree right;

        public BinaryTree(Klant[] values) : this(values, 0) { }

        BinaryTree(Klant[] values, int index)
        {
            Load(this, values, index);
        }

        void Load(BinaryTree tree, Klant[] values, int index)
        {
            this.Klant_ID = values[index].Klant_ID;
            this.Voornaam = values[index].Voornaam;
            this.Tussenvoegsel = values[index].Tussenvoegsel;
            this.Achternaam = values[index].Achternaam;
            this.Leeftijd = values[index].Leeftijd;
            this.Geslacht = values[index].Geslacht;
            this.Plaats = values[index].Plaats;
            this.Email = values[index].Email;

            if (index * 2 + 1 < values.Length)
            {
                this.left = new BinaryTree(values, index * 2 + 1);
            }
            if (index * 2 + 2 < values.Length)
            {
                this.right = new BinaryTree(values, index * 2 + 2);
            }
        }

        public void Insert(Klant[] klant)
        {
            BinaryTree current = this;
            while (current != null)
            {
                if (current.Klant_ID < klant[0].Klant_ID)
                    if (current.left == null)
                    { current.left = new BinaryTree(klant); break; }
                    else current = current.left;
                else
                    if (current.right == null)
                    { current.right = new BinaryTree(klant); break; }
                    else current = current.right;
            }
        }

    }
}
