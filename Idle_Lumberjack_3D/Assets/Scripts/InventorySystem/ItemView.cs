using UnityEngine;
using UnityEngine.UI;
namespace Lumberjack.Inventory
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private Text amountText;

        public void UpdateView(ItemData data)
        {
            amountText.text = ((int)data.amount).ToString();
        }
    }
}