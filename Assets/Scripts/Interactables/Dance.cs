using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour, IInteractable {
    [SerializeField] private Animator playerAnimator;
    private static readonly int Dance1 = Animator.StringToHash("Dance");

    public void Interact(Transform interactor, PlayerInteract player) {
        playerAnimator.SetTrigger(Dance1);
    }

    public string GetInteractText() {
        return "Dance";
    }

    public Transform GetTransform() {
        return transform;
    }
}
