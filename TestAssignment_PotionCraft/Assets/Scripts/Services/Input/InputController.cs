using Infrastructure;
using UnityEngine;

namespace Services.Input
{
    public class InputController : MonoBehaviour
    {
        public IInputService InputHandler;

        private void Start()
        {
            InputHandler = Game.InputService;
            Debug.Log("InputController Start, InputHandler: " + (InputHandler != null));
        }

         void Update()
         {
             if (InputHandler.IsRButtonPressedOnce())
             {
                 GameBootloader.OnRestart();
             }

             if (InputHandler.IsLeftMouseButtonDown())
             {
                 //Debug.Log("LMB down!");
             }
         }
    }
}