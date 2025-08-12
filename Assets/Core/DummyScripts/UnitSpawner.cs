using Core.Units;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.DummyScripts
{
    public class UnitSpawner : MonoBehaviour
    {
        public float SpawnRadius;
        public float SpawnCooldown;
        public UnitSettingsDescription EnemyDescription;
        public UnitSettingsDescription PlayerDescription;
        public DummyEntryPoint EntryPoint;
        public Transform EnemyUnitsHolder;
        public Transform PlayerUnitsHolder;
        
        private float _currentCooldown;

        private void Start()
        {
            UnitsStaticFactory.EnemySceneContainer = EnemyUnitsHolder;
            UnitsStaticFactory.PlayerSceneContainer = PlayerUnitsHolder;
            _currentCooldown = SpawnCooldown;
        }

        private void Update()
        {
            _currentCooldown -= Time.deltaTime;
            if (_currentCooldown > 0f) return;
            Vector3 spawnPosition = Random.onUnitSphere * SpawnRadius;
            spawnPosition.y = 0f;

            bool isEnemy = Random.value < 0.8f;
            var currentDescription = isEnemy? EnemyDescription : PlayerDescription;
            EntryPoint.SpawnNewUnit(currentDescription, spawnPosition, isEnemy);
            _currentCooldown = SpawnCooldown;
        }
    }
}