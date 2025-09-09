using UnityEngine;

namespace Core.SkillsTree.Requirement
{
    [CreateAssetMenu(fileName = "New Skill Requirement", menuName = "Skills/Requirements/Prerequisite Skill Requirement")]
    public class PrerequisiteSkillRequirement : UnlockRequirement
    {
        public SkillData RequiredSkill;
        public override bool IsMet(UnitData unitData) => unitData.IsSkillUnlocked(RequiredSkill.SkillID);
        public override string GetDescription() => $"Требуется навык: {RequiredSkill.SkillName}";
    }
}