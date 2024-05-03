using System;
using UnityEngine;

public class Axe : MonoBehaviour, IInteractable {
    [SerializeField] private PlayerInteract _player;
    
    
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 scale;
    [SerializeField] private Quaternion rotation;
    [SerializeField] private GameObject hand;

    private void Awake() {
        if (InfoManager.Instance.hasAxe) {
            Pickup();
        }
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        // Pick up the axe if player isn't holding anything
        if (!InfoManager.Instance.hasAxe && !InfoManager.Instance.hasWateringCan) {
            Pickup();
        } else if (InfoManager.Instance.hasAxe && player.GetInteractableObject() is Axe) {
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
        transform.localScale = scale;
        InfoManager.Instance.hasAxe = true;
        AlterReputation();
    }

    private void Drop() {
        transform.parent = null;
        gameObject.AddComponent<Rigidbody>();
        InfoManager.Instance.hasAxe = false;
    }
    
    public string GetInteractText() {
        if (!InfoManager.Instance.hasAxe && !InfoManager.Instance.hasWateringCan) {
            return "Pick up Axe";
        }
        if (InfoManager.Instance.hasAxe && _player.GetInteractableObject() is Axe) {
            return "Drop Axe";
        }
        return null;
    }

    public Transform GetTransform() {
        return transform;
    }

    public void AlterReputation() {
        InfoManager.Instance.reputation = Math.Max(-10, InfoManager.Instance.reputation - 1);
    }
}