﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_StoreV10.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Section Section { get; set; }

        public override string ToString()
        {
            return $"Id {Id}  Name {Name} Email {Email}   Section {Section}";
        }
    }
}
