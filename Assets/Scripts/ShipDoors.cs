using UnityEngine;

public class ShipDoors : MonoBehaviour, IInteractable {
    private Animator _doorAnimator;
    private void Start() {
        _doorAnimator = GetComponent<Animator>();
    }
    private void OpenCloseDoors() {
        _doorAnimator.SetBool("Open", !_doorAnimator.GetBool("Open"));
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        OpenCloseDoors();
    }

    public string GetInteractText() {
        return _doorAnimator.GetBool("Open") ? "Close Doors" : "Open Doors";
    }

    public Transform GetTransform() {
        return transform;
    }
}