using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private GameObject stoveOnGameObject;
    [SerializeField] private GameObject particlesGameObject;

    private void Start() {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEvent e) {
        if (e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried) {
            Show();
        } else {
            Hide();
        }
    }

    private void Hide() {
        stoveOnGameObject.SetActive(false);
        particlesGameObject.SetActive(false);
    }

    private void Show() {
        stoveOnGameObject.SetActive(true);
        particlesGameObject.SetActive(true);
    }
}
