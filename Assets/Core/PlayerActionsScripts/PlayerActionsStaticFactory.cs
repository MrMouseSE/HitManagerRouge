using System.Collections.Generic;
using Core.PlayerActionsScripts.PlayerSkills;

namespace Core.PlayerActionsScripts
{
    public static class PlayerActionsStaticFactory
    {
        public static IPlayerAction CreatePlayerActions(PlayerSkillsDataHolder playerSkillsData)
        {
            return CreateTapPlayerAction(playerSkillsData);
        }

        private static IPlayerAction CreateTapPlayerAction(PlayerSkillsDataHolder playerSkillsData)
        {
            List<IPlayerSkill> playerSkills = new List<IPlayerSkill>();
            foreach (var skillData in playerSkillsData.PlayerCurrentSkills)
            {
                playerSkills.Add(PlayerSkillsStaticFactory.CreatePlayerSkills(skillData));
            }
            TapPlayerAction tapPlayerAction = new TapPlayerAction(playerSkills);
            return tapPlayerAction;
        }
    }
}