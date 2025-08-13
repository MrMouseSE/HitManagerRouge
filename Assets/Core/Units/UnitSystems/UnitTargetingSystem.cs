using System.Collections.Generic;
using Core.GameplayControllers;
using UnityEngine;

namespace Core.Units.UnitSystems
{
    public class UnitTargetingSystem : IUnitSystem
    {
        public void UpdateUnit(UnitsController context, float deltaTime, UnitValuesContainer unitValuesContainer)
        {
            if (unitValuesContainer.Target == null) unitValuesContainer.IsTargetLocked = false;
            if (unitValuesContainer.IsTargetLocked) return;
            List<IPlayableUnit> targetsList = context.GetUnitsList(!unitValuesContainer.IsEnemy);
            if (targetsList.Count < 1) return;
            unitValuesContainer.Target = targetsList[Random.Range(0, targetsList.Count)];
            unitValuesContainer.IsTargetLocked = true;
        }
    }
}