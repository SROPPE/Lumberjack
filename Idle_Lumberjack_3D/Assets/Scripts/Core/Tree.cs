using Lumberjack.HealthSystem;
using Lumberjack.Inventory;
using Lumberjack.Stats;
using UnityEngine;

//Need refactoring
public class Tree : MonoBehaviour, IInventoryItemProvider
{
    public int levelOffset;
    [SerializeField] int chunkStages;
    [SerializeField] InventoryItemInfo inventoryItem;
    [SerializeField] Progression progression;
    [SerializeField] CharacterType characterType;
    [SerializeField] IntReference currentChunkLevel;
    public InventoryItemInfo InventoryItem => inventoryItem;

    private int currentLevel;
   
    private void OnEnable()
    {
        currentLevel = levelOffset + chunkStages*currentChunkLevel.Value;
        GetComponent<Health>().SetHealth(progression.GetStat(characterType, Stat.Health, currentLevel));
        inventoryItem.data.price = progression.GetStat(characterType, Stat.GoldReward, currentLevel);
        inventoryItem.data.itemName = currentLevel.ToString();
    }
}
