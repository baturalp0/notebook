using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefterim.Entities
{
    public class note
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string noteTitle { get; set; }
        public string noteContent { get; set; }
        public bool deleted { get; set; }
        public DateTime createDate { get; set; }
    }
}
