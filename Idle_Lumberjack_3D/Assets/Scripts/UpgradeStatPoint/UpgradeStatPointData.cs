using UnityEngine;

//NeedRefactoring
[CreateAssetMenu(fileName = "Upgrade Stat Point", menuName = "Upgrade Stat Point/Create new")]
public class UpgradeStatPointData : ScriptableObject
{
    public string statUpgradeSize;
    public string currentStatLevel;
    public string goldRequired;
    public string currentStatSize;
}
