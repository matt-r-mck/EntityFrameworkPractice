﻿using System;
using System.Collections.Generic;

namespace EdDbEFLib.models
{
    public partial class MajorClass
    {
        public int Id { get; set; }
        public int MajorId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Major Major { get; set; }
    }
}
