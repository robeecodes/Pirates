using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Animator _chestAnimator;
    private void Start() {
        _chestAnimator = GetComponent<Animator>();
    }
    private void OpenCloseDoors() {
        _chestAnimator.SetBool("IsOpen", !_chestAnimator.GetBool("IsOpen"));
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        OpenCloseDoors();
    }

    public string GetInteractText() {
        return _chestAnimator.GetBool("IsOpen") ? "Close Chest" : "Open Chest";
    }

    public Transform GetTransform() {
        return transform;
    }
}
