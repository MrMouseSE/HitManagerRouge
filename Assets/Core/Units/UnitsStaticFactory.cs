using Core.Units.UnitSystems;
using UnityEngine;

namespace Core.Units
{
    public static class UnitsStaticFactory
    {
        public static Transform EnemySceneContainer;
        public static Transform PlayerSceneContainer;
        
        private static int _spawnedUnits;
        
        public static IPlayableUnit CreateUnit(UnitSettingsDescription description, Vector3 position, bool isEnemy)
        {
            IPlayableUnit playableUnit = null;
            Transform parentTransform = isEnemy ? EnemySceneContainer : PlayerSceneContainer;
            
            switch (description.UnitType)
            {
                case UnitTypes.Default:
                    playableUnit = CreateDefaultUnit(description, parentTransform, position, isEnemy);
                    break;
            }
            return playableUnit;
        }
        
        
        
        private static IPlayableUnit CreateDefaultUnit(UnitSettingsDescription description, Transform parent, Vector3 position, bool isEnemy)
        {
            IPlayableUnit playableUnit = new DefaultUnit();
            UnitSceneContainer sceneContainer = Object.Instantiate(description.UnitPrefab, position, Quaternion.identity, parent);
            sceneContainer.UnitGameObject.name += _spawnedUnits;
            IUnitSystem[] unitSystems = new IUnitSystem[3];
            unitSystems[0] = new UnitTargetingSystem();
            unitSystems[1] = new UnitHitSystem();
            unitSystems[2] = new SimpleUnitMoveSystem();
            UnitValuesContainer valuesContainer = new UnitValuesContainer(description, position, sceneContainer, unitSystems, isEnemy);
            playableUnit.SetUnitValuesContainer(valuesContainer);
            _spawnedUnits++;
            return playableUnit;
        }
    }
}