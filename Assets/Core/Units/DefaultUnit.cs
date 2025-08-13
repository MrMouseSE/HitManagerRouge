using System;
using Core.GameplayControllers;
using Core.Units.UnitsValues;
using Core.Utils;
using UnityEngine;

namespace Core.Units
{
    public class DefaultUnit : IPlayableUnit
    {
        private UnitValuesContainer _unitValuesContainer;
        
        public void SetUnitValuesContainer(UnitValuesContainer unitValuesContainer)
        {
            _unitValuesContainer = unitValuesContainer;
        }

        public Vector3 GetPosition()
        {
            return _unitValuesContainer.UnitPosition;
        }

        public bool IsPositionOverlapByUnit(Vector3 position, float radius)
        {
             float lenghtSquared = (position - _unitValuesContainer.UnitPosition).magnitude;

             bool overlap = (lenghtSquared < radius || lenghtSquared < _unitValuesContainer.UnitRadius);
             return overlap;
        }

        public void HitUnit(UnitDamage[] incomeDamages)
        {
            _unitValuesContainer.HitUnit(incomeDamages);
        }

        public void HealUnit(float heal)
        {
            _unitValuesContainer.TryChangeCurrentHealthAndReturnIsAlive(heal);
            _unitValuesContainer.Prefab.PlayEffect(PlayableUnitEffectTypes.Heal);
        }

        public void SetTarget(IPlayableUnit target)
        {
            _unitValuesContainer.SetUnitTarget(target);
        }

        public UnitValuesContainer GetUnitValuesContainer()
        {
            return _unitValuesContainer;
        }

        public bool TryToUpdateUnit(UnitsController context, float deltaTime)
        {
            _unitValuesContainer.UpdateSystems(context, deltaTime);
            return _unitValuesContainer.TryChangeCurrentHealthAndReturnIsAlive(0);
        }

        public void DestroyUnit()
        {
            _unitValuesContainer.Destroy();
            GC.SuppressFinalize(this);
        }
    }
}
