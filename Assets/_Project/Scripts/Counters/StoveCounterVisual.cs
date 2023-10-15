using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    // Public class called StoveCounterVisual that inherits from MonoBehaviour.

    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private GameObject stoveOnGameObject;
    [SerializeField] private GameObject particlesGameObject;
    // References to the current StoveCounter and GameObjects within the prefab.

    private void Start()
    {
        // Unity event function that is called after Awake.
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged; // Listens to an event from the StoveCounter called OnStateChanged.
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        // OnStateChanged event function that is called based on the event from the StoveCounter.
        bool showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried; // Sets a bool based on whether or not State sent from the StoveCounter event is Frying or Fried.
        stoveOnGameObject.SetActive(showVisual); // Shows the red glow on the StoveCounter when the showVisual bool is set to true
        particlesGameObject.SetActive(showVisual); // Shows particles on the StoveCounter when the showVisual bool is set to true.
    }
}

