using System.Reflection;

namespace Reflection.Demo
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hi");

            var assembly = Assembly.LoadFrom(@"E:\C# VIsual Studio\Advanced c#\LinqInternalsDemo\PrintAll\bin\Debug\net8.0\PrintAll.dll");

            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine($"Type is : {type.FullName}");
                Console.WriteLine("================================");

                var instance = Activator.CreateInstance(type);


                foreach ( var field in type.GetFields(BindingFlags.NonPublic
                    | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                    {
                          Console.WriteLine($"Field : {field.Name}");
                          field.SetValue(instance, "Khan");
                }
                Console.WriteLine("================================");
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
                    | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(c => !c.IsSpecialName))
                {
                    Console.WriteLine($"Method : {method.Name}");
                    try
                    {
                        if (method.GetParameters().Length == 1 && method.GetParameters()[0].ParameterType == typeof(string))
                        {
                            // Check if method is Print and invoke with a single argument "King"
                            if (method.Name == "Print")
                            {
                                method.Invoke(instance, new object[] { "King" });
                            }
                        }
                        else if (method.GetParameters().Length == 0)
                        {
                            method.Invoke(instance, null);
                        }
                        else if (method.ReturnType.Name != "Void")
                        {
                            var returnedValue = method.Invoke(instance, null);
                            Console.WriteLine($"Returned value from method {returnedValue}");
                        }
                        else
                        {
                            method.Invoke(instance, null);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Exception occured in : {e.Message}");
                    }
                }

                Console.WriteLine("================================");


                foreach (var property in type.GetProperties())
                {
                    Console.WriteLine($"Property : {property.Name}");
                    var propertyValue = property.GetValue(instance); //instance will be neglected if the property is static
                    Console.WriteLine($"Property value {propertyValue}");
                }
            }
        }
    }

}
