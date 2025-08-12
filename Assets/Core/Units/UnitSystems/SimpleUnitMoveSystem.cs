using UnityEngine;

namespace Core.Units.UnitSystems
{
    public class SimpleUnitMoveSystem : IUnitSystem
    {
        public void UpdateUnit(float deltaTime, UnitValuesContainer unitValuesContainer)
        {
            if (!unitValuesContainer.IsTargetLocked) return;
            Vector3 targetDirection = unitValuesContainer.Target.GetPosition() - unitValuesContainer.UnitPosition; 
            unitValuesContainer.UnitPosition += targetDirection.normalized * (unitValuesContainer.UnitSpeed * deltaTime);
        }
    }
}