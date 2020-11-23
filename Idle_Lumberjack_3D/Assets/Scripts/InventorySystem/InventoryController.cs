using System.Collections.Generic;
using UnityEngine;
namespace Lumberjack.Inventory
{
    public class InventoryController : MonoBehaviour, IInventory
    {
        [SerializeField] Transform inventoryParent;
        [SerializeField] InventoryReference inventory;
        List<string> inventoryUI = new List<string>();

        public InventoryReference GetInventoryReference()
        {
            return inventory;
        }
        private void Start()
        {
            UpdateView();
        }
        public void UpdateView()
        {
            foreach (var item in inventory.items)
            {
                if (item.data.currentView)
                    item.data.currentView.UpdateView(item.data);
            }
        }
        public void DropItem(InventoryItemInfo item)
        {
            inventory.Remove(item);
            var currentItemInInventory = inventory.GetItem(item.data.itemName);
            currentItemInInventory.data.currentView.UpdateView(currentItemInInventory.data);

        }

        public void TakeItem(InventoryItemInfo item)
        {

            inventory.Add(item);

            var currentItemInInventory = inventory.GetItem(item.data.itemName);
            string name = currentItemInInventory.data.itemName;
            if (!inventoryUI.Contains(name))
            {
                currentItemInInventory.data.currentView = Instantiate(item.prefabUI, inventoryParent);
                inventoryUI.Add(name);
            }
            currentItemInInventory.data.currentView.UpdateView(currentItemInInventory.data);
        }

    }
}