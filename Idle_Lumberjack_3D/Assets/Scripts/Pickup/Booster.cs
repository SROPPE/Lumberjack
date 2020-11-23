using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lumberjack.Stats;
public class Booster : MonoBehaviour, IModifierProvider
{
    [SerializeField] private Stat modifiedStat;
    [SerializeField] private float additiveModifier = 0f;
    [SerializeField] private float percentageModifier = 0f;
    public IEnumerable<float> GetAdditiveModifiers(Stat stat)
    {
        if (stat == modifiedStat)
        {
            yield return additiveModifier;
        }
    }

    public IEnumerable<float> GetPercentageModifiers(Stat stat)
    {
        if (stat == modifiedStat)
        {
            yield return percentageModifier;
        }
    }
}
