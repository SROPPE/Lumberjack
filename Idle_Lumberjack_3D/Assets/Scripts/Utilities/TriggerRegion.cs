using System;
using UnityEngine;

public class TriggerRegion : MonoBehaviour
{
    [SerializeField] private string requiredTag = "Player";
    public event Action<GameObject> EnterZone;
    public event Action<GameObject> LeaveZone;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            EnterZone?.Invoke(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            LeaveZone?.Invoke(other.gameObject);
        }
    }
}
