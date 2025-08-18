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
            Vector3 targetDirection = (unitValuesContainer.Target.GetPosition() - unitValuesContainer.UnitCurrentPosition).normalized;
            unitValuesContainer.UpdateUnitMoveDirection(targetDirection);
            unitValuesContainer.MoveUnitByVector(unitValuesContainer.UnitCurrentDirection * (unitValuesContainer.UnitCurrentSpeed * deltaTime));
        }
    }
}