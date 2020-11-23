using Lumberjack.Pickup.Config;
using Lumberjack.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoostersController : MonoBehaviour
{
    [SerializeField] private Transform boostersUIParent;
    [SerializeField] private BaseStats statsForBoost;
    
    Dictionary<string,AppliedBooster> appliedBoosters = new Dictionary<string, AppliedBooster>();
   
    public void TakeBooster(PickupBoosterConfig takedBooster)
    {
        if(appliedBoosters.ContainsKey(takedBooster.boosterName))
        {
            appliedBoosters[takedBooster.boosterName].countdownVisualization.AddRemainingDuration(takedBooster.duration);
        }
        else
        {
            ApplyBooster(takedBooster);
        }
    }

    private void ApplyBooster(PickupBoosterConfig takedBooster)
    {
        statsForBoost.applyModifiers.Add(takedBooster.booster);
        var visualisation = AddBoosterUIVisualization(takedBooster);

        visualisation.CountdownIsOver += DestroyBooster;

        AppliedBooster appliedBooster = new AppliedBooster(visualisation, takedBooster.booster);
        appliedBoosters.Add(takedBooster.boosterName, appliedBooster);
    }

    private UICountdownVisualization AddBoosterUIVisualization(PickupBoosterConfig takedBooster)
    {
        var countdownUI = Instantiate(takedBooster.visualization, boostersUIParent);

        StartCoroutine(countdownUI.StartCountdown(takedBooster.duration, takedBooster.boosterName));

        return countdownUI;
    }

    private void DestroyBooster(string name)
    {
        if(appliedBoosters.ContainsKey(name))
        {
            statsForBoost.applyModifiers.Remove(appliedBoosters[name].booster);
            appliedBoosters.Remove(name);
        }
    }
    private class AppliedBooster
    {
        public AppliedBooster(UICountdownVisualization countdownVisualization, Booster booster)
        {
            this.countdownVisualization = countdownVisualization;
            this.booster = booster;
        }
        public UICountdownVisualization countdownVisualization;
        public Booster booster;
    }
}
