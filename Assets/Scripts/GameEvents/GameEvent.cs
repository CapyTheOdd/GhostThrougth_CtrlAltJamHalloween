using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Game Event")]
public class GameEvent : ScriptableObject {

    public readonly List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise() {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised(null, null);
        }
    }
    public void Raise(Component _component) {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised(_component, null);
        }
    }
    public void Raise(Component _component, object _var) {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised(_component, _var);
        }
    }

    // REGISTRA E REMOVE O LISTENER //
    public void RegisterListener(GameEventListener _listener) {
        if (listeners.Contains(_listener)) return;

        listeners.Add(_listener);
    }
    public void UnregisterListener(GameEventListener _listener) {
        if (!listeners.Contains(_listener)) return;

        listeners.Remove(_listener);
    }
}