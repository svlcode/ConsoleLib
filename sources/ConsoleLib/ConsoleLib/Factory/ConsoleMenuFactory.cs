using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLib.Factory
{
    public static class ConsoleMenuFactory
    {
        public static IMenu CreateMenu()
        {
            return new Menu();
        }
    }
}
