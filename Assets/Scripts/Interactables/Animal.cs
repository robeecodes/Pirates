using System;
using UnityEngine;

public class Animal : MonoBehaviour, IInteractable, IReputable {
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private AudioClip squeakSFX;
    private static readonly int PetSmall = Animator.StringToHash("PetSmall");

    public void Interact(Transform interactor, PlayerInteract player) {
        if (GetComponent<Navigation>().state != Navigation.State.Scared && !playerInfo.hasWateringCan && !playerInfo.hasAxe) {
            Animator playerAnimator = player.GetComponent<Animator>();
            AudioSource.PlayClipAtPoint(squeakSFX, transform.position,
                1f);
            playerAnimator.SetTrigger(PetSmall);
        }
    }

    public string GetInteractText() {
        if (GetComponent<Navigation>().state != Navigation.State.Scared && !playerInfo.hasWateringCan && !playerInfo.hasAxe) {
            return "Pet Animal";
        }

        return null;
    }

    public Transform GetTransform() {
        return transform;
    }

    public void AlterReputation() {
        playerInfo.reputation = (float)Math.Min(10, playerInfo.reputation + 0.5);
    }
}