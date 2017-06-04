using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleLib
{
    public class Menu
    {
        private readonly List<MenuItem> _items;

        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor HighlightColor { get; set; }

        public Menu()
        {
            _items = new List<MenuItem>();

            SetDefaultColors();
            Console.CursorVisible = false;
        }

        private void InitDefaultColors()
        {
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Gray;
            HighlightColor = ConsoleColor.Yellow;
        }

        private void InitHighlightColors()
        {
            BackgroundColor = ConsoleColor.Yellow;
            ForegroundColor = ConsoleColor.Black;
            HighlightColor = ConsoleColor.Yellow;
        }

        private void ChangeColors()
        {
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForegroundColor;
        }

        private void SetDefaultColors()
        {
            InitDefaultColors();
            ChangeColors();
        }

        private void SetHighlightColors()
        {
            InitHighlightColors();
            ChangeColors();
        }

        public void AddMenuItem(string menuItemCaption, Action action)
        {
            _items.Add(new MenuItem(menuItemCaption, action));
        }

        public void Show()
        {
            var initialHighlightPosition = 0;
            DisplayItems(highlightPosition:initialHighlightPosition);

            SetCursorToTheFirstMenuItem();

            NavigateMenuItems();

        }

        private void DisplayItems(int highlightPosition)
        {
            if (_items != null)
            {
                MoveCursorTopPostion(GetInitialCursorTopPosition());

                foreach (var item in _items)
                {
                    item.TopPosition = Console.CursorTop;

                    if (item.TopPosition == highlightPosition)
                    {
                        SetHighlightColors();
                    }
                    else
                    {
                        SetDefaultColors();
                    }

                    Console.WriteLine(item.Name);
                }

                SetDefaultColors();
            }
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
                    Console.WriteLine("Test");
                    Console.ReadLine();

                    Console.CursorVisible = false;
                    Console.Clear();

                    Console.CursorTop = currentCursorPosition;
                    DisplayItems(highlightPosition: currentCursorPosition);
                    Console.CursorTop = currentCursorPosition;
                }
                else
                {
                    var nextCursorPosition = GetNextCursorTopPosition(key, firstItemTopPosition, lastItemTopPosition);

                    DisplayItems(highlightPosition: nextCursorPosition);

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

        

        private int GetInitialCursorTopPosition()
        {
            return 0;
        }

        private void MoveCursorTopPostion(int nextPosition)
        {
            Console.CursorTop = nextPosition;
        }

        private void SetCursorToTheFirstMenuItem()
        {
            var firstItem = _items.FirstOrDefault();
            if (firstItem != null)
                Console.CursorTop = firstItem.TopPosition;
        }
    }
}