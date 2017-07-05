using System.Collections.Generic;
using System.Linq;

namespace ConsoleLib
{
    internal class ItemSelector : IItemSelector
    {
        private readonly List<MenuItem> _items;

        public ItemSelector(List<MenuItem> items)
        {
            _items = items;
        }

        public void SelectItemAtPosition(int topPosition)
        {
            var itemToSelect = _items.FirstOrDefault(i => i.TopPosition == topPosition);
            if (itemToSelect != null)
            {
                SelectIten(itemToSelect);
            }
        }

        public void SelectFirstItem()
        {
            if(_items != null && _items.Count > 0)
            {
                var firstMenuItem = _items.ElementAt(0);
                SelectIten(firstMenuItem);
            }
        }

        public MenuItem GetSelectedItem()
        {
            return _items.FirstOrDefault(itm => itm.IsSelected);
        }

        private void SelectIten(MenuItem itemToSelect)
        {
            DeselectAllItems();

            itemToSelect.IsSelected = true;
        }

        private void DeselectAllItems()
        {
            foreach (var menuItem in _items)
            {
                menuItem.IsSelected = false;
            }
        }
    }
}