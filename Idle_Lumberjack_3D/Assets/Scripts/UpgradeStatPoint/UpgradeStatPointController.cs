using Lumberjack.Stats;
using UnityEngine;

public class UpgradeStatPointController : MonoBehaviour
{
    [SerializeField] private TriggerRegion zoneTrigger;
    [SerializeField] private UpgradeStatPointData data;
    [SerializeField] private UpgradeStatPointView viewPrefab;
    [SerializeField] private Transform viewParent;
    [SerializeField] private Stat statType;
    
    private BaseStats _statsToUpgrade;

    private UpgradeStatPointView _upgradeStatPointView;
    private Wallet _playerWallet;

    private void OnEnable()
    {
        zoneTrigger.EnterZone += StartProcessing;
        zoneTrigger.LeaveZone += EndProcessing;
    }
    private void OnDisable()
    {
        zoneTrigger.EnterZone -= StartProcessing;
        zoneTrigger.LeaveZone -= EndProcessing;
    }
    private void StartProcessing(GameObject player)
    {
        _playerWallet = player.GetComponent<Wallet>();
        _statsToUpgrade = player.GetComponent<IStatsProvider>().stats;
        EnableView();
    }
    private void EndProcessing(GameObject player)
    {
        _upgradeStatPointView.InteractableButton.onClick.RemoveListener(UpgradeStat);
        _upgradeStatPointView.gameObject.SetActive(false);
    }

    private void EnableView()
    {
        if (_upgradeStatPointView == null)
        {
            var view = Instantiate(viewPrefab, viewParent);
            _upgradeStatPointView = view;
        }
        _upgradeStatPointView.gameObject.SetActive(true);
        SetViewActions();

        UpdateView();
    }
    
    private void SetViewActions()
    {
        _upgradeStatPointView.InteractableButton.onClick.AddListener(UpgradeStat);
    }

    private void UpgradeStat()
    {
        _playerWallet.SpendMoney(_statsToUpgrade.CalculateStatWithoutModifiers(Stat.GoldRequired, _statsToUpgrade.GetStatLevel(statType)));
        _statsToUpgrade.UpgradeStat(statType);

        UpdateView();
    }

    private void UpdateView()
    {
        UpdatePlayerCapabillity();
        PrepareDataForUpdate();

        _upgradeStatPointView.UpdateView(data);
    }
    private void PrepareDataForUpdate()
    {
        data.currentStatLevel = _statsToUpgrade.GetStatLevel(statType).ToString();
        data.currentStatSize = _statsToUpgrade.CalculateStatWithoutModifiers(statType, _statsToUpgrade.GetStatLevel(statType)).ToString();

        float requiredGold = _statsToUpgrade.CalculateStatWithoutModifiers(Stat.GoldRequired, _statsToUpgrade.GetStatLevel(statType));

        data.goldRequired = requiredGold.ToString();
        data.statUpgradeSize = _statsToUpgrade.GetUpgradedStatValue(statType, 1).ToString();
    }

    private void UpdatePlayerCapabillity()
    {
        float requiredGold = _statsToUpgrade.CalculateStatWithoutModifiers(Stat.GoldRequired, _statsToUpgrade.GetStatLevel(statType));

        if (_playerWallet.HasEnoughMoney(requiredGold))
        {
            _upgradeStatPointView.InteractableButton.interactable = true;
        }
        else
        {
            _upgradeStatPointView.InteractableButton.interactable = false;
        }
    }
}
