using Core.GameplayControllers;
using Core.PlayerActionsScripts.PlayerInputLibrary;
using Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions;
using Core.UserInterfaceViewScripts;

namespace Core.PlayerActionsScripts.PlayerSkills
{
    public class HitUnitPlayerSkill : IPlayerSkill
    {
        private PlayerSkillDescription _hitSkillDescription;
        private float _currentCooldown;

        public void SetSkillDescription(PlayerSkillDescription skillDescription)
        {
            _hitSkillDescription = skillDescription;
        }

        public void UpdateSkill(UserInterfaceViewController interfaceViewController, UnitsController unitsController,
            GestureResult gestureResult, float deltaTime)
        {
            _currentCooldown -= deltaTime;
            interfaceViewController.UpdateUserInterfaceViewCooldown(_currentCooldown, _hitSkillDescription.PlayerSkillsType);
            if (_currentCooldown > 0) return;

            if (!gestureResult.IsTappedThisFrame || !gestureResult.TappedUnits[0].GetUnitValuesContainer().IsEnemy) return;
            gestureResult.TappedUnits[0].HitUnit(_hitSkillDescription.HitAmount);
            _currentCooldown = _hitSkillDescription.Cooldown;
        }
    }
}