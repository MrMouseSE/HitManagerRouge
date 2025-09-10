using System.Collections.Generic;
using Core.GameplayControllers;
using Core.PlayerActionsScripts.PlayerInputLibrary;
using Core.PlayerActionsScripts.PlayerSkills;
using Core.UserInterfaceViewScripts;

namespace Core.PlayerActionsScripts
{
    public class TapPlayerAction : IPlayerAction
    {
        private readonly List<IPlayerSkill> _actionSkills;

        public TapPlayerAction(List<IPlayerSkill> actionSkills)
        {
            _actionSkills = actionSkills;
        }

        public void SetPlayerSkillsToAction(IPlayerSkill playerSkill)
        {
            _actionSkills.Add(playerSkill);
        }
        
        public void UpdatePlayerAction(GameplayControllersHandler context, float deltaTime)
        {
            UnitsController unitsController = (UnitsController)context.GetGameplayControllerByType(typeof(UnitsController));
            UserInterfaceViewController interfaceViewController = 
                (UserInterfaceViewController)context.GetGameplayControllerByType(typeof(UserInterfaceViewController));
            GestureResult gestureResult = PlayerInputHandler.CheckForTapThisFrame(unitsController);
            foreach (var actionSkill in _actionSkills)
            {
                actionSkill.UpdateSkill(interfaceViewController, unitsController, gestureResult, deltaTime);
            }
        }
    }
}