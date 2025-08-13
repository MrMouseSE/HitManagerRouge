using System;
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
        public Vector3 UnitPosition;
        public float UnitRadius;
        public float UnitMaxSpeed;
        public bool IsTargetLocked;
        public IPlayableUnit Target;
        
        public IUnitSystem[] UnitSystems;

        public float UnitCurrentSpeed;

        public UnitValuesContainer(UnitSettingsDescription unitSettingsDescription, UnitSceneContainer prefab, 
            IUnitSystem[] unitSystems, bool isEnemy)
        {
            Prefab = prefab;
            UnitPosition = Prefab.UnitTransform.position;
            MaximumHealth = unitSettingsDescription.UnitHealth;
            CurrentHealth = MaximumHealth;
            CurrentDamageMultiplier = 1;
            CurrentArmorMultiplier = 1;
            CurrentDamages = unitSettingsDescription.UnitDamages.OrderBy(x=>(int)x.Type).ToArray();
            CurrentArmor = unitSettingsDescription.UnitArmors.OrderBy(x => (int)x.Type).ToArray();
            IsEnemy = isEnemy;
            UnitRadius = unitSettingsDescription.UnitRadius;
            UnitMaxSpeed = unitSettingsDescription.UnitSpeed;
            UnitBouncePower = unitSettingsDescription.UnitBouncePower;
            UnitSystems = unitSystems;
        }

        public void UpdateSystems(UnitsController context, float deltaTime)
        {
            foreach (var unitSystem in UnitSystems)
            {
                unitSystem.UpdateUnit(context, deltaTime,this);
            }
        }

        public void SetUnitTarget(IPlayableUnit target)
        {
            Target = target;
            IsTargetLocked = true;
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
            Prefab.Value = CurrentHealth.ToString();
            return CurrentHealth > 0f;
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

        public void UpdatePosition(Vector3 offset)
        {
            UnitPosition += offset;
            Prefab.UnitTransform.position = UnitPosition;
        }

        public void Destroy()
        {
            Prefab.PlayEffect(PlayableUnitEffectTypes.Death);
            GC.SuppressFinalize(this);
        }
    }
}