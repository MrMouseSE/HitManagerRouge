using System;
using System.Linq;
using Core.Units.UnitsValues;
using Core.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

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

        public UnitSceneContainer Prefab;
        public Vector3 UnitPosition;
        public float UnitRadius;
        public float UnitSpeed;
        public bool IsTargetLocked;
        public IPlayableUnit Target;
        
        public IUnitSystem[] UnitSystems;

        public UnitValuesContainer(UnitSettingsDescription unitSettingsDescription, UnitSceneContainer prefab, IUnitSystem[] unitSystems)
        {
            Prefab = prefab;
            MaximumHealth = unitSettingsDescription.UnitHealth;
            CurrentHealth = MaximumHealth;
            CurrentDamageMultiplier = 1;
            CurrentArmorMultiplier = 1;
            CurrentDamages = unitSettingsDescription.UnitDamages.OrderBy(x=>(int)x.Type).ToArray();
            CurrentArmor = unitSettingsDescription.UnitArmors.OrderBy(x => (int)x.Type).ToArray();
            UnitRadius = unitSettingsDescription.UnitRadius;
            UnitSpeed = unitSettingsDescription.UnitSpeed;
            UnitSystems = unitSystems;
        }

        public void UpdateSystems(float deltaTime)
        {
            foreach (var unitSystem in UnitSystems)
            {
                unitSystem.UpdateUnit(deltaTime,this);
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
            bool isAlive = true;
            float tempHealth = CurrentHealth - deltaHealth;
            if (tempHealth < 0)
            {
                CurrentHealth = 0;
                isAlive = false;
            }

            if (tempHealth > MaximumHealth)
            {
                CurrentHealth = MaximumHealth;
            }
            return isAlive;
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

        public float ReturnCalculatedIncomeDamage(UnitDamage damage)
        {
            return (1 - CurrentArmor[(int)damage.Type].Value * CurrentArmorMultiplier) * damage.Value;
        }

        public void Destroy()
        {
            Prefab.PlayEffect(PlayableUnitEffectTypes.Death);
            GC.SuppressFinalize(this);
        }
    }
}