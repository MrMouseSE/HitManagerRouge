using Core.GameplayControllers;
using Core.PlayerActionsScripts.PlayerInputLibrary;

namespace Core.PlayerActionsScripts.PlayerSkills
{
    public class HealUnitPlayerSkill : IPlayerSkill
    {
        private float healAmount;
        
        public void UseSkill(UnitsController unitsController, GestureResult gestureResult, float deltaTime)
        {
            gestureResult.TappedUnits[0].HealUnit(healAmount);
        }
    }
}