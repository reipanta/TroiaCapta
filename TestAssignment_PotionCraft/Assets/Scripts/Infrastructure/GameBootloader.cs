using UnityEngine;

namespace Infrastructure
{
    // Booting the game straight from the scene here
    public class GameBootloader : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            
            _game = new Game();
            _game.StateMachine.EntryPoint<BootStrapState>();
            DontDestroyOnLoad(this);
            SceneLoader.LoadScene("MainGame");
        }

        public static void OnRestart()
        {
            SceneLoader.LoadScene("MainGame");
        }
    }
}