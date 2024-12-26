using System.Collections.Generic;

/// <summary>
/// Model component of the inventory MVC system. Handles the data and logic of the inventory.
/// </summary>
public class InventoryModel
{
    // List to store the items in the inventory.
    private List<ItemData> items = new List<ItemData>();

    /// <summary>
    /// Adds an item to the inventory. If the item already exists, it increases the quantity.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="quantity">The quantity of the item.</param>
    public void AddItem(string name, int quantity)
    {
        var existingItem = items.Find(i => i.Name == name);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            items.Add(new ItemData { Name = name, Quantity = quantity });
        }
    }

    /// <summary>
    /// Removes a specified quantity of an item from the inventory. If the quantity becomes zero or less, the item is removed.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="quantity">The quantity to remove.</param>
    public void RemoveItem(string name, int quantity)
    {
        var item = items.Find(i => i.Name == name);
        if (item != null)
        {
            item.Quantity -= quantity;
            if (item.Quantity <= 0)
            {
                items.Remove(item);
            }
        }
    }

    /// <summary>
    /// Gets a list of all items in the inventory.
    /// </summary>
    /// <returns>A list of ItemData representing the items in the inventory.</returns>
    public List<ItemData> GetItems()
    {
        return new List<ItemData>(items);
    }
}
