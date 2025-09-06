using Core.GameplayControllers;
using Core.PlayerActionsScripts.PlayerInputLibrary;
using Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions;

namespace Core.PlayerActionsScripts.PlayerSkills
{
    public interface IPlayerSkill
    {
        public void SetSkillDescription(PlayerSkillDescription skillDescription);
        public void UpdateSkill(UnitsController unitsController, GestureResult gestureResult, float deltaTime);
    }
}