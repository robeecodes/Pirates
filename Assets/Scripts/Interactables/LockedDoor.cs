using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private PlayerInfo _playerInfo;

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
