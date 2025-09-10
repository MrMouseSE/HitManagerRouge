using System;
using System.Collections.Generic;

namespace Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions
{
    [Serializable]
    public class PlayerScriptTypeHolder
    {
        public PlayerSkillsTypes PlayerSkillsType;
        public List<PlayerSkillDescription> PlayerSkillDescriptions;
    }
}