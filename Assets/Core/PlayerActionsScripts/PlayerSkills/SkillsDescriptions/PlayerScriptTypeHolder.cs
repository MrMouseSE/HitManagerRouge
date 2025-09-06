using System;
using System.Collections.Generic;

namespace Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions
{
    [Serializable]
    public class PlayerScriptTypeHolder
    {
        public PlayerSkillsType PlayerSkillsType;
        public List<PlayerSkillDescription> PlayerSkillDescriptions;
    }
}