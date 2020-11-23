using UnityEngine;
using UnityEngine.UI;

public class UpgradeStatPointView : MonoBehaviour
{
    [SerializeField] private Text upgradeSizeText;
    [SerializeField] private Text statLevelText;
    [SerializeField] private Text goldRequiredText;
    [SerializeField] private Text currentStatSizeText;
    [SerializeField] private Button interactableButton;

    public Button InteractableButton => interactableButton;

    public void UpdateView(UpgradeStatPointDataWrapper data)
    {
        upgradeSizeText.text = data.statUpgradeSize;
        statLevelText.text = data.currentStatLevel;
        goldRequiredText.text = data.goldRequired;
        currentStatSizeText.text = data.currentStatSize;

    }
}
