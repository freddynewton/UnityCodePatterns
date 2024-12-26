using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// View component of the inventory MVC system. Handles the display of the inventory.
/// </summary>
public class InventoryView : MonoBehaviour
{
    // Prefab for displaying an item in the inventory.
    public GameObject itemPrefab;

    // The parent transform where item displays will be instantiated.
    public Transform contentPanel;

    /// <summary>
    /// Updates the inventory display with the current list of items.
    /// </summary>
    /// <param name="items">The list of items to display.</param>
    public void UpdateInventoryDisplay(List<ItemData> items)
    {
        // Clear existing items
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // Create new item displays
        foreach (var item in items)
        {
            GameObject itemGO = Instantiate(itemPrefab, contentPanel);
            Text itemText = itemGO.GetComponentInChildren<Text>();
            itemText.text = $"{item.Name} x{item.Quantity}";
        }
    }
}
