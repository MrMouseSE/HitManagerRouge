using System.Collections.Generic;
using UnityEngine;

namespace Core.SkillsTree
{
    public class SkillTreeManager : MonoBehaviour 
    {
        private UnitData _unitData;
        private HashSet<string> _unlockedSkillIDs = new HashSet<string>();

        public bool IsSkillUnlocked(string skillID)
        {
            return _unlockedSkillIDs.Contains(skillID);
        }
    
        public bool CanUnlock(SkillData skill)
        {
            if (IsSkillUnlocked(skill.SkillID)) return false;

            foreach (var requirement in skill.UnlockRequirements)
            {
                if (!requirement.IsMet(_unitData))
                {
                    return false;
                }
            }
            return true;
        }

        public void TryUnlockSkill(SkillData skill)
        {
            if (!CanUnlock(skill) || _unitData.SkillPoints < skill.SkillPointsCost)
            {
                Debug.Log("Нельзя изучить навык!");
                return;
            }

            _unitData.SkillPoints -= skill.SkillPointsCost;
            _unlockedSkillIDs.Add(skill.SkillID);
            
            Debug.Log($"Навык {skill.SkillName} изучен!");
        }
    }
}