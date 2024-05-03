using UnityEngine;

public class FirstMateTavern : MonoBehaviour, IInteractable {
    [SerializeField] private Dialogue dialogue;
    public void Interact(Transform interactor, PlayerInteract player) {
        dialogue.Talk();
    }

    public string GetInteractText() {
        return "Talk";
    }

    public Transform GetTransform() {
        return transform;
    }
}
