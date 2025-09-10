using Core.GameplayControllers;
using Core.PlayerActionsScripts.PlayerInputLibrary;
using Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions;
using Core.UserInterfaceViewScripts;

namespace Core.PlayerActionsScripts.PlayerSkills
{
    public interface IPlayerSkill
    {
        public void SetSkillDescription(PlayerSkillDescription skillDescription);
        public void UpdateSkill(UserInterfaceViewController interfaceViewController, UnitsController unitsController, 
            GestureResult gestureResult, float deltaTime);
    }
}