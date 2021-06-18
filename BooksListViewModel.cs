using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Domain.Entities;

namespace MvcApplication1.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }

        public IEnumerable<string> Authors { get; set; }
    }
}