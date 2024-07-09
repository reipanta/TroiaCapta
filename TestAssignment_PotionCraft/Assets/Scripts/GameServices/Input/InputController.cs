using Infrastructure;
using UnityEngine;

namespace GameServices.Input
{
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
    }
}