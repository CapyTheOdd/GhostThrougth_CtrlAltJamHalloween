using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;

    public CustomGameEvent response;

    private void OnEnable() {
        gameEvent.RegisterListener(this);
    }
    private void OnDisable() {
        gameEvent.UnregisterListener(this);
    } 

    public void OnEventRaised(Component _component, object _var) {
        response?.Invoke(_component, _var);
    }
}

[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> {}