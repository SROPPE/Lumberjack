namespace Lumberjack.Inventory
{
    [System.Serializable]
    public class InventoryItemInfo : IInventoryStored
    {
        public ItemView prefabUI;
        public ItemData data;
        public InventoryItemData GetItemData()
        {
            return data;
        }
        public string GetItemId()
        {
            return data.itemName;
        }
    }
}
