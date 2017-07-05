namespace ConsoleLib
{
    internal interface IItemSelector
    {
        MenuItem GetSelectedItem();
        void SelectItemAtPosition(int topPosition);
        void SelectFirstItem();
    }
}