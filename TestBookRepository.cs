using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcApplication1.Domain.Entities;
using MvcApplication1.Domain.Interfaces;

namespace MvcApplication1.Domain.DAO
{
    public class TestBookRepository : IBookRepository
    {       

        #region IBookRepository Members

        public IQueryable<Book> Books
        {
            get
            {
                return new List<Book> { 
                    new Book { Id = 100, Title = "Book 1", Author = "Author 1", Description = "Description 1", PublishDate = DateTime.Parse("8/1/2011") },
                    new Book { Id = 200, Title = "Book 2", Author = "Author 2", Description = "Description 2", PublishDate = DateTime.Parse("8/2/2011") },
                    new Book { Id = 300, Title = "Book 3", Author = "Author 3", Description = "Description 3", PublishDate = DateTime.Parse("8/3/2011") },
                    new Book { Id = 400, Title = "Book 4", Author = "Author 4", Description = "Description 4", PublishDate = DateTime.Parse("8/4/2011") },
                    new Book { Id = 500, Title = "Book 5", Author = "Author 5", Description = "Description 5", PublishDate = DateTime.Parse("8/5/2011") },
                    new Book { Id = 600, Title = "Book 6", Author = "Author 6", Description = "Description 6", PublishDate = DateTime.Parse("8/6/2011") },
                    new Book { Id = 700, Title = "Book 7", Author = "Author 7", Description = "Description 7", PublishDate = DateTime.Parse("8/7/2011") },
                    new Book { Id = 800, Title = "Book 8", Author = "Author 8", Description = "Description 8", PublishDate = DateTime.Parse("8/8/2011") },
                    new Book { Id = 900, Title = "Book 9", Author = "Author 9", Description = "Description 9", PublishDate = DateTime.Parse("8/9/2011") },
                    new Book { Id = 1000, Title = "Book 10", Author = "Author 10", Description = "Description 10", PublishDate = DateTime.Parse("8/10/2011") },
                    new Book { Id = 1100, Title = "Book 11", Author = "Author 11", Description = "Description 11", PublishDate = DateTime.Parse("8/11/2011") },
                    new Book { Id = 1200, Title = "Book 12", Author = "Author 12", Description = "Description 12", PublishDate = DateTime.Parse("8/12/2011") },
                    new Book { Id = 1300, Title = "Book 13", Author = "Author 13", Description = "Description 13", PublishDate = DateTime.Parse("8/13/2011") },
                    new Book { Id = 1400, Title = "Book 14", Author = "Author 14", Description = "Description 14", PublishDate = DateTime.Parse("8/14/2011") }
                }.AsQueryable();
            }
        }
        
        public void SaveBook(Book book)
        {
            //Save Logic here
        }

        #endregion
    }
}
