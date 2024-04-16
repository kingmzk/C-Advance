

namespace IDisposable.Demo
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");

            //  using var serviceProxy = new ServiceProxy(null);  serviceProxy.Get();  serviceProxy.Post("");

            // if not using

            ServiceProxy serviceProxy = null;
            try
            {
                serviceProxy = new ServiceProxy(null);

                serviceProxy.Get();
                serviceProxy.Post("");
            }
            finally
            {
                serviceProxy.Dispose();
            }
           
      
        }
    }

}
