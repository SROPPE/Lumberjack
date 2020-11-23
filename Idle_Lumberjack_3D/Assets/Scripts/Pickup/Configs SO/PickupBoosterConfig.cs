using UnityEngine;
using UnityEngine.Events;
using Lumberjack.Stats;
using System;

namespace Lumberjack.Pickup.Config
{
    [CreateAssetMenu(fileName = "Pickup", menuName = "Pickup/Create New Booster", order = 0)]
    public class PickupBoosterConfig : PickupObjectConfig
    {
        [SerializeField] float _duration;
        [SerializeField] string _boosterName;
        [SerializeField] UICountdownVisualization _visualisation;
        [SerializeField] Booster _boosterProvider;
        public float duration => _duration;
        public string boosterName => _boosterName;
        public UICountdownVisualization visualization => _visualisation;
        public Booster booster => _boosterProvider;

        public override void ApplyPickup(GameObject player)
        {
            player.GetComponent<CharacterBoostersController>().TakeBooster(this);   
        }

    }
}