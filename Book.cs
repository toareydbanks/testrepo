using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication1.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
