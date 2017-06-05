using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLib
{
    class ConsoleGraphics
    {
        private readonly List<MenuItem> _items;

        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor HighlightColor { get; set; }

        public ConsoleGraphics(List<MenuItem> items)
        {
            _items = items;
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

        public void ShowItems()
        {
            var initialHighlightPosition = 0;
            HighlightItem(highlightPosition: initialHighlightPosition);

            SetCursorToTheFirstMenuItem();
        }

        private void MoveCursorTopPostion(int nextPosition)
        {
            Console.CursorTop = nextPosition;
        }

        private int GetInitialCursorTopPosition()
        {
            return 0;
        }

        public void HighlightItem(int highlightPosition)
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

        private void SetCursorToTheFirstMenuItem()
        {
            var firstItem = _items.FirstOrDefault();
            if (firstItem != null)
                Console.CursorTop = firstItem.TopPosition;
        }

        
    }
}
