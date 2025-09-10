using System.Collections.Generic;

namespace Core.DummyScripts
{
    [System.Serializable]
    public class UnitData
    {
        public string NameId { get; set; }
        public int Level { get; set; } = 2;
        public int SkillPoints { get; set; } = 5;
        public HashSet<int> UnlockedSkillIDs = new();
        
        public bool HasItem(int requiredItemID)
        {
            throw new System.NotImplementedException();
        }

        public bool IsSkillUnlocked(int requiredSkillSkillID)
        {
            throw new System.NotImplementedException();
        }
    }
}