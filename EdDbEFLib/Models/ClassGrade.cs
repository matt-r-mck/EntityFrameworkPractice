﻿using System;
using System.Collections.Generic;

namespace EdDbEFLib.models
{
    public partial class ClassGrade
    {
        public ClassGrade() {
            StudentClass = new HashSet<StudentClass>();
        }

        public string Grade { get; set; }
        public decimal Gpa { get; set; }

        public virtual ICollection<StudentClass> StudentClass { get; set; }
    }
}
