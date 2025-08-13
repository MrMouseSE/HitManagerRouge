using Core.EnemiesScripts;
using Core.GameplayControllers;
using Core.Units;
using UnityEngine;

namespace Core.DummyScripts
{
    public class DummyEntryPoint : MonoBehaviour
    {
        public int CurrentDifficulty;
        public EnemiesSpawnDescription EnemiesSpawnDescription;
        
        private GameplayControllersHandler _gameplayControllersHandler;
        
        private void Awake()
        {
            
            IGameplayController[] gameplayControllers = new IGameplayController[3]
            {
                new UnitsController(),
                new EnemySpawnController(EnemiesSpawnDescription.EnemiesDifficultyParams.Find(x=>x.Difficulty == CurrentDifficulty)),
                new PlayerActionsController()
            };
            _gameplayControllersHandler = new GameplayControllersHandler(gameplayControllers);
        }

        private void Update()
        {
            _gameplayControllersHandler.UpdateGameplayControllers(Time.deltaTime);
        }

        public void SpawnNewUnit(UnitSettingsDescription description, Vector3 position, bool isEnemy)
        {
            _gameplayControllersHandler.GetUnitsController(
                typeof(UnitsController)).CreatePlayableUnit(description, position, isEnemy);
        }
    }
}