using System;
using UnityEngine;

public class WateringCan : MonoBehaviour, IInteractable, IReputable {
    [SerializeField] private PlayerInteract _player;
    
    
    [SerializeField] private Vector3 position;
    [SerializeField] private Quaternion rotation;
    [SerializeField] private GameObject hand;

    private void Awake() {
        if (InfoManager.Instance.hasWateringCan) {
            Pickup();
        }
    }
    
    public void Interact(Transform interactor, PlayerInteract player) {
        // Pick up the can if player isn't holding anything
        if (!InfoManager.Instance.hasAxe && !InfoManager.Instance.hasWateringCan) {
            Pickup();
        } else if (InfoManager.Instance.hasWateringCan && player.GetInteractableObject() is WateringCan) {
            Drop();
        }
    }

    private void Pickup() {
        if (gameObject.GetComponent<Rigidbody>() != null) {
            Destroy(gameObject.GetComponent<Rigidbody>());
        }
        transform.parent = hand.transform;
        transform.localPosition = position;
        transform.localRotation = rotation;
        InfoManager.Instance.hasWateringCan = true;
        AlterReputation();
    }

    private void Drop() {
        transform.parent = null;
        gameObject.AddComponent<Rigidbody>();
        InfoManager.Instance.hasWateringCan = false;
    }
    
    public string GetInteractText() {
        if (!InfoManager.Instance.hasAxe && !InfoManager.Instance.hasWateringCan) {
            return "Pick up Watering Can";
        }
        if (InfoManager.Instance.hasWateringCan && _player.GetInteractableObject() is WateringCan) {
            return "Drop Watering Can";
        }
        return null;
    }

    public Transform GetTransform() {
        return transform;
    }

    public void AlterReputation() {
        InfoManager.Instance.reputation = (float)Math.Min(10, InfoManager.Instance.reputation + 1.5);
    }
}
