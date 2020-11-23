using Lumberjack.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantShop : MonoBehaviour
{
    [SerializeField] TriggerRegion zoneTrigger;
    public GameEvent OnSaled;
    private void OnEnable()
    {
        zoneTrigger.EnterZone += Sale;

    }
    private void OnDisable()
    {
        zoneTrigger.EnterZone -= Sale;
    }
    private void Sale(GameObject player)
    {
        var inventoryKeeper = player.GetComponent<IInventory>();
        var wallet = player.GetComponent<Wallet>();
        var inventory = inventoryKeeper.GetInventoryReference().items;
        for (int i = 0; i < inventory.Count; i++)
        {
            var itemsToSaleAmount = inventory[i].data.amount;
            var resultReward =(int)(inventory[i].data.price * itemsToSaleAmount);
            wallet.AddMoney(resultReward);
            inventory[i].data.amount -= itemsToSaleAmount;
            OnSaled.Raise();
        }
    }

}
