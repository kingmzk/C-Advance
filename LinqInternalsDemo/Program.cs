using Linq;

namespace LinqInternalsDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //  WhereDemo();

            var customer = new[]
            {
                new Customer
                {
                    Id=1,
                    Name="Rean",
                    Phones = new[] { new Phone{Number="9019108181", PhoneType=PhoneType.Cell },
                                   new Phone{Number="9738421141", PhoneType=PhoneType.Cell }
                    }
                },
                 new Customer 
                 { 
                     Id=2,
                     Name="Ayub",
                    Phones = new[] { new Phone{Number="9448588646", PhoneType=PhoneType.Home },
                                   new Phone{Number="78616565746", PhoneType=PhoneType.Home }
                    }
                 }
            };

            // var customerNames = customer.Select(c => c.Name);         
            // var customerNames = customer.NewSelect(c => c.Name);
            // foreach (var name in customerNames) { Console.WriteLine(name); }

            //   var customerPhones = customer.SelectMany(c => c.Phones);
           // var customerPhones = customer.NewSelectMany(c => c.Phones);
          //  foreach (var item in customerPhones) { Console.WriteLine($"{item.Number} and {item.PhoneType}"); }

            var address = new[]
            {
                new Address{ Id=1, CustomerId=2, Street="Halahalli",City="Mandya" },
                 new Address{ Id=2, CustomerId=1, Street="Frankfurd",City="Germany" },
            };

            //var customerWithAddress = customer.Join(
            var customerWithAddress = customer.NewJoin(
                address
                , c => c.Id
                , a => a.CustomerId
                , (c, a) => new { c.Name, a.Street, a.City }
                );

            foreach( var items in  customerWithAddress) { Console.WriteLine($"{items.Name} - {items.Street} - {items.City}");  }
        }


        static void WhereDemo()
        {
            int[] arr = { 10, 11, 12, 13, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            var evenItems = arr.Where(x => x % 2 == 0);

            foreach (int item in evenItems)
            {
                Console.WriteLine(item);
            }

            //The IEnumerableExtension class is simply defining an extension method (newWhere) for objects that implement the IEnumerable<T> interface. This means that any object that implements IEnumerable<T> can make use of the newWhere method as if it were a member of that object's class.
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var oddItems = items.newWhere(x => x % 2 != 0);
            // If items is a list, it will jump to the extension method.
            // If items is an enumerable yielding items, it will be processed in `oddItems`

            foreach (int item in oddItems)
            {
                Console.WriteLine(item);
            }
        }

    }
}