using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcApplication1.Domain.Entities;

namespace MvcApplication1.Domain.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
        void SaveBook(Book book);
    }
}
