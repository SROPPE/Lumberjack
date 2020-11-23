namespace Lumberjack.Inventory
{
    public abstract class InventoryItemData
    {
        public abstract void SetData(InventoryItemData data);
        public abstract void AddData(InventoryItemData data);
        public abstract void RemoveData(InventoryItemData data);
        public abstract bool CanRemove(InventoryItemData data);
    }
    public interface IInventoryStored
    {
        InventoryItemData GetItemData();
        string GetItemId();
    }
}
