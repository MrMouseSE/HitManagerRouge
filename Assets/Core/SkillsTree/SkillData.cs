using System.Collections.Generic;
using Core.SkillsTree.Requirement;
using UnityEngine;

namespace Core.SkillsTree
{
    [CreateAssetMenu(fileName = "New Skill", menuName = "Skills/Skill Data")]
    public class SkillData : ScriptableObject
    {
        public string SkillID;
        public string SkillName;
        public string Description;
        public int SkillPointsCost;
        public List<UnlockRequirement> UnlockRequirements = new();
    }
}