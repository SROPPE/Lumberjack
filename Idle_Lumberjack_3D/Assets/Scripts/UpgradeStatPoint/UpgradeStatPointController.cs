using Lumberjack.Stats;
using UnityEngine;
public class UpgradeStatPointDataWrapper
{
    public string statUpgradeSize;
    public string currentStatLevel;
    public string goldRequired;
    public string currentStatSize;
}
public class UpgradeStatPointController : MonoBehaviour
{
    [SerializeField] private TriggerRegion zoneTrigger;
    [SerializeField] private UpgradeStatPointData upgradeStatPointData;
    [SerializeField] private Transform viewParent;
    [SerializeField] private Transform viewPrefab;
    [SerializeField] private Stat statType;
    BaseStats _statsToUpgrade;

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
        _upgradeStatPointView.InteractableButton.onClick.RemoveListener(Upgrade);
        _upgradeStatPointView.gameObject.SetActive(false);
    }

    private void EnableView()
    {
        if (_upgradeStatPointView == null)
        {
            var viewGO = Instantiate(viewPrefab, viewParent);
            _upgradeStatPointView = viewGO.GetComponent<UpgradeStatPointView>();
        }
        _upgradeStatPointView.gameObject.SetActive(true);
        _upgradeStatPointView.InteractableButton.onClick.AddListener(Upgrade);

        UpdateView();
    }
    private void Upgrade()
    {
        _playerWallet.SpendMoney(_statsToUpgrade.CalculateStatWithoutModifiers(Stat.GoldRequired, _statsToUpgrade.GetStatLevel(statType)));
        _statsToUpgrade.UpgradeStat(statType);

        UpdateView();
    }

    private void UpdateView()
    {

        UpdatePlayerCapabillity();
        var data = GetDataForUpdate();

        _upgradeStatPointView.UpdateView(data);
    }

    //Need refactoring
    private UpgradeStatPointDataWrapper GetDataForUpdate()
    {
        UpgradeStatPointDataWrapper data = new UpgradeStatPointDataWrapper();

        data.currentStatLevel = upgradeStatPointData.upgradeStatPointName + _statsToUpgrade.GetStatLevel(statType);
        data.currentStatSize = upgradeStatPointData.currentStatName + _statsToUpgrade.GetStat(statType);

        float requiredGold = _statsToUpgrade.CalculateStatWithoutModifiers(Stat.GoldRequired, _statsToUpgrade.GetStatLevel(statType));
        data.goldRequired = requiredGold.ToString();

        data.statUpgradeSize = "+" + _statsToUpgrade.GetStatUpgradeValue(statType, 1).ToString();

        return data;
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
