using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqIAndDelegates.Delegates
{
    delegate int MyDelegate(int x, int y);
    public class Delegates
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Subtract(int x, int y)
        {
            return x - y;
        }


        public static void main(string[] args)
        {
            MyDelegate del = new MyDelegate(Add);
            int result = del(5, 6);
            Console.WriteLine(result);

            MyDelegate del1 = new MyDelegate(Subtract);
            result = del1(8, 6);
            Console.WriteLine(result);
        }

    }
}
