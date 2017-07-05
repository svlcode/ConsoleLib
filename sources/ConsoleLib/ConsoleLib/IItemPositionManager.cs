namespace ConsoleLib
{
    internal interface IItemPositionManager
    {
        void MoveCursorToFirstItemPosition();
        void SetItemsPosition(int topOffsetPosition);
        void SetItemsPosition();
        MenuItem GetItemByPosition(int topPosition);
        int GetCurrentCursorTopPosition();
        void MoveCursorToItemTopPosition(MenuItem item);
        int GetFirstItemTopPosition();
        int GetLastItemTopPosition();
        void MoveCursorToTopPosition(int topPosition);
    }
}