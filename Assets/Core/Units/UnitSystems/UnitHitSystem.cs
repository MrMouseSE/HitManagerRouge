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
                if (targetUnit.GetUnitValuesContainer().Prefab.UnitCollider.bounds.Intersects(unitValuesContainer.Prefab.UnitCollider.bounds))
                {
                    targetUnit.HitUnit(unitValuesContainer.ReturnCalculatedOutcomeDamage());
                    unitValuesContainer.UnitCurrentSpeed -=
                        unitValuesContainer.UnitMaxSpeed * unitValuesContainer.UnitBouncePower;
                }
            }
        }
    }
}