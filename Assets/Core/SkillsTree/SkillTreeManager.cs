using System.Collections.Generic;
using Core.DummyScripts;
using UnityEngine;

namespace Core.SkillsTree
{
    public class SkillTreeManager : MonoBehaviour 
    {
        public List<SkillView> SkillsView = new();
        
        private UnitData _unitData = new UnitData();
        private HashSet<int> _unlockedSkillIDs = new();

        public bool IsSkillUnlocked(int skillID)
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