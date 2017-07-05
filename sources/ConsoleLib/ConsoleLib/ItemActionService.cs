using System;

namespace ConsoleLib
{
    internal class ItemActionService
    {
        private readonly IItemPositionManager _itemPositionManager;
        private readonly IItemSelector _itemSelector;

        public ItemActionService(IItemPositionManager itemPositionManager, IItemSelector itemSelector)
        {
            _itemPositionManager = itemPositionManager;
            _itemSelector = itemSelector;
        }

        public void InvokeItemAction()
        {
            Console.CursorVisible = true;

            Console.Clear();

            var selectedItem = _itemSelector.GetSelectedItem();
            if (selectedItem != null)
            {
                if (selectedItem.Action != null)
                {
                    selectedItem.Action.Invoke();
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey(true);


                _itemPositionManager.MoveCursorToItemTopPosition(selectedItem);
            }
            Console.CursorVisible = false;
            Console.Clear();
        }
    }
}