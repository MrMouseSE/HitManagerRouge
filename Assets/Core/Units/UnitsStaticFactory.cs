using Core.Units.UnitSystems;
using UnityEngine;

namespace Core.Units
{
    public static class UnitsStaticFactory
    {
        public static Transform EnemySceneContainer;
        public static Transform PlayerSceneContainer;
        
        public static IPlayableUnit CreateUnit(UnitSettingsDescription description, Vector3 position, bool isEnemy)
        {
            IPlayableUnit playableUnit = null;
            Transform parentTransform = isEnemy ? EnemySceneContainer : PlayerSceneContainer;
            
            switch (description.UnitType)
            {
                case UnitTypes.Default:
                    playableUnit = CreateDefaultUnit(description, parentTransform, position);
                    break;
            }
            return playableUnit;
        }
        
        private static IPlayableUnit CreateDefaultUnit(UnitSettingsDescription description, Transform parent, Vector3 position)
        {
            IPlayableUnit playableUnit = new DefaultUnit();
            UnitSceneContainer sceneContainer = Object.Instantiate(description.UnitPrefab, parent);
            sceneContainer.UnitTransform.localPosition = position;
            IUnitSystem[] unitSystems = new IUnitSystem[1];
            unitSystems[0] = new SimpleUnitMoveSystem();
            UnitValuesContainer valuesContainer = new UnitValuesContainer(description, sceneContainer, unitSystems);
            playableUnit.SetUnitValues(valuesContainer);
            return playableUnit;
        }
    }
}