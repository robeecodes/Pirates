using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Dialogue dialogue;

    public void Interact(Transform interactor, PlayerInteract player) {
        dialogue.Talk();
    }

    public string GetInteractText() {
        return "Try door?";
    }

    public Transform GetTransform() {
        return transform;
    }
}
