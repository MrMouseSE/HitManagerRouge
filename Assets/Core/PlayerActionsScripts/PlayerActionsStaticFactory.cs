using System.Collections.Generic;
using Core.PlayerActionsScripts.PlayerSkills;

namespace Core.PlayerActionsScripts
{
    public static class PlayerActionsStaticFactory
    {
        public static IPlayerAction CreatePlayerAction()
        {
            return CreateTapPlayerAction();
        }

        private static IPlayerAction CreateTapPlayerAction()
        {
            List<IPlayerSkill> playerSkills = PlayerSkillsStaticFactory.CreatePlayerSkills();
            TapPlayerAction tapPlayerAction = new TapPlayerAction(playerSkills);
            return tapPlayerAction;
        }
    }
}