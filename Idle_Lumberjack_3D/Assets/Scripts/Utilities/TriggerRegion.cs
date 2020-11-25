using Lumberjack.Control;
using System;
using UnityEngine;

public class TriggerRegion : MonoBehaviour
{
    public event Action<GameObject> EnterZone;
    public event Action<GameObject> LeaveZone;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            EnterZone?.Invoke(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            LeaveZone?.Invoke(other.gameObject);
        }
    }
}
