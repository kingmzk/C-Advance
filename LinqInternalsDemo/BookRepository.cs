using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book () { Title = "Book 1", Price = 10 },
                new Book () { Title = "Book 2", Price = 20 },
                new Book () { Title = "Book 3", Price = 30 },
                new Book () { Title = "Book 4", Price = 40 },
                new Book () { Title = "Book 5", Price = 50 },
                new Book () { Title = "Book 6", Price = 60 },
                new Book () { Title = "Book 7", Price = 70 },
                new Book () { Title = "Book 8", Price = 80 },
                new Book () { Title = "Book 9", Price = 90 },
                new Book () { Title = "Book 10", Price = 100 },
                new Book () { Title = "Book 2", Price = 20 },
            };
        }
    }
}
