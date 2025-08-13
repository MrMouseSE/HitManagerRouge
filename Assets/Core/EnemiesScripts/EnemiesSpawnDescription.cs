using System.Collections.Generic;
using UnityEngine;

namespace Core.EnemiesScripts
{
    [CreateAssetMenu(menuName = "Create EnemiesSpawnDescription", fileName = "EnemiesSpawnDescription", order = 0)]
    public class EnemiesSpawnDescription : ScriptableObject
    {
        public List<EnemiesDifficultyParams> EnemiesDifficultyParams;
    }
}