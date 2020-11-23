using UnityEngine;
public class Wallet : MonoBehaviour
{
    [SerializeField] FloatReference goldAmount;

    public GameEvent GoldAdded;
    public GameEvent GoldSpent;
    public GameEvent GoldAmountChanged;
    public void AddMoney(float amount)
    {
        if (amount > 0)
        {
            goldAmount.Value += amount;
            GoldAdded.Raise();
            GoldAmountChanged.Raise();

        }
    }
    public void SpendMoney(float amount)
    {
        if (HasEnoughMoney(amount))
        {
            goldAmount.Value -= amount;
            GoldSpent.Raise();
            GoldAmountChanged.Raise();
        }
    }
    public bool HasEnoughMoney(float amount)
    {
        return goldAmount.Value >= amount;
    }
}

