using System;

namespace ConsoleLib
{
    internal sealed class NavigationArgs : EventArgs
    {
        public NavigationDirectionEnum Direction { get; }

        public NavigationArgs(NavigationDirectionEnum direction)
        {
            Direction = direction;
        }
    }
}