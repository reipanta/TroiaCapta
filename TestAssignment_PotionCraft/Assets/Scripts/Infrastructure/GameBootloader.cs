using UnityEngine;

namespace Infrastructure
{
    public class GameBootloader : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            Debug.Log("GameBootloader Awake");
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