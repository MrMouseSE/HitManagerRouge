using Core.Units;

namespace Core.EnemiesScripts
{
    public class EnemySpawnSettingHandler
    {
        public float Cooldown;
        public float SpawnRadius;
        public int MaximumCount;
        public UnitSettingsDescription UnitSettings;
        public float CurrentCooldown;
        public int CurrentCount;

        public EnemySpawnSettingHandler(EnemyDescriptionData enemiesSpawnDescription)
        {
            Cooldown = enemiesSpawnDescription.Cooldown;
            SpawnRadius = enemiesSpawnDescription.SpawnRadius;
            MaximumCount = enemiesSpawnDescription.MaximumCount;
            UnitSettings = enemiesSpawnDescription.UnitSettings;
            CurrentCooldown = Cooldown;
            CurrentCount = 0;
        }
    }
}