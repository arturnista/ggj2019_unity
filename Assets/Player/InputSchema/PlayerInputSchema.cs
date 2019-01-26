using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Create PlayerInputSchema")]
public class PlayerInputSchema : ScriptableObject {

    public string Axis = "Horizontal";
    [Space]
    public KeyCode Jump = KeyCode.Space;
    public KeyCode Pickup = KeyCode.E;

}