using System.Collections.Generic;
using Core.PlayerActionsScripts;

namespace Core.GameplayControllers
{
    public class PlayerActionsController : IGameplayController
    {
        private List<IPlayerAction> _playerActions;
        
        public void UpdateController(GameplayControllersHandler context, float deltaTime)
        {
            foreach (var playerAction in _playerActions)
            {
                playerAction.UpdatePlayerAction(context, deltaTime);
            }
        }
    }
}
