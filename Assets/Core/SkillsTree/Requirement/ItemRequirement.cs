using Core.DummyScripts;
using UnityEngine;

namespace Core.SkillsTree.Requirement
{
    [CreateAssetMenu(fileName = "New Item Requirement", menuName = "Skills/Requirements/Item Skill Requirement")]
    public class ItemRequirement : UnlockRequirement
    {
        public int RequiredItemID;
        public override bool IsMet(UnitData unitData) => unitData.HasItem(RequiredItemID);
        public override string GetDescription() => $"Требуется предмет: {RequiredItemID}";
    }
}