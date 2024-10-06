using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Hastalar
    {
        public int ID { get; set; }
        public int ReceteID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string TCK { get; set; }
        public string TelNo { get; set; }
        public string Sikayet { get; set; }
        public string Teshis { get; set; }
        public DateTime Tarih { get; set; }
        public bool Durum { get; set; }
        public bool Silinmis { get; set; }
    }
}
