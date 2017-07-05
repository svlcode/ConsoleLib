using System;

namespace ConsoleLib
{
    internal class MenuItem
    {
        /// <summary>
        /// The name of the menu item that is displayed inside the console. 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The method that is executed when the menu item is selected.
        /// </summary>
        public Action Action { get; set; }

        /// <summary>
        /// The top position of the menu item within the menu.
        /// </summary>
        public int TopPosition { get; set; }

        public bool IsSelected { get; set; }


        public MenuItem(string name, Action action)
        {
            Name = name;
            Action = action;
        }
    }
}