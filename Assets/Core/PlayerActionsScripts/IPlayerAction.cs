using Core.GameplayControllers;
using Core.PlayerActionsScripts.PlayerSkills;

namespace Core.PlayerActionsScripts
{
    public interface IPlayerAction
    {
        public void SetPlayerSkillsToAction(IPlayerSkill playerSkill);
        
        public void UpdatePlayerAction(GameplayControllersHandler context, float deltaTime);
    }
}
