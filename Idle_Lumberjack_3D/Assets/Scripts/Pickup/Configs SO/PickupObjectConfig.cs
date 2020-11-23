using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjectConfig : ScriptableObject
{
    public UnityEngine.GameObject _pickupPrefab;
    public virtual void ApplyPickup(UnityEngine.GameObject player)
    {

    }
}
