using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_experessions
{
    public class BookRepository
    {
        /*
        public List<Book> GetBooks(Func<Book, bool> predicate)
        {
            var books = new List<Book>
        {
            new Book { Title = "C#", Price = 10 },
            new Book { Title = "C++", Price = 10 },
            new Book { Title = "Java", Price = 50 }
        };

            // Return the books filtered by the predicate
            return books.Where(predicate).ToList();
        }
      */

        public List<Book> GetBooks()
        {
            return new List<Book>() 
            {
                new Book { Title = "C#", Price = 5 },
                new Book { Title = "C++", Price = 10 },
                new Book { Title = "Java", Price = 50 }
            };
        }

    }
}
