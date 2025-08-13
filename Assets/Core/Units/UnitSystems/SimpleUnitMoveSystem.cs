using Core.GameplayControllers;
using UnityEngine;

namespace Core.Units.UnitSystems
{
    public class SimpleUnitMoveSystem : IUnitSystem
    {
        public void UpdateUnit(UnitsController context, float deltaTime, UnitValuesContainer unitValuesContainer)
        {
            if (!unitValuesContainer.IsTargetLocked) return;
            unitValuesContainer.UnitCurrentSpeed = 
                Mathf.Lerp(unitValuesContainer.UnitCurrentSpeed, unitValuesContainer.UnitMaxSpeed, deltaTime);
            Vector3 targetDirection = unitValuesContainer.Target.GetPosition() - unitValuesContainer.UnitPosition;
            unitValuesContainer.UpdatePosition(targetDirection.normalized * (unitValuesContainer.UnitCurrentSpeed * deltaTime));
        }
    }
}