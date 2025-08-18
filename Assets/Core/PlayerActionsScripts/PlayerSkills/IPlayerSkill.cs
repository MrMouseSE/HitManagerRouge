using Core.GameplayControllers;
using Core.PlayerActionsScripts.PlayerInputLibrary;

namespace Core.PlayerActionsScripts.PlayerSkills
{
    public interface IPlayerSkill
    {
        public void UseSkill(UnitsController unitsController, GestureResult gestureResult, float deltaTime);
    }
}