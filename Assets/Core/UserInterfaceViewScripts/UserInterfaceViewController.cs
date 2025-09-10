using System.Collections.Generic;
using Core.GameplayControllers;
using Core.PlayerActionsScripts.PlayerSkills;
using Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions;

namespace Core.UserInterfaceViewScripts
{
    public class UserInterfaceViewController : IGameplayController
    {
        public List<IUserInterfaceView> UserInterfaceViews = new List<IUserInterfaceView>();

        public UserInterfaceViewController(PlayerSkillsDataHolder skillDataHolder)
        {
            
        }

        public void AddUserInterfaceView()
        {
            
        }

        public void UpdateUserInterfaceViewCooldown(float currentCooldown, PlayerSkillsTypes skillsType)
        {
            var interfaceView = UserInterfaceViews.Find(x => x.CheckUserInterfaceSkillType(skillsType));
            interfaceView.UpdateUserInterfaceView(currentCooldown);
        }
        
        public void UpdateController(GameplayControllersHandler context, float deltaTime)
        {
            foreach (var userInterfaceView in UserInterfaceViews)
            {
                //userInterfaceView.UpdateUserInterfaceView(deltaTime);
            }
        }
    }
}