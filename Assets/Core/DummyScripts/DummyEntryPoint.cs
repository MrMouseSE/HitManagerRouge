using System.Collections.Generic;
using Core.GameplayControllers;
using Core.Units;
using UnityEngine;

namespace Core.DummyScripts
{
    public class DummyEntryPoint : MonoBehaviour
    {
        
        private List<IGameplayController> _gameplayControllers = new List<IGameplayController>();
        
        private void Awake()
        {
            _gameplayControllers.Add(new UnitsController());
        }

        private void Update()
        {
            foreach (IGameplayController gameplayController in _gameplayControllers)
            {
                gameplayController.UpdateController(Time.deltaTime);
            }
        }

        public void SpawnNewUnit(UnitSettingsDescription description, Vector3 position, bool isEnemy)
        {
            UnitsController unitsController = (UnitsController)_gameplayControllers.Find(x => x.GetType() == typeof(UnitsController));
            unitsController.CreatePlayableUnit(description, position, isEnemy);
        }
    }
}