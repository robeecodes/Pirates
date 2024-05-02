using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    [SerializeField] private PlayerInfo _playerInfo;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null) {
                interactable.Interact(transform, this);
            }
        }
    }

    public IInteractable GetInteractableObject() {
        List<IInteractable> interactables = new List<IInteractable>();
        float interactRange = 2f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliders) {
            if (collider.TryGetComponent(out IInteractable interactable)) {
                interactables.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactables) {
            if (closestInteractable == null) {
                closestInteractable = interactable;
            }
            else {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position)) {
                    if ((closestInteractable is not Axe) && (closestInteractable is not WateringCan)) {
                        if (interactable is Axe && !_playerInfo.hasAxe) {
                            closestInteractable = interactable;
                        }

                        if (interactable is WateringCan && !_playerInfo.hasWateringCan) {
                            closestInteractable = interactable;
                        }
                    }
                    else {
                        closestInteractable = interactable;
                    }
                }
                else if (_playerInfo.hasAxe && closestInteractable is Axe && interactable is not Axe) {
                    closestInteractable = interactable;
                }
                else if (_playerInfo.hasWateringCan && closestInteractable is WateringCan &&
                         interactable is not WateringCan) {
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }
}