namespace Core.SkillsTree
{
    public class UnitData
    {
        public int Level { get; set; }
        public int SkillPoints { get; set; }
        
        public bool HasItem(string requiredItemID)
        {
            throw new System.NotImplementedException();
        }

        public bool IsSkillUnlocked(string requiredSkillSkillID)
        {
            throw new System.NotImplementedException();
        }
    }
}