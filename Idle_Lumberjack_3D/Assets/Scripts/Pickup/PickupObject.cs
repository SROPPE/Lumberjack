using Lumberjack.Control;
using Lumberjack.Pickup.Config;
using System;
using UnityEngine;

namespace Lumberjack.Pickup
{
    public class PickupObject : MonoBehaviour
    {
        public string requiredTag = "Player";
        public event Action PickedUp;
        public PickupObjectConfig pickupObjectConfig;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(requiredTag))
            {
                pickupObjectConfig.ApplyPickup(other.gameObject);
                PickedUp?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
