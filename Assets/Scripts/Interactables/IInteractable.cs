using UnityEngine;

public interface IInteractable {
    void Interact(Transform interactor, PlayerInteract player);
    string GetInteractText();
    Transform GetTransform();
}
