using Core.Units.UnitsValues;
using UnityEngine;

namespace Core.Units
{
    public interface IPlayableUnit
    {
        public void SetUnitValues(UnitValuesContainer unitValuesContainer);
        public Vector3 GetPosition();
        public bool IsPositionOverlapByUnit(Vector3 position, float radius);
        public void HitUnit(UnitDamage[] incomeDamages);
        public void HealUnit(float heal);
        public void SetTarget(IPlayableUnit target);
        public bool TryToUpdateUnit(float deltaTime);
        public void DestroyUnit();
    }
}
