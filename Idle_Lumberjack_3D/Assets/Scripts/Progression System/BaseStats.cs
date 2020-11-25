using System.Collections.Generic;
using UnityEngine;

namespace Lumberjack.Stats
{
    [CreateAssetMenu(fileName = "BaseStats", menuName = "BaseStats/Create New")]
    public class BaseStats : ScriptableObject
    {
        [SerializeField] CharacterType character;
        [SerializeField] Progression progression;
        [SerializeField] bool canUseModifiers = false;

        public List<IModifierProvider> applyModifiers = new List<IModifierProvider>();

        private Dictionary<Stat, int> _statLevel;

        public int GetStatLevel(Stat stat)
        {
            FillStats();
            return _statLevel[stat];
        }
        public void UpgradeStat(Stat stat)
        {
            FillStats();
            _statLevel[stat]++;
        }
        public float GetUpgradedStatValue(Stat stat, int additionLevel)
        {
            FillStats();
            float statWithAdditionLevel = CalculateStatWithoutModifiers(stat, _statLevel[stat] + additionLevel);

            float statValue = CalculateStatWithoutModifiers(stat, _statLevel[stat]);

            float result = statWithAdditionLevel - statValue;
            return result;
        }
        public float GetStat(Stat stat)
        {
            FillStats();
            if (canUseModifiers)
            {
                return CalculateStatWithModifiers(stat, _statLevel[stat]);
            }

            return CalculateStatWithoutModifiers(stat, _statLevel[stat]);
        }

        private void FillStats()
        {
            if (_statLevel != null) return;
            _statLevel = new Dictionary<Stat, int>();
            var stats = progression.GetStatsForCharacter(character);
            foreach (var stat in stats)
            {
                _statLevel.Add(stat, 1);
            }

        }
        public float CalculateStatWithModifiers(Stat stat, int statLevel)
        {
            FillStats();
            float result = (progression.GetStat(character, stat, statLevel) + GetResultAdditiveModifier(stat)) *
                  (1 + GetResultPercentageModifier(stat) / 100);
            return result;
        }
        public float CalculateStatWithoutModifiers(Stat stat, int statLevel)
        {
            FillStats();
            float result = progression.GetStat(character, stat, statLevel);
            return result;
        }

        public float GetResultAdditiveModifier(Stat stat)
        {
            FillStats();
            float result = 0f;
            foreach (var modifierProvider in applyModifiers)
            {
                foreach (float modifier in modifierProvider.GetAdditiveModifiers(stat))
                {
                    result += modifier;
                }
            }
            return result;
        }
        private float GetResultPercentageModifier(Stat stat)
        {
            FillStats();
            float result = 0f;
            foreach (var modifierProvider in applyModifiers)
            {
                foreach (float modifier in modifierProvider.GetPercentageModifiers(stat))
                {
                    result += modifier;
                }
            }
            return result;
        }
    }
}