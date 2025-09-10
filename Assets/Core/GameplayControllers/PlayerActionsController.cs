using System.Collections.Generic;
using Core.PlayerActionsScripts;
using Core.PlayerActionsScripts.PlayerSkills;
using Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions;

namespace Core.GameplayControllers
{
    public class PlayerActionsController : IGameplayController
    {
        private PlayerSkillsDataHolder _playerSkillsData;
        private readonly List<IPlayerAction> _playerActions;

        public PlayerActionsController(PlayerSkillsDataHolder playerSkillsData)
        {
            //TODO: refactor save and load skills system
            _playerSkillsData = playerSkillsData;
            _playerActions = new List<IPlayerAction> { PlayerActionsStaticFactory.CreatePlayerActions(_playerSkillsData) };
        }

        public void UpdatePlayerSkillsData(PlayerSkillsTypes playerSkillsTypes, int currentLevel)
        {
            var skill = _playerSkillsData.PlayerCurrentSkills.Find(x=>x.SkillsTypes == playerSkillsTypes);
            skill.SkillCurrentLevel = currentLevel;
            //TODO: refactor for update skill information
        }
        
        public void UpdateController(GameplayControllersHandler context, float deltaTime)
        {
            foreach (var playerAction in _playerActions)
            {
                playerAction.UpdatePlayerAction(context, deltaTime);
            }
        }
    }
}
