using ConsoleLib.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLib.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = ConsoleMenuFactory.CreateMenu();
            menu.AddMenuItem("Suma a doua numere", () =>
            {
                int a, b;
                Console.Write("Dati a=");
                a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Dati b=");
                b = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Suma dintre {a} si {b} este {a + b}");

            });
            menu.AddMenuItem("Produsul a doua numere", () =>
            {
                int a, b;
                Console.Write("Dati a=");
                a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Dati b=");
                b = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Produsul dintre {a} si {b} este {a * b}");

            });
            menu.AddMenuItem("Impartirea a doua numere", () =>
            {
                int a, b;
                Console.Write("Dati a= ");
                a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Dati b= ");
                b = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Impartirea dintre {a} si {b} este {a / b}");

            });
            menu.AddMenuItem("Alt meniu", () =>
            {
                var innerMenu = ConsoleMenuFactory.CreateMenu();
                innerMenu.AddMenuItem("First item", () =>
                {
                    Console.WriteLine("Test 1");
                    Console.ReadLine();
                });
                innerMenu.AddMenuItem("Second item", () =>
                {
                    Console.WriteLine("Test 2");
                    Console.ReadLine();
                });
                innerMenu.AddMenuItem("Third item", () =>
                {
                    Console.WriteLine("Test 3");
                    Console.ReadLine();
                });
                innerMenu.Show();
            });

            menu.Show();
        }
    }
}
