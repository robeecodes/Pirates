using UnityEngine;

public class Barrels : MonoBehaviour, IInteractable {
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AudioClip kickSFX;
    private static readonly int Kick = Animator.StringToHash("Kick");
    private static readonly int IsSwimming = Animator.StringToHash("IsSwimming");

    private void KickBarrel(PlayerInteract player) {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        playerAnimator.SetTrigger(Kick);

        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Kick")) {
            AudioSource.PlayClipAtPoint(kickSFX, transform.position, 0.75f);
            rigidbody.AddForceAtPosition(player.transform.forward * 100, transform.position, ForceMode.Impulse);
        }
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        if (!playerAnimator.GetBool(IsSwimming)) {
            KickBarrel(player);
        }
    }

    public string GetInteractText() {
        if (!playerAnimator.GetBool(IsSwimming)) {
            return "Kick Barrel";
        }
        else {
            return null;
        }
    }

    public Transform GetTransform() {
        return transform;
    }
}
