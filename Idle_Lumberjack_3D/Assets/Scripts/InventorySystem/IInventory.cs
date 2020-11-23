namespace Lumberjack.Inventory
{
    public interface IInventory
    {
        void TakeItem(InventoryItemInfo item);
        void DropItem(InventoryItemInfo item);
        InventoryReference GetInventoryReference();
    }
}