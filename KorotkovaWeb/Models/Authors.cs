﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorotkovaWeb.Models
{
    public class Authors
    {
        public long id { get; set; }
        public string Authorr { get; set; }
        public string country { get; set; }
        public List<Book> Book { get; set; }
        public Authors()
        {
            Book = new List<Book>();
        }

    }
}