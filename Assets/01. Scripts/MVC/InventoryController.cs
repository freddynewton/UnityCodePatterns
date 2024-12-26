using UnityEngine;

/// <summary>
/// Inventory Controller that handles the interaction between Model and View.
/// </summary>
public class InventoryController : MonoBehaviour
{
    // The model that handles the data and logic of the inventory.
    private InventoryModel model;

    // The view that handles the display of the inventory.
    private InventoryView view;

    void Start()
    {
        // Initialize the model and view.
        model = new InventoryModel();
        view = GetComponent<InventoryView>();

        // Example: Add some initial items
        model.AddItem("Sword", 1);
        model.AddItem("Health Potion", 5);

        // Update the view to reflect the initial state of the model.
        UpdateView();
    }

    /// <summary>
    /// Adds an item to the inventory and updates the view.
    /// </summary>
    /// <param name="itemName">The name of the item.</param>
    /// <param name="quantity">The quantity of the item.</param>
    public void AddItem(string itemName, int quantity)
    {
        model.AddItem(itemName, quantity);
        UpdateView();
    }

    /// <summary>
    /// Removes an item from the inventory and updates the view.
    /// </summary>
    /// <param name="itemName">The name of the item.</param>
    /// <param name="quantity">The quantity to remove.</param>
    public void RemoveItem(string itemName, int quantity)
    {
        model.RemoveItem(itemName, quantity);
        UpdateView();
    }

    /// <summary>
    /// Updates the view to reflect the current state of the model.
    /// </summary>
    private void UpdateView()
    {
        view.UpdateInventoryDisplay(model.GetItems());
    }

    /// <summary>
    /// Example method to demonstrate adding an item via UI button.
    /// </summary>
    public void OnAddItemButtonClicked()
    {
        AddItem("Gold Coin", 10);
    }
}
