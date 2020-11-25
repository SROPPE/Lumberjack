using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeStatPointView : MonoBehaviour
{
    [SerializeField] private Text upgradeSizeText;
    [SerializeField] private Text statLevelText;
    [SerializeField] private Text goldRequiredText;
    [SerializeField] private Text currentStatSizeText;
    [SerializeField] private Button interactableButton;

    Dictionary<Text, string> textStaticPart;
    public Button InteractableButton => interactableButton;
    private void Awake()
    {
        textStaticPart = new Dictionary<Text, string>();
        textStaticPart.Add(upgradeSizeText, upgradeSizeText.text);
        textStaticPart.Add(statLevelText, statLevelText.text);
        textStaticPart.Add(goldRequiredText, goldRequiredText.text);
        textStaticPart.Add(currentStatSizeText, currentStatSizeText.text);
    }

    public void UpdateView(UpgradeStatPointData data)
    {
        upgradeSizeText.text = textStaticPart[upgradeSizeText] + data.statUpgradeSize;
        statLevelText.text = textStaticPart[statLevelText] + data.currentStatLevel;
        goldRequiredText.text = textStaticPart[goldRequiredText] + data.goldRequired;
        currentStatSizeText.text = textStaticPart[currentStatSizeText] + data.currentStatSize;

    }
}
