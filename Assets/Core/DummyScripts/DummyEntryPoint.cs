using Core.EnemiesScripts;
using Core.GameplayControllers;
using Core.PlayerActionsScripts.PlayerInputLibrary;
using Core.PlayerActionsScripts.PlayerSkills;
using Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions;
using Core.Units;
using Core.UserInterfaceViewScripts;
using UnityEngine;

namespace Core.DummyScripts
{
    public class DummyEntryPoint : MonoBehaviour
    {
        public Camera BattleSceneCamera;
        public int CurrentDifficulty;
        public EnemiesSpawnDescription EnemiesSpawnDescription;
        public PlayerSkillsDictionary PlayerSkillsDictionary;
        
        private GameplayControllersHandler _gameplayControllersHandler;
        
        private void Awake()
        {
            PlayerSkillsStaticFactory.PlayerSkillsDictionary = PlayerSkillsDictionary;
            PlayerInputHandler.RayCastCamera = BattleSceneCamera;
            PlayerSkillsDataHolder playerSkillsDataHolder = PlayerSkillsDataSaveAndLoadHandler.GetSkillsData();
            IGameplayController[] gameplayControllers = new IGameplayController[4]
            {
                new UnitsController(),
                new EnemySpawnController(EnemiesSpawnDescription.EnemiesDifficultyParams.Find(x=>x.Difficulty == CurrentDifficulty)),
                new UserInterfaceViewController(playerSkillsDataHolder),
                new PlayerActionsController(playerSkillsDataHolder),
                
            };
            _gameplayControllersHandler = new GameplayControllersHandler(gameplayControllers);
        }

        private void Update()
        {
            _gameplayControllersHandler.UpdateGameplayControllers(Time.deltaTime);
        }

        public void SpawnNewUnit(UnitSettingsDescription description, Vector3 position, bool isEnemy)
        {
            UnitsController unitsController = (UnitsController)_gameplayControllersHandler.GetGameplayControllerByType(typeof(UnitsController));
            unitsController.CreatePlayableUnit(description, position, isEnemy);
        }
    }
}