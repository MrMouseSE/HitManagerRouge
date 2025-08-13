using Core.GameplayControllers;

namespace Core.Units.UnitSystems
{
    public interface IUnitSystem
    {
        public void UpdateUnit(UnitsController context, float deltaTime, UnitValuesContainer unitValuesContainer);
    }
}