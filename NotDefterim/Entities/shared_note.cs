﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefterim.Entities
{
    internal class shared_note
    {
        public int note_id { get; set; }
        public int user_id { get; set; }
        public DateTime share_time { get; set; }
        public bool read_only { get; set; }
    }
}
