using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleLib
{
    public class Menu
    {
        private readonly List<MenuItem> _items;
        private readonly ConsoleGraphics _graphics;

        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor HighlightColor { get; set; }

        public Menu()
        {
            _items = new List<MenuItem>();
            _graphics = new ConsoleGraphics(_items);
        }

        public void AddMenuItem(string menuItemCaption, Action action)
        {
            _items.Add(new MenuItem(menuItemCaption, action));
        }

        public void Show()
        {
            _graphics.ShowItems();

            NavigateMenuItems();
        }

        private void NavigateMenuItems()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            int firstItemTopPosition = GetFirstItemTopPosition();
            int lastItemTopPosition = GetLastItemTopPosition();

            while (key != ConsoleKey.Escape)
            {
                if (key == ConsoleKey.Enter)
                {
                    var currentCursorPosition = Console.CursorTop;

                    Console.CursorVisible = true;

                    Console.Clear();

                    var item = _items.FirstOrDefault(i => i.TopPosition == currentCursorPosition);
                    if (item != null)
                    {
                        if (item.Action != null)
                        {
                            item.Action.Invoke();
                        }
                    }
                    Console.Write("Press any key to continue...");
                    Console.ReadKey(true);
                    
                    Console.CursorVisible = false;
                    Console.Clear();

                    Console.CursorTop = currentCursorPosition;
                    _graphics.HighlightItem(highlightPosition: currentCursorPosition);
                    Console.CursorTop = currentCursorPosition;
                }
                else
                {
                    var nextCursorPosition = GetNextCursorTopPosition(key, firstItemTopPosition, lastItemTopPosition);

                    _graphics.HighlightItem(highlightPosition: nextCursorPosition);

                    Console.CursorTop = nextCursorPosition;
                }
                

                key = Console.ReadKey(true).Key;
            }
        }

        private int GetNextCursorTopPosition(ConsoleKey key, int firstItemTopPosition, int lastItemTopPosition)
        {
            int cursorTopPosition = Console.CursorTop;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (cursorTopPosition - 1 >= firstItemTopPosition)
                        cursorTopPosition -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    if (cursorTopPosition + 1 <= lastItemTopPosition)
                        cursorTopPosition += 1;
                    break;
                case ConsoleKey.PageUp:
                    cursorTopPosition = firstItemTopPosition;
                    break;
                case ConsoleKey.PageDown:
                    cursorTopPosition = lastItemTopPosition;
                    break;
            }
            return cursorTopPosition;
        }

        private int GetLastItemTopPosition()
        {
            int lastItemTopPosition = 0;
            var lastOrDefault = _items.LastOrDefault();
            if (lastOrDefault != null)
                lastItemTopPosition = lastOrDefault.TopPosition;
            return lastItemTopPosition;
        }

        private int GetFirstItemTopPosition()
        {
            int firstItemTopPosition = 0;
            var firstOrDefault = _items.FirstOrDefault();
            if (firstOrDefault != null)
                firstItemTopPosition = firstOrDefault.TopPosition;
            return firstItemTopPosition;
        }

        

       

       

       
    }
}