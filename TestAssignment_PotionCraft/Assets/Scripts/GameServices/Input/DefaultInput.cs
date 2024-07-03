using UnityEngine;

namespace GameServices.Input
{
    public class DefaultInput : IInputService
    {
        private const string Click = "Click";
        
        public bool IsRButtonPressedOnce() => UnityEngine.Input.GetKeyDown(KeyCode.R);
        public bool IsLeftMouseButtonDown() => UnityEngine.Input.GetButtonDown(Click);
    }
}