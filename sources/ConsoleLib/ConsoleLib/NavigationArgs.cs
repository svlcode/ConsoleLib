using System;

namespace ConsoleLib
{
    internal class NavigationArgs : EventArgs
    {
        public NavigationDirectionEnum Direction { get; }

        public NavigationArgs(NavigationDirectionEnum direction)
        {
            Direction = direction;
        }
    }
}