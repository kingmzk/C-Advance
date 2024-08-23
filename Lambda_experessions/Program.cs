// See https://aka.ms/new-console-template for more information
using Lambda_experessions;
using System.Diagnostics;

class Programme
{
    public static void Main(string[] args)
    {
        // args => expression
        // () => ....
        // x => ....
        // (x,y,z) => ...

        Func<int , int> square = (number => number * number);
        Console.WriteLine(square(5));

        int num = 10;
        Func<int, int> multiplier = x => x * num;
        Console.WriteLine(multiplier(5));

        //var repository = new BookRepository();
        //List<Book> result = repository.GetBooks(x => x.Price > 10);

        var books = new BookRepository().GetBooks();
        var result = books.FindAll(Book => Book.Price >= 10);

        foreach (var book in result)
        {
            Console.WriteLine($"{book.Title} - {book.Price}");
        }


    }
}
