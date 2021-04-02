﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class MovieCast
    {
        public string Character { get; set; }
        public int MovieId { get; set; }
        public int CastId { get; set; }
        public Movie Movie { get; set; }
        public Cast Cast { get; set; }
       
    }
}
