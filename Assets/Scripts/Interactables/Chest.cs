using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Animator _chestAnimator;
    [SerializeField] private Dialogue dialogue;
    
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    private void Start() {
        _chestAnimator = GetComponent<Animator>();
    }
    private void OpenCloseChest() {
        _chestAnimator.SetBool(IsOpen, !_chestAnimator.GetBool(IsOpen));
        if (!InfoManager.Instance.hasOpenedChest) {
            dialogue.Talk();
            InfoManager.Instance.hasOpenedChest = true;
        }
        
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        OpenCloseChest();
    }

    public string GetInteractText() {
        return _chestAnimator.GetBool(IsOpen) ? "Close Chest" : "Open Chest";
    }

    public Transform GetTransform() {
        return transform;
    }
}
