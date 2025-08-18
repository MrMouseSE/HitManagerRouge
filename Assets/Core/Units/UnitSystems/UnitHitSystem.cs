using System.Collections.Generic;
using Core.GameplayControllers;

namespace Core.Units.UnitSystems
{
    public class UnitHitSystem : IUnitSystem
    {
        public void UpdateUnit(UnitsController context, float deltaTime, UnitValuesContainer unitValuesContainer)
        {
            List<IPlayableUnit> targetUnits = context.GetUnitsList(!unitValuesContainer.IsEnemy);
            foreach (var targetUnit in targetUnits)
            {
                if (CheckIntersectByRadius(unitValuesContainer, targetUnit.GetUnitValuesContainer()))
                {
                    var damage = unitValuesContainer.ReturnCalculatedOutcomeDamage();
                    targetUnit.HitUnit(damage);
                    unitValuesContainer.MoveToPreviousPosition();
                    unitValuesContainer.UnitCurrentSpeed -= unitValuesContainer.UnitMaxSpeed * unitValuesContainer.UnitBouncePower;
                }
            }
        }

        private bool CheckIntersectByRadius(UnitValuesContainer source, UnitValuesContainer target)
        {
            float squareDistance = (source.UnitCurrentPosition - target.UnitCurrentPosition).sqrMagnitude;
            float summRadius = source.UnitRadius + target.UnitRadius;
            return squareDistance <= summRadius * summRadius;
        }
    }
}