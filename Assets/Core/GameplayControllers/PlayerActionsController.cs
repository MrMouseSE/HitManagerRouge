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

        public PlayerActionsController()
        {
            //TODO: refactor save and load skills system
            _playerSkillsData = PlayerSkillsDataSaveAndLoadHandler.GetSkillsData();
            _playerActions = new List<IPlayerAction> { PlayerActionsStaticFactory.CreatePlayerActions(_playerSkillsData) };
        }

        public void UpdatePlayerSkillsData(PlayerSkillsType playerSkillsType, int currentLevel)
        {
            var skill = _playerSkillsData.PlayerCurrentSkills.Find(x=>x.SkillsType == playerSkillsType);
            skill.SkillCurrentLevel = currentLevel;
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
