using System.Collections.Generic;
using UnityEngine;
using Component = System.ComponentModel.Component;

namespace EventSystem
{
    [CreateAssetMenu(menuName = "GameEvent")]
    public class GameEvent : ScriptableObject
    {
        public List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise(Component sender, object data)
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].OnEventRaised(sender, data);
            }
        }

        public void Register(GameEventListener listener)
        {
            if(!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void Unregister(GameEventListener listener)
        {
            if(listeners.Contains(listener))
                listeners.Remove(listener);
        }
    }
}