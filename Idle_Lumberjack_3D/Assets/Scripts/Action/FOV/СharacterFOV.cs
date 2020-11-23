using Lumberjack.Actions.Combat;
using System.Collections.Generic;
using UnityEngine;

namespace Lumberjack.Actions
{
    public class СharacterFOV : MonoBehaviour
    {
        [SerializeField] private GameObjectsContainer objectsInFOV;
        [SerializeField] private string reqierdTag = "Enemy";

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(reqierdTag))
            {
                objectsInFOV.Add(other.gameObject);
               
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(reqierdTag))
            {
                objectsInFOV.Remove(other.gameObject);
            }
        }
    }
}