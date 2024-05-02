using UnityEngine;

public class ShipDoors : MonoBehaviour, IInteractable {
    [SerializeField] private AudioClip openSFX;
    [SerializeField] private AudioClip closeSFX;
    
    private Animator _doorAnimator;
    private static readonly int Open = Animator.StringToHash("Open");

    private void Start() {
        _doorAnimator = GetComponent<Animator>();
    }
    private void OpenCloseDoors() {
        _doorAnimator.SetBool(Open, !_doorAnimator.GetBool(Open));
        if (_doorAnimator.GetBool(Open)) {
            AudioSource.PlayClipAtPoint(openSFX, transform.position,
                1f);
        }
        else {
            AudioSource.PlayClipAtPoint(closeSFX, transform.position,
                1f);
        }
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        OpenCloseDoors();
    }

    public string GetInteractText() {
        return _doorAnimator.GetBool(Open) ? "Close Doors" : "Open Doors";
    }

    public Transform GetTransform() {
        return transform;
    }
}