using System.Collections.Generic;

namespace Core.PlayerActionsScripts.PlayerSkills
{
    public static class PlayerSkillsStaticFactory
    {
        public static List<IPlayerSkill> CreatePlayerSkills()
        {
            return CreateUnitHealPlayerSkill();
        }

        private static List<IPlayerSkill> CreateUnitHealPlayerSkill()
        {
            HealUnitPlayerSkill healUnitPlayerSkill = new HealUnitPlayerSkill();
            List<IPlayerSkill> playerSkills = new List<IPlayerSkill>();
            playerSkills.Add(healUnitPlayerSkill);
            return playerSkills;
        }
    }
}