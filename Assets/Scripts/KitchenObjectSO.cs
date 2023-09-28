using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adds 'Kitchen Object SO' to the create asset menu, allowing you to create a kitchen object so per kitchen object, e.g. tomato, cheese block.
[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject {

    // Prefab, icon sprite, object name to show in game.
    public Transform prefab;
    public Sprite sprite;
    public string objectName;

}
