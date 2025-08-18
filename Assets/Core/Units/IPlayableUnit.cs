using Core.GameplayControllers;
using Core.Units.UnitsValues;
using UnityEngine;

namespace Core.Units
{
    public interface IPlayableUnit
    {
        public void SetUnitValuesContainer(UnitValuesContainer unitValuesContainer);
        public Vector3 GetPosition();
        public bool IsPositionOverlapByUnit(Vector3 position, float radius);
        public void HitUnit(UnitDamage[] incomeDamages);
        public void HealUnit(float heal);
        public bool TryToUpdateUnit(UnitsController context, float deltaTime);
        public UnitValuesContainer GetUnitValuesContainer();
        public void DestroyUnit();
    }
}
