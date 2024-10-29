using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;


namespace AYellowpaper.SerializedCollections {
    public class GUI : MonoBehaviour
    {
        [SerializedDictionary(keyName: "state", valueName: "game object")]
        public SerializedDictionary<GameState, GameObject> menuDictionary;


        private void Start() {
            HideAllUI();
            menuDictionary[GameManager.Instance.CurrentGameState].SetActive(true);
        }

        public void OnStateChanged(Component _component, object _data)
        {
            if (_data is GameState) {
                GameState _changeState = (GameState) _data;

                HideAllUI();
                menuDictionary[_changeState].SetActive(true);
            }
        }
        private void HideAllUI() {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}