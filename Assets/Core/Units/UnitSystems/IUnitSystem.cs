namespace Core.Units
{
    public interface IUnitSystem
    {
        public void UpdateUnit(float deltaTime, UnitValuesContainer unitValuesContainer);
    }
}