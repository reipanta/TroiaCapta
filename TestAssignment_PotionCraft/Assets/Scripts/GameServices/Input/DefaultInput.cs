using UnityEngine;

namespace GameServices.Input
{
    // Here we bind interface methods to a certain input
    public class DefaultInput : IInputService
    {
        private const string Click = "Click";
        
        public bool IsRButtonPressedOnce() => UnityEngine.Input.GetKeyDown(KeyCode.R);
        public bool IsLeftMouseButtonDown() => UnityEngine.Input.GetButtonDown(Click);
    }
}