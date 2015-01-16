using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum_opdracht
{
    public class Bestelling
    {
        public int Klant_ID { get; set; }
        public int Bestelling_ID { get; set; }
        public bool Verwerking { get; set; }
        public DateTime Start_tijd { get; set; }
        public int Duur { get; set; }
        public bool Compleet { get; set; }
        public bool Dadelijk { get; set; }
    }
}
