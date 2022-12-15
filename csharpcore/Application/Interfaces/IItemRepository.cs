namespace GildedRose;

public interface IItemRepository
{
    public List<Item> GetInventory();

    public Item FindItem(string name);

    public void SaveInventory(List<Item> items);

    public void DeleteItem(string name);
}