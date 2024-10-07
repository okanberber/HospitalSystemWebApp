using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Recete
    {
        public int ID { get; set; }
        public int IlaclarID { get; set; }
        public string Isim { get; set; }
        public DateTime Tarih { get; set; }
    }
}
