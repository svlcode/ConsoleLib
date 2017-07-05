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
        private readonly IItemPositionManager _itemPositionManager;

        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor HighlightColor { get; set; }

        public ConsoleGraphics(List<MenuItem> items, IItemPositionManager itemPositionManager)
        {
            _items = items;
            _itemPositionManager = itemPositionManager;

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

        public void RenderItems()
        {
            var currentItemPosition = _itemPositionManager.GetCurrentCursorTopPosition();

            _itemPositionManager.MoveCursorToFirstItemPosition();
            WriteItems();

            _itemPositionManager.MoveCursorToTopPosition(currentItemPosition);
        }

        private void WriteItems()
        {
            if (_items != null)
            {
                foreach (var item in _items)
                {
                    if (item.IsSelected)
                    {
                        SetHighlightColors();
                    }
                    else
                    {
                        SetDefaultColors();
                    }

                    Console.Write(item.Name);

                    SetDefaultColors();
                    Console.WriteLine();
                }

                SetDefaultColors();
            }
        }
    }
}
