using Core.Units;
using UnityEngine;

namespace Core.DummyScripts
{
    public class UnitSpawner : MonoBehaviour
    {
        public DummyEntryPoint EntryPoint;
        public Transform EnemyUnitsHolder;
        public Transform PlayerUnitsHolder;
        public UnitSettingsDescription PlayerUnitDescription;

        private void Start()
        {
            UnitsStaticFactory.EnemySceneContainer = EnemyUnitsHolder;
            UnitsStaticFactory.PlayerSceneContainer = PlayerUnitsHolder;
            CreatePlayerUnits();
        }

        private void CreatePlayerUnits()
        {
            Vector3[] spawnPositions = new Vector3[3]
            {
                new (0, 0, 0),
                new (2, 0, 0),
                new (0, 0, 2),
            };
            foreach (var spawnPosition in spawnPositions)
            {
                SpawnPlayerUnits(PlayerUnitDescription, spawnPosition);
            }
        }

        private void SpawnPlayerUnits(UnitSettingsDescription playerDescription, Vector3 spawnPoint)
        {
            EntryPoint.SpawnNewUnit(playerDescription, spawnPoint, false);
         
        }
    }
}