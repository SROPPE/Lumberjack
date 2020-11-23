
namespace Lumberjack.Inventory
{
    [System.Serializable]
    public class ItemData : InventoryItemData
    {
        public float amount;
        public string itemName;
        public ItemView currentView;
        public float price;

        public override void AddData(InventoryItemData data)
        {
            var newData = data as ItemData;
            amount += newData.amount;
        }

        public override bool CanRemove(InventoryItemData data)
        {
            var newData = data as ItemData;
            if (amount < newData.amount) return false;
            return true;
        }

        public override void RemoveData(InventoryItemData data)
        {
            var newData = data as ItemData;
            amount -= newData.amount;

        }
        public override void SetData(InventoryItemData data)
        {
            var newData = data as ItemData;
            currentView = newData.currentView;
        }
    }
}