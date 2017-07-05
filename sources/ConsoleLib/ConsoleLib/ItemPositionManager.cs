using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleLib
{
    internal class ItemPositionManager : IItemPositionManager
    {
        private readonly List<MenuItem> _items;
        private const int DEFAULT_OFFSET_TOP_ITEM_POSITION = 0;
        

        public ItemPositionManager(List<MenuItem> items)
        {
            _items = items;
            
        }

        public void SetItemsPosition(int topOffsetPosition)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].TopPosition = topOffsetPosition + i;
            }
        }

        public void SetItemsPosition()
        {
            SetItemsPosition(DEFAULT_OFFSET_TOP_ITEM_POSITION);
        }

        public MenuItem GetItemByPosition(int topPosition)
        {
            return _items.FirstOrDefault(itm => itm.TopPosition == topPosition);
        }

        public int GetFirstItemTopPosition()
        {
            int firstItemTopPosition = 0;
            var firstOrDefault = _items.FirstOrDefault();
            if (firstOrDefault != null)
                firstItemTopPosition = firstOrDefault.TopPosition;
            return firstItemTopPosition;
        }

        public int GetLastItemTopPosition()
        {
            int lastItemTopPosition = 0;
            var lastOrDefault = _items.LastOrDefault();
            if (lastOrDefault != null)
                lastItemTopPosition = lastOrDefault.TopPosition;
            return lastItemTopPosition;
        }

        public void MoveCursorToFirstItemPosition()
        {
            Console.CursorTop = GetFirstItemTopPosition();
        }

        public int GetCurrentCursorTopPosition()
        {
            return Console.CursorTop;
        }

        public void MoveCursorToItemTopPosition(MenuItem item)
        {
            Console.CursorTop = item.TopPosition;
        }

        public void MoveCursorToTopPosition(int topPosition)
        {
            Console.CursorTop = topPosition;
        }
    }
}