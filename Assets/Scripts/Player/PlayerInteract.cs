using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour {
    private void Start() {
        if (SceneManager.GetActiveScene().name == "Main" && InfoManager.Instance.isTavernExit) {
            StartCoroutine(Teleport());
        }
    }
    
    private IEnumerator Teleport() {
        yield return null;
        transform.position = new Vector3(-14.80f, 5.52f, -1.05f);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null) {
                StartCoroutine(Interact(interactable));
            }
        }
    }

    private IEnumerator Interact(IInteractable interactable) {
        interactable.Interact(transform, this);
        var controller = GetComponent<ThirdPersonController>();
        controller.enabled = false;
        yield return new WaitForSeconds(1f);
        controller.enabled = true;
    }

    // Find the closest interactable object to the player
    public IInteractable GetInteractableObject() {
        List<IInteractable> interactables = new List<IInteractable>();
        float interactRange = 1f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliders) {
            if (collider.TryGetComponent(out IInteractable interactable)) {
                interactables.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactables) {
            // You cannot pet animals if holding something
            if ((InfoManager.Instance.hasAxe || InfoManager.Instance.hasWateringCan) && interactable is Animal) {
                continue;
            }

            // Palm trees can only be chopped when holding an axe
            if (!InfoManager.Instance.hasAxe && interactable is PalmTree) {
                continue;
            }

            if (closestInteractable == null) {
                closestInteractable = interactable;
            }
            else {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position)) {
                    // Ignore items being held
                    if ((closestInteractable is not Axe) && (closestInteractable is not WateringCan)) {
                        switch (interactable) {
                            case Axe when !InfoManager.Instance.hasAxe:
                            case WateringCan when !InfoManager.Instance.hasWateringCan:
                                closestInteractable = interactable;
                                break;
                        }
                    }
                    else {
                        closestInteractable = interactable;
                    }
                }
                // Ignore items being held
                else if (InfoManager.Instance.hasAxe && closestInteractable is Axe && interactable is not Axe) {
                    closestInteractable = interactable;
                }
                else if (InfoManager.Instance.hasWateringCan && closestInteractable is WateringCan &&
                         interactable is not WateringCan) {
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }
}