using Infrastructure;
using UnityEngine;

namespace GameServices.Input
{
    // InputController is a class other objects call on if they need to check for input
    public class InputController : MonoBehaviour
    {
        public IInputService InputHandler; 
        private void Start()
        {
            InputHandler = Game.InputService;
        }

         void Update()
         {
             if (InputHandler.IsRButtonPressedOnce())
             {
                 GameBootloader.OnRestart();
             }
             
         }

         public void RestartGameByButton()
         {
             GameBootloader.OnRestart();
         }
    }
}