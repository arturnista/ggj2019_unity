using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Create PlayerInputSchema")]
public class PlayerInputSchema : ScriptableObject {

    public KeyCode Right = KeyCode.D;
    public KeyCode Left = KeyCode.A;
    public KeyCode Jump = KeyCode.Space;
    public KeyCode Pickup = KeyCode.E;

    public string DpadHor = "DpadHorizontal";

}