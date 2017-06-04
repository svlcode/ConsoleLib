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
            Menu menu = new Menu();
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

            menu.Show();
        }
    }
}
