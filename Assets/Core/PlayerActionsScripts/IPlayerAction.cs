using Core.GameplayControllers;

namespace Core.PlayerActionsScripts
{
    public interface IPlayerAction
    {
        public void UpdatePlayerAction(GameplayControllersHandler context, float deltaTime);
    }
}
