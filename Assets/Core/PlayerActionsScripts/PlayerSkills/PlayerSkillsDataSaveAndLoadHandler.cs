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
            PlayerPrefs.SetInt(skillData.SkillsType.ToString(), skillData.SkillCurrentLevel);
        }

        public static PlayerSkillsDataHolder GetSkillsData()
        {
            PlayerSkillsDataHolder skillDataHolder = new PlayerSkillsDataHolder();
            skillDataHolder.PlayerCurrentSkills = new List<PlayerSkillCurrentData>();
            foreach (var value in Enum.GetValues(typeof(PlayerSkillsType)))
            {
                PlayerSkillCurrentData skillCurrentData = new PlayerSkillCurrentData();
                skillCurrentData.SkillsType = (PlayerSkillsType)value;
                skillCurrentData.SkillCurrentLevel = PlayerPrefs.GetInt(skillCurrentData.SkillsType.ToString(), 0);
                skillDataHolder.PlayerCurrentSkills.Add(skillCurrentData);
            }
            return skillDataHolder;
        }
    }
}