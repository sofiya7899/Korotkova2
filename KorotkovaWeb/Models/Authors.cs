using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorotkovaWeb.Models
{
    public class Authors
    {
        public long id { get; set; }
        public string NameAuthor { get; set; }
        public string country { get; set; }
        public ICollection<Book> books { get; set; }

        public int getBooks()
        {
            return books.Count;
        }

    }
}
