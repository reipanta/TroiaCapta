using System;
using System.ComponentModel;
using UnityEngine.Events;

namespace EventSystem
{
    [Serializable]
    public class CustomGameEvent : UnityEvent<Component, object>
    {
    }
}