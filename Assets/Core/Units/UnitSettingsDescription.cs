using System.Collections.Generic;
using Core.Units.UnitsValues;
using UnityEngine;

namespace Core.Units
{
    [CreateAssetMenu(menuName = "Create UnitSettingsDescription", fileName = "UnitSettingsDescription", order = 0)]
    public class UnitSettingsDescription : ScriptableObject
    {
        public UnitSceneContainer UnitPrefab;
        public UnitTypes UnitType;
        public float UnitHealth;
        public float UnitRadius;
        public List<UnitDamage> UnitDamages;
        public List<UnitDamage> UnitArmors;
        public float UnitSpeed;
    }
}