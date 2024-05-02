using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour, IInteractable {
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private PlayerInteract _player;
    
    
    [SerializeField] private Vector3 position;
    [SerializeField] private Quaternion rotation;
    [SerializeField] private GameObject hand;

    public void Interact(Transform interactor, PlayerInteract player) {
        // Pick up the can if player isn't holding anything
        if (!_playerInfo.hasAxe && !_playerInfo.hasWateringCan) {
            if (gameObject.GetComponent<Rigidbody>() != null) {
                Destroy(gameObject.GetComponent<Rigidbody>());
            }
            transform.parent = hand.transform;
            transform.localPosition = position;
            transform.localRotation = rotation;
            _playerInfo.hasWateringCan = true;
        } else if (_playerInfo.hasWateringCan && player.GetInteractableObject() is WateringCan) {
            transform.parent = null;
            gameObject.AddComponent<Rigidbody>();
            transform.localScale = new Vector3(1, 1, 1);
            _playerInfo.hasWateringCan = false;
        }
    }

    public string GetInteractText() {
        if (!_playerInfo.hasAxe && !_playerInfo.hasWateringCan) {
            return "Pick up Watering Can";
        }
        if (_playerInfo.hasWateringCan && _player.GetInteractableObject() is WateringCan) {
            return "Drop Watering Can";
        }
        return null;
    }

    public Transform GetTransform() {
        return transform;
    }
}
