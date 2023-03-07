using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AplicacionReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a este magnifico programa... :)");
            int input;
            int i = -1;
            while (i != 0)
            {
                Console.WriteLine("Lista de funciones cargadas:");
                IEnumerable<IFunction> dlls = GetDlls();

                i = 0;
                foreach (IFunction dll in dlls)
                {
                    i++;
                    Console.WriteLine(" " + i + "- " + dll.GetName());
                }
                Console.WriteLine("\nSeleccione una dll o ingrese 0 (cero) para cerrar");
                i = int.Parse(Console.ReadLine());
                if (i != 0)
                {
                    Console.WriteLine("Input: ");
                    input = int.Parse(Console.ReadLine());
                    int result = dlls.ElementAt(i - 1).DoSomething(input);
                    Console.WriteLine("Resultado: " + result + "\n\n");
                }
            }
            Console.WriteLine("Gracias por usarme... :(");
        }
        private static IEnumerable<IFunction> GetDlls()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Funciones", "*.dll");
            foreach (string file in files)
            {
                Assembly dll = Assembly.UnsafeLoadFrom(file);
                Type type = dll.GetTypes().Where(i => typeof(IFunction).IsAssignableFrom(i)).FirstOrDefault();
                if (type != null)
                    yield return Activator.CreateInstance(type) as IFunction;
            }
        }
    }
}
