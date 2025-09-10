using Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions;

namespace Core.UserInterfaceViewScripts
{
    public interface IUserInterfaceView
    {
        public bool CheckUserInterfaceSkillType(PlayerSkillsTypes skillType);
        public void UpdateUserInterfaceView(float currentCooldown);
    }
}