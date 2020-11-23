using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : MonoBehaviour
{
    [SerializeField] string requierdTag = "Enemy";
    [SerializeField] GameObjectsContainer enemiesInAttackRange;
    private void OnTriggerEnter(Collider other)
    {
        if(PathedCondition(other))
        {
            enemiesInAttackRange.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (PathedCondition(other))
        {
           enemiesInAttackRange.Remove(other.gameObject);
        }
    }
    private bool PathedCondition(Collider other)
    {
        return other.CompareTag(requierdTag);
    }
}
