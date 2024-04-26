using UnityEngine;

public class Barrels : MonoBehaviour, IInteractable
{
    private void KickBarrel(PlayerInteract player) {
        Animator playerAnimator = player.GetComponent<Animator>();
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        playerAnimator.SetTrigger("Kick");

        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Kick")) {
            rigidbody.AddForceAtPosition(player.transform.forward * 100, transform.position, ForceMode.Impulse);
        }
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        KickBarrel(player);
    }

    public string GetInteractText() {
        return "Kick Barrel";
    }

    public Transform GetTransform() {
        return transform;
    }
}
