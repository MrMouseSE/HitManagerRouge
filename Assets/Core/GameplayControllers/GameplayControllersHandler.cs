using System;
using System.Collections.Generic;

namespace Core.GameplayControllers
{
    public class GameplayControllersHandler
    {
        private readonly Dictionary<Type,IGameplayController> _gameplayControllers;

        public GameplayControllersHandler(IGameplayController[] gameplayControllers)
        {
            _gameplayControllers = new Dictionary<Type, IGameplayController>();
            foreach (var gameplayController in gameplayControllers)
            {
                _gameplayControllers.Add(gameplayController.GetType(), gameplayController);
            }
        }

        public void UpdateGameplayControllers(float deltaTime)
        {
            foreach (var gameplayController in _gameplayControllers)
            {
                gameplayController.Value.UpdateController(this, deltaTime);
            }
        }

        public IGameplayController GetGameplayControllerByType(Type type)
        {
            return _gameplayControllers[type];
        }

        public UnitsController GetUnitsController(Type type)
        {
            return _gameplayControllers[type] as UnitsController;
        }

        public PlayerActionsController GetPlayerActionsController(Type type)
        {
            return _gameplayControllers[type] as PlayerActionsController;
        }
    }
}