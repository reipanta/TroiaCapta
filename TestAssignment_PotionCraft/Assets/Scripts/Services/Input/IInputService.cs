using System;

namespace Services.Input
{
    public interface IInputService
    {
        bool IsRButtonPressedOnce();
        bool IsLeftMouseButtonDown();
    }
}