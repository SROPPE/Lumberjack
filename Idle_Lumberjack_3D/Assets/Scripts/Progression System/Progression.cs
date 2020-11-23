using System.Collections.Generic;
using UnityEngine;
namespace Lumberjack.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 1)]
    public class Progression : ScriptableObject
    {
        [SerializeField] List<ProgressionCharacterClass> _charactersProgression;

        private Dictionary<CharacterType, Dictionary<Stat, float[]>> _lookupTable = null;
        
        public float GetStat(CharacterType character, Stat stat, int level)
        {
            BuildLookup();
            float[] levels = _lookupTable[character][stat];
            if (levels.Length <= level - 1)
            {
                return levels[levels.Length-1];
            }
            return levels[level - 1];
        }
        public List<Stat> GetStatsForCharacter(CharacterType character)
        {
            BuildLookup();

            List<Stat> result = new List<Stat>();
            var stats = _lookupTable[character].Keys;

            foreach (var stat in stats)
            {
                result.Add(stat);
            }
            return result;
        }
        public float GetMaxLevel(Stat stat, CharacterType characterClass)
        {
            var levels = _lookupTable[characterClass][stat];
            return levels.Length;
        }

        private void BuildLookup()
        {
            if (_lookupTable != null) return;
            _lookupTable = new Dictionary<CharacterType, Dictionary<Stat, float[]>>();
            foreach (var characterClass in _charactersProgression)
            {
                var statLookupTable = new Dictionary<Stat, float[]>();
                foreach (var progression in characterClass.progressionStat)
                {
                    statLookupTable[progression.stat] = progression.levels;

                }
                _lookupTable[characterClass.character] = statLookupTable;
            }
        }

        [System.Serializable]
        public class ProgressionCharacterClass
        {
            public CharacterType character;
            public ProgressionStat[] progressionStat;
        }
        [System.Serializable]
        public class ProgressionStat
        {
            public Stat stat;
            public float[] levels;
        }


    }
}