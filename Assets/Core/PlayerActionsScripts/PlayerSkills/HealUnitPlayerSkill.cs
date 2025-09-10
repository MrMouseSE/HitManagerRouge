using Core.GameplayControllers;
using Core.PlayerActionsScripts.PlayerInputLibrary;
using Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions;
using Core.UserInterfaceViewScripts;

namespace Core.PlayerActionsScripts.PlayerSkills
{
    public class HealUnitPlayerSkill : IPlayerSkill
    {
        private PlayerSkillDescription _healSkillDescription;
        private float _currentCooldown;

        public void SetSkillDescription(PlayerSkillDescription skillDescription)
        {
            _healSkillDescription = skillDescription;
        }

        public void UpdateSkill(UserInterfaceViewController interfaceViewController, UnitsController unitsController, 
            GestureResult gestureResult, float deltaTime)
        {
            _currentCooldown -= deltaTime;
            interfaceViewController.UpdateUserInterfaceViewCooldown(_currentCooldown, _healSkillDescription.PlayerSkillsType);
            if (_currentCooldown > 0) return;

            if (!gestureResult.IsTappedThisFrame || gestureResult.TappedUnits[0].GetUnitValuesContainer().IsEnemy) return;
            gestureResult.TappedUnits[0].HealUnit(_healSkillDescription.HealAmount);
            _currentCooldown = _healSkillDescription.Cooldown;
        }
    }
}