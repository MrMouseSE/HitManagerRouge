using UnityEngine;

namespace Core.SkillsTree.Requirement
{
    [CreateAssetMenu(fileName = "New Level Requirement", menuName = "Skills/Requirements/Level Requirement")]
    public class LevelRequirement : UnlockRequirement
    {
        public int RequiredLevel;
        public override bool IsMet(UnitData unitData) => unitData.Level >= RequiredLevel;
        public override string GetDescription() => $"Требуется уровень: {RequiredLevel}";
    }
}