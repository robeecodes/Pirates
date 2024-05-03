using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderers : MonoBehaviour, IInteractable {
    [SerializeField] private WandererDialogue dialogue;

    private void Start() {
        dialogue.InitMe(GetComponent<Navigation>());
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        dialogue.Talk();
        transform.LookAt(player.transform.position);
    }
    
    public string GetInteractText() {
        return "Talk";
    }

    public Transform GetTransform() {
        return transform;
    }
}