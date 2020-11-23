using UnityEngine;
namespace Lumberjack.Inventory
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Runtimeset/Create inventory")]
    public class InventoryReference : RuntimeSet<InventoryItemInfo>
    {

        public GameEvent OnItemAdded;
        public GameEvent OnItemRemoved;
        public GameEvent OnItemSpended;
        public InventoryItemInfo GetItem(string name)
        {
            return items.Find((element) => element.data.itemName == name);
        }
        public override void Add(InventoryItemInfo newItem)
        {
            var storedItem = FindStoredItem(newItem);
            if (items.Contains(storedItem))
            {
                storedItem.GetItemData().AddData(newItem.GetItemData());
            }
            else
            {
                items.Add(newItem);
            }
            OnItemAdded.Raise();
        }
        public override void Remove(InventoryItemInfo item)
        {
            InventoryItemInfo storedItem = FindStoredItem(item);
            if (items.Contains(storedItem))
            {
                if (storedItem.GetItemData().CanRemove(item.GetItemData()))
                {
                    storedItem.GetItemData().RemoveData(item.GetItemData());
                    OnItemSpended.Raise();
                }
            }

        }
        private InventoryItemInfo FindStoredItem(InventoryItemInfo item)
        {
            var stored = items.Find((element) => element.GetItemId() == item.GetItemId());
            if (stored != null)
            {
                return stored;
            }
            return item;
        }
    }
}