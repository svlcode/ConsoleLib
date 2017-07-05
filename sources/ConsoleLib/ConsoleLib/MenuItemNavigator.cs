using System;

namespace ConsoleLib
{
    internal class MenuItemNavigator
    {
        private readonly IItemPositionManager _itemPositionManager;
        private readonly IItemSelector _itemSelector;

        public MenuItemNavigator(IItemPositionManager itemPositionManager, IItemSelector itemSelector)
        {
            _itemPositionManager = itemPositionManager;
            _itemSelector = itemSelector;
        }

        //public int GetNextCursorTopPosition(NavigationDirectionEnum direction)
        //{
        //    var cursorTopPosition = GetNextCursorTopPosition(direction);
        //    _itemSelector.SelectItemAtPosition(cursorTopPosition);
        //    _itemPositionManager.MoveCursorToTopPosition(cursorTopPosition);
        //}

        public int GetNextCursorTopPosition(NavigationDirectionEnum direction)
        {
            int cursorTopPosition = _itemPositionManager.GetCurrentCursorTopPosition();

            int firstItemTopPosition = _itemPositionManager.GetFirstItemTopPosition();
            int lastItemTopPosition = _itemPositionManager.GetLastItemTopPosition();
            switch (direction)
            {
                case NavigationDirectionEnum.Previous:
                    if (cursorTopPosition - 1 >= firstItemTopPosition)
                        cursorTopPosition -= 1;
                    break;
                case NavigationDirectionEnum.Next:
                    if (cursorTopPosition + 1 <= lastItemTopPosition)
                        cursorTopPosition += 1;
                    break;
                case NavigationDirectionEnum.First:
                    cursorTopPosition = firstItemTopPosition;
                    break;
                case NavigationDirectionEnum.Last:
                    cursorTopPosition = lastItemTopPosition;
                    break;
            }
            return cursorTopPosition;
        }
    }
}