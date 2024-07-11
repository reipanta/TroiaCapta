using GameServices.Input;

namespace Infrastructure
{
    // Game state that corresponds to the main game
    public class Game
    {
        public static IInputService InputService;
        public GameStateMachine StateMachine;

        public Game()
        {
            StateMachine = new GameStateMachine();
        }
    }
}