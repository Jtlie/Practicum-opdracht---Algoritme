using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum_opdracht
{
    class NodeKlant<T> where T : Klant
    {
        private T data;
        public NodeKlant<T> Left, Right;

        public NodeKlant(T item)
        {
            data = item;
            Left = null;
            Right = null;
        }
        public T Data
        {
            set { data = value; }
            get { return data; }
        }
    }
}
