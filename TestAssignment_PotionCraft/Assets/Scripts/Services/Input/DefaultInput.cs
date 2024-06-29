namespace Services.Input
{
    public class DefaultInput : IInputService
    {
        private const string Click = "Click";
        private const string KeyR = "R";

        public bool IsRButtonPressedOnce() => UnityEngine.Input.GetKeyDown(KeyR);
        public bool IsLeftMouseButtonDown() => UnityEngine.Input.GetButtonDown(Click);
    }
}