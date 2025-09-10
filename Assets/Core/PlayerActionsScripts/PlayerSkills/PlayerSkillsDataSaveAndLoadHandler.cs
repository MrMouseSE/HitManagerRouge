using System;
using System.Collections.Generic;
using Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions;
using UnityEngine;

namespace Core.PlayerActionsScripts.PlayerSkills
{
    public static class PlayerSkillsDataSaveAndLoadHandler
    {
        public static void SaveSkillData(PlayerSkillCurrentData skillData)
        {
            PlayerPrefs.SetInt(skillData.SkillsTypes.ToString(), skillData.SkillCurrentLevel);
        }

        public static PlayerSkillsDataHolder GetSkillsData()
        {
            PlayerSkillsDataHolder skillDataHolder = new PlayerSkillsDataHolder();
            skillDataHolder.PlayerCurrentSkills = new List<PlayerSkillCurrentData>();
            foreach (var value in Enum.GetValues(typeof(PlayerSkillsTypes)))
            {
                PlayerSkillCurrentData skillCurrentData = new PlayerSkillCurrentData();
                skillCurrentData.SkillsTypes = (PlayerSkillsTypes)value;
                skillCurrentData.SkillCurrentLevel = PlayerPrefs.GetInt(skillCurrentData.SkillsTypes.ToString(), -1);
                if (skillCurrentData.SkillCurrentLevel < 0) continue;
                skillDataHolder.PlayerCurrentSkills.Add(skillCurrentData);
            }
            return skillDataHolder;
        }
    }
}