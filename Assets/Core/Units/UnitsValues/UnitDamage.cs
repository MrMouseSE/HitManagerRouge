using System;

namespace Core.Units.UnitsValues
{
    [Serializable]
    public class UnitDamage
    {
        public float Value;
        public DamageTypes Type;

        public UnitDamage(float value, DamageTypes type)
        {
            Value = value;
            Type = type;
        }
    }
}