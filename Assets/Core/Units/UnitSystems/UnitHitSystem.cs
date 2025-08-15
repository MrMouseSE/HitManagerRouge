using System.Collections.Generic;
using Core.GameplayControllers;
using UnityEngine;

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
                    var damage = unitValuesContainer.ReturnCalculatedOutcomeDamage();
                    Debug.LogWarning(unitValuesContainer.Prefab.UnitGameObject.name + $" dealt ${damage} damage to " 
                        + targetUnit.GetUnitValuesContainer().Prefab.UnitGameObject.name);
                    targetUnit.HitUnit(damage);
                    unitValuesContainer.UnitCurrentSpeed -= unitValuesContainer.UnitMaxSpeed * unitValuesContainer.UnitBouncePower;
                }
            }
        }
    }
}