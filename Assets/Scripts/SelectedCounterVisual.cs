using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour {

    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;

    private void Start() {
        // Creates an Instance of that player and attaches a listener for the OnSelectedCounterChanged.
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e) {
        // Shows or hides the visualGameObject depending on the event args.
        if (e.selectedCounter == clearCounter) {
            Show();
        } else {
            Hide();
        }
    }

    // Shows the visualGameObject.
    private void Show() {
        visualGameObject.SetActive(true);
    }

    // Hides the visualGameObject.
    private void Hide() {
        visualGameObject.SetActive(false);
    }
}
