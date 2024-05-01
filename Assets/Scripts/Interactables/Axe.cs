using UnityEngine;

public class Axe : MonoBehaviour, IInteractable {
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private PlayerInteract _player;
    
    
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 scale;
    [SerializeField] private Quaternion rotation;
    [SerializeField] private GameObject hand;

    public void Interact(Transform interactor, PlayerInteract player) {
        // Pick up the axe if player isn't holding anything
        if (!_playerInfo.hasAxe && !_playerInfo.hasWateringCan) {
            if (gameObject.GetComponent<Rigidbody>() != null) {
                Destroy(gameObject.GetComponent<Rigidbody>());
            }
            transform.parent = hand.transform;
            transform.localPosition = position;
            transform.localRotation = rotation;
            transform.localScale = scale;
            _playerInfo.hasAxe = true;
        } else if (_playerInfo.hasAxe && player.GetInteractableObject() is Axe) {
            transform.parent = null;
            gameObject.AddComponent<Rigidbody>();
            transform.localScale = new Vector3(1, 1, 1);
            _playerInfo.hasAxe = false;
        }
    }

    public string GetInteractText() {
        if (!_playerInfo.hasAxe && !_playerInfo.hasWateringCan) {
            return "Pick up Axe";
        }
        if (_playerInfo.hasAxe && _player.GetInteractableObject() is Axe) {
            return "Drop Axe";
        }
        return null;
    }

    public Transform GetTransform() {
        return transform;
    }
}