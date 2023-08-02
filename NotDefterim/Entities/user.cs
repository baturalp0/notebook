using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefterim.Entities
{
    public class user //database'teki tabloyu modellediğimiz kısım
    {
        public int id { get; set; }
        public string name { get; set; }  //varchar = string
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool active { get; set; }  //tinyint = bool
        public DateTime createDate { get; set; }

    }
}
