using Core.GameplayControllers;
using Core.PlayerActionsScripts.PlayerInputLibrary;
using Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions;

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

        public void UpdateSkill(UnitsController unitsController, GestureResult gestureResult, float deltaTime)
        {
            _currentCooldown -= deltaTime;
            if (_currentCooldown > 0) return;

            if (!gestureResult.IsTappedThisFrame || !gestureResult.TappedUnits[0].GetUnitValuesContainer().IsEnemy) return;
            gestureResult.TappedUnits[0].HitUnit(_hitSkillDescription.HitAmount);
            _currentCooldown = _hitSkillDescription.Cooldown;
        }
    }
}