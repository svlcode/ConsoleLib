using System;

namespace ConsoleLib
{
    internal class KeyToMenuActionConverter
    {
        public event EventHandler<NavigationArgs> Navigate;
        public event EventHandler StartItemAction;
        public event EventHandler CloseMenu;

        public KeyToMenuActionConverter()
        {
            
        }

        public void ReadKeys()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            while (key != ConsoleKey.Escape)
            {
                if (key == ConsoleKey.Enter)
                {
                    OnStartItemAction();
                }
                else
                {
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            OnNavigate(NavigationDirectionEnum.Previous);
                            break;
                        case ConsoleKey.DownArrow:
                            OnNavigate(NavigationDirectionEnum.Next);
                            break;
                        case ConsoleKey.PageUp:
                            OnNavigate(NavigationDirectionEnum.First);
                            break;
                        case ConsoleKey.PageDown:
                            OnNavigate(NavigationDirectionEnum.Last);
                            break;
                    }
                }

                key = Console.ReadKey(true).Key;
            }
            Console.Clear();
        }

        private void OnStartItemAction()
        {
            if (StartItemAction != null)
            {
                StartItemAction(this, EventArgs.Empty);
            }
        }

        private void OnNavigate(NavigationDirectionEnum direction)
        {
            if (Navigate != null)
            {
                Navigate(this, new NavigationArgs(direction));
            }
        }
    }
}