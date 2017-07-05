using System;
using System.Collections.Generic;

namespace ConsoleLib
{
    public class Menu
    {
        private readonly List<MenuItem> _items;
        private readonly ConsoleGraphics _graphics;
        private readonly ItemSelector _itemSelector;
        private readonly ItemPositionManager _itemPositionManager;
        private readonly KeyToMenuActionConverter _keyToMenuActionConverter;
        private readonly MenuItemNavigator _menuItemNavigator;
        private readonly ItemActionService _itemActionService;


        public Menu()
        {
            _items = new List<MenuItem>();

            _itemPositionManager = new ItemPositionManager(_items);
            _graphics = new ConsoleGraphics(_items, _itemPositionManager);
            _itemSelector = new ItemSelector(_items);
            _menuItemNavigator = new MenuItemNavigator(_itemPositionManager, _itemSelector);
            _itemActionService = new ItemActionService(_itemPositionManager,_itemSelector);
            _keyToMenuActionConverter = new KeyToMenuActionConverter();

            SetupKeyMenuActionConverter();
        }

        private void SetupKeyMenuActionConverter()
        {
            _keyToMenuActionConverter.StartItemAction += KeyToMenuActionConverter_StartItemAction;
            _keyToMenuActionConverter.Navigate += _keyToMenuActionConverter_Navigate;
        }

        private void _keyToMenuActionConverter_Navigate(object sender, NavigationArgs e)
        {
            var nextCursorTopPosition =_menuItemNavigator.GetNextCursorTopPosition(e.Direction);
            _itemSelector.SelectItemAtPosition(nextCursorTopPosition);
            _itemPositionManager.MoveCursorToTopPosition(nextCursorTopPosition);
            _graphics.RenderItems();
        }

        private void KeyToMenuActionConverter_StartItemAction(object sender, EventArgs e)
        {
            var currentItemPosition = _itemPositionManager.GetCurrentCursorTopPosition();

            _itemActionService.InvokeItemAction();

            _itemPositionManager.MoveCursorToTopPosition(currentItemPosition);

            _graphics.RenderItems();
        }

        public void AddMenuItem(string menuItemCaption, Action action)
        {
            _items.Add(new MenuItem(menuItemCaption, action));
        }

        public void Show()
        {
            _itemPositionManager.SetItemsPosition();
            _itemSelector.SelectFirstItem();
            _graphics.RenderItems();
            _keyToMenuActionConverter.ReadKeys();
        }
    }
}