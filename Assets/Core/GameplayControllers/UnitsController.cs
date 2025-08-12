using System.Collections.Generic;
using Core.Units;
using UnityEngine;

namespace Core.GameplayControllers
{
    public class UnitsController : IGameplayController
    {
        private readonly List<IPlayableUnit> _playerUnits = new List<IPlayableUnit>();
        private readonly List<IPlayableUnit> _enemyUnits = new List<IPlayableUnit>();
        private readonly List<IPlayableUnit> _unitsToRemove = new List<IPlayableUnit>();

        public void CreatePlayableUnit(UnitSettingsDescription description, Vector3 position, bool isEnemy)
        {
            IPlayableUnit playableUnit = UnitsStaticFactory.CreateUnit(description, position, isEnemy);
            if (isEnemy) _enemyUnits.Add(playableUnit);
            else _playerUnits.Add(playableUnit);
        }

        public void UpdateController(float deltaTime)
        {
            foreach (var enemyUnit in _enemyUnits)
            {
                if (enemyUnit.TryToUpdateUnit(deltaTime)) _unitsToRemove.Add(enemyUnit);
            }

            foreach (var playerUnit in _playerUnits)
            {
                if (playerUnit.TryToUpdateUnit(deltaTime)) _unitsToRemove.Add(playerUnit);
            }

            foreach (var playableUnit in _unitsToRemove)
            {
                _playerUnits.Remove(playableUnit);
                _enemyUnits.Remove(playableUnit);
            }

            DestroyUnits();
        }

        private void DestroyUnits()
        {
            for (int i = 0; i < _unitsToRemove.Count; i++)
            {
                _unitsToRemove[i].DestroyUnit();
            }
            _unitsToRemove.Clear();
        }
    }
}