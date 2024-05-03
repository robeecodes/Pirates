using System;
using UnityEngine;

public class WaterEdge : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.name == "Sand") {
            dialogue.Talk();
        }
    }
}
