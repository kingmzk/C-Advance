using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();
            //LinQ extension method
            var lowPriceBooks = books.Where(x => x.Price <= 50)
                .OrderBy(x => x.Title)
                .Select(x => x.Title);

            //LinQ QUery method 
            var lowPriceBookQuery = from b in books
                                     where b.Price <= 50
                                     orderby b.Title
                                     select b;

            foreach (var book in lowPriceBooks)
            {
                Console.WriteLine(book);
               // Console.WriteLine(book.Title + " " + book.Price);
            }

            var book1 = books.SingleOrDefault(b => b.Title == "Book 10");

            var book2 = books.FirstOrDefault(b => b.Title == "Book 10");

            var book3 = books.LastOrDefault(b => b.Title == "Book 10");

            var pagedBooks = books.Skip(2).Take(3); //skip 2 take 3

            var book4 = books.Count();

            var book5 = books.Max(b => b.Price);

            var book6 = books.Min(b => b.Price);

            var book7 = books.Sum(b => b.Price);

            var book8 = books.Average(b => b.Price);


            //Nullable
            DateTime? date = null; 

            Console.WriteLine("GetValueOrDefault" + date.GetValueOrDefault());
            Console.WriteLine("HasValue" + date.HasValue);

            DateTime? dates = new DateTime(2024, 1, 1);
            DateTime date1 = dates.GetValueOrDefault();


            //Dynamic
            //The dynamic type in C# allows you to bypass compile-time type checking, enabling you to perform operations on objects at runtime without knowing their type during compilation.

            object obj = "zakria";
            obj.GetHashCode();

                  //in reflection example
                  var methodInfo = obj.GetType().GetMethod("GetHashCode");
                  methodInfo.Invoke(null, null);

            //using dynamic at compile time
            dynamic excelObj = "khan";
            excelObj.Optimize();

            dynamic name = "khan";
                name = 20;

        }
    }
}
