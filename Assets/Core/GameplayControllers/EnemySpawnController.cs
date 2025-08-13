using System.Collections.Generic;
using Core.EnemiesScripts;
using UnityEngine;

namespace Core.GameplayControllers
{
    public class EnemySpawnController : IGameplayController
    {
        private List<EnemySpawnSettingHandler> _enemySpawnSettingHandlers = new ();

        public EnemySpawnController(EnemiesDifficultyParams enemiesDifficultyParams)
        {
            foreach (var enemy in enemiesDifficultyParams.Enemies)
            {
                _enemySpawnSettingHandlers.Add(new EnemySpawnSettingHandler(enemy));
            }
        }

        public void UpdateController(GameplayControllersHandler context, float deltaTime)
        {
            foreach (var enemySpawnSettingHandler in _enemySpawnSettingHandlers)
            {
                enemySpawnSettingHandler.CurrentCooldown -= deltaTime;
                if (enemySpawnSettingHandler.CurrentCooldown < 0 && enemySpawnSettingHandler.CurrentCount < enemySpawnSettingHandler.MaximumCount)
                {
                    var unitsController = (UnitsController)context.GetGameplayControllerByType(typeof(UnitsController));
                    Vector3 spawnPosition = Random.onUnitSphere * enemySpawnSettingHandler.SpawnRadius;
                    spawnPosition.y = 0f;
                    unitsController.CreatePlayableUnit(enemySpawnSettingHandler.UnitSettings,spawnPosition, true);
                    enemySpawnSettingHandler.CurrentCount++;
                    enemySpawnSettingHandler.CurrentCooldown = enemySpawnSettingHandler.Cooldown;
                }
            }
        }
    }
}