using System;

namespace ConsoleLib
{
    public interface IMenu
    {
        void AddMenuItem(string menuItemCaption, Action action);
        void Show();
    }
}