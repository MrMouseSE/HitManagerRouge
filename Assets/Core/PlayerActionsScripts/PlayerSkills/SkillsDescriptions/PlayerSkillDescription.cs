using System;

namespace Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions
{
    [Serializable]
    public class PlayerSkillDescription
    {
        public int SkillLevel;
        public float HealAmount;
        public float HitAmount;
        public float Cooldown;
    }
}