using System;
using System.Collections.Generic;
using System.Linq;
using Core.GameplayControllers;
using Core.Units.UnitsValues;
using Core.Units.UnitSystems;
using Core.Utils;
using UnityEngine;

namespace Core.Units
{
    public class UnitValuesContainer
    {
        public float MaximumHealth;
        public float CurrentHealth;
        public float CurrentDamageMultiplier;
        public UnitDamage[] CurrentDamages;
        public float CurrentArmorMultiplier;
        public UnitDamage[] CurrentArmor;
        public bool IsEnemy;
        public float UnitBouncePower;

        public UnitSceneContainer Prefab;
        public Vector3 UnitCurrentPosition;
        public float UnitRadius;
        public float UnitMaxSpeed;
        public bool IsTargetLocked;
        public IPlayableUnit Target;
        public readonly List<UnitValuesContainer> Hunters = new List<UnitValuesContainer>();

        public float UnitCurrentSpeed;
        public Vector3 UnitCurrentDirection = Vector3.zero;
        
        private readonly IUnitSystem[] _unitSystems;
        private Vector3 _previousPosition;

        public UnitValuesContainer(UnitSettingsDescription unitSettingsDescription, Vector3 startPosition, UnitSceneContainer prefab, 
            IUnitSystem[] unitSystems, bool isEnemy)
        {
            Prefab = prefab;
            UnitCurrentPosition = startPosition;
            _previousPosition = UnitCurrentPosition;
            MaximumHealth = unitSettingsDescription.UnitHealth;
            CurrentHealth = MaximumHealth;
            CurrentDamageMultiplier = 1;
            CurrentArmorMultiplier = 1;
            CurrentDamages = unitSettingsDescription.UnitDamages.OrderBy(x=>(int)x.Type).ToArray();
            CurrentArmor = unitSettingsDescription.UnitArmors.OrderBy(x => (int)x.Type).ToArray();
            IsEnemy = isEnemy;
            UnitRadius = Prefab.UnitSphereCollider.radius;
            UnitMaxSpeed = unitSettingsDescription.UnitSpeed;
            UnitBouncePower = unitSettingsDescription.UnitBouncePower;
            _unitSystems = unitSystems;
        }

        public void UpdateSystems(UnitsController context, float deltaTime)
        {
            foreach (var unitSystem in _unitSystems)
            {
                unitSystem.UpdateUnit(context, deltaTime,this);
            }
        }

        public void AddHunter(UnitValuesContainer unitValuesContainer)
        {
            Hunters.Add(unitValuesContainer);
        }

        public void SetUnitTarget(IPlayableUnit target, bool isTargetLocked)
        {
            Target = target;
            IsTargetLocked = isTargetLocked;
            if (!isTargetLocked) return;
            Target.GetUnitValuesContainer().AddHunter(this);
        }

        public void SetCurrentArmorMultiplier(float armorMultiplier)
        {
            CurrentArmorMultiplier = armorMultiplier;
        }

        public void SetCurrentDamageMultiplier(float multiplier)
        {
            CurrentDamageMultiplier = multiplier;
        }

        public bool TryChangeCurrentHealthAndReturnIsAlive(float deltaHealth)
        {
            float tempHealth = CurrentHealth + deltaHealth;
            if (tempHealth > MaximumHealth) CurrentHealth = MaximumHealth;
            else CurrentHealth = tempHealth;
            return CurrentHealth > 0f;
        }

        public void HealUnit(float healAmount)
        {
            TryChangeCurrentHealthAndReturnIsAlive(healAmount);
            Prefab.PlayEffect(PlayableUnitEffectTypes.Heal);
        }

        public UnitDamage[] ReturnCalculatedOutcomeDamage()
        {
            UnitDamage[] outcomeDamage = new UnitDamage[CurrentDamages.Length];
            for (int i = 0; i < outcomeDamage.Length; i++)
            {
                outcomeDamage[i] = new UnitDamage(CurrentDamages[i].Value * CurrentDamageMultiplier, CurrentDamages[i].Type);
            }

            return outcomeDamage;
        }
        
        public void HitUnit(UnitDamage[] incomeDamages)
        {
            float resultDamage = 0f;
            foreach (UnitDamage incomeDamage in incomeDamages)
            {
                resultDamage += ReturnCalculatedIncomeDamage(incomeDamage);
            }
            TryChangeCurrentHealthAndReturnIsAlive(-resultDamage);
            Prefab.PlayEffect(PlayableUnitEffectTypes.Damage);
        }

        public float ReturnCalculatedIncomeDamage(UnitDamage damage)
        {
            return (1 - CurrentArmor[(int)damage.Type].Value) * CurrentArmorMultiplier * damage.Value;
        }

        public void UpdateUnitMoveDirection(Vector3 direction)
        {
            UnitCurrentDirection = Mathf.Approximately(UnitMaxSpeed, 0f) ? direction : Vector3.Lerp(direction, UnitCurrentDirection, -UnitCurrentSpeed/UnitMaxSpeed);
        }
        
        public void MoveToPreviousPosition()
        {
            UnitCurrentPosition = _previousPosition;
            Prefab.UnitTransform.position = UnitCurrentPosition;
        }
        
        public void MoveUnitByVector(Vector3 offset)
        {
            _previousPosition = UnitCurrentPosition;
            UnitCurrentPosition += offset;
            Prefab.UnitTransform.position = UnitCurrentPosition;
        }

        public void Destroy()
        {
            foreach (UnitValuesContainer hunterValueContainer in Hunters)
            {
                hunterValueContainer.SetUnitTarget(null, false);
            }
            Hunters.Clear();
            Prefab.PlayEffect(PlayableUnitEffectTypes.Death);
            GC.SuppressFinalize(this);
        }
    }
}