using Lumberjack.HealthSystem;
using Lumberjack.Inventory;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class BreakableObject : MonoBehaviour
{   
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }
    private void OnEnable()
    {
        _health.DamageReceived += HandleReceivedDamage;
    }
    private void OnDisable()
    {
        _health.DamageReceived -= HandleReceivedDamage;
    }
   
    public void HandleReceivedDamage(object sender, TakeDamageEventArgs eventArgs)
    {
        var inventory = eventArgs.From.GetComponent<IInventory>();
        var itemProvider = GetComponent<IInventoryItemProvider>();

        itemProvider.InventoryItem.data.amount = eventArgs.PercentageDamage;
        inventory.TakeItem(itemProvider.InventoryItem);
    }
}
