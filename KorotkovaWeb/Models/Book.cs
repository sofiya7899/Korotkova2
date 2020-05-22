using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorotkovaWeb.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Authorr { get; set;}
        public long IdAuthor { get; set; }

        public Authors Author { get; set; }

    }
}
