using System;
using Core.Units;

namespace Core.EnemiesScripts
{
    [Serializable]
    public class EnemyDescriptionData
    {
        public float Cooldown;
        public float SpawnRadius;
        public int MaximumCount;
        public UnitSettingsDescription UnitSettings;
    }
}