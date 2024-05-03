using UnityEngine;

// Interface for gameObjects which the player can interact with
public interface IInteractable {
    // Interaction details
    void Interact(Transform interactor, PlayerInteract player);
    // Text to print to screen
    string GetInteractText();
    // Get transofrm of interactable
    Transform GetTransform();
}
