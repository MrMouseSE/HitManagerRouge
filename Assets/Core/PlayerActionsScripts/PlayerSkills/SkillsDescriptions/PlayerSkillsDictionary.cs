using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions
{
    [CreateAssetMenu(menuName = "Create PlayerSkillsDictionary", fileName = "PlayerSkillsDictionary", order = 0)]
    public class PlayerSkillsDictionary : ScriptableObject
    {
        public List<PlayerScriptTypeHolder> SkillDescriptions;

        private void OnValidate()
        {
            foreach (PlayerScriptTypeHolder skillDescriptionHolder in SkillDescriptions)
            {
                foreach (var skillDescription in skillDescriptionHolder.PlayerSkillDescriptions)
                {
                    skillDescription.PlayerSkillsType = skillDescriptionHolder.PlayerSkillsType;
                }
            }
        }
    }
}