namespace Core.GameplayControllers
{
    public interface IGameplayController
    {
        public void UpdateController(GameplayControllersHandler context, float deltaTime);
    }
}