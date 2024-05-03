using System;
using UnityEngine;

public class Animal : MonoBehaviour, IInteractable, IReputable {
    [SerializeField] private AudioClip squeakSFX;
    private static readonly int PetSmall = Animator.StringToHash("PetSmall");
    private static readonly int PetMedium = Animator.StringToHash("PetMedium");

    // Pet the animal
    public void Interact(Transform interactor, PlayerInteract player) {
        if (GetComponent<Navigation>().state != Navigation.State.Scared && !InfoManager.Instance.hasWateringCan && !InfoManager.Instance.hasAxe) {
            Animator playerAnimator = player.GetComponent<Animator>();
            AlterReputation();
            AudioSource.PlayClipAtPoint(squeakSFX, transform.position,
                1f);
            if (GetComponent<SmallAnimal>()) {
                playerAnimator.SetTrigger(PetSmall);
            }
            if (GetComponent<MediumAnimal>()) {
                playerAnimator.SetTrigger(PetMedium);
            }
            
        }
    }

    public string GetInteractText() {
        if (GetComponent<Navigation>().state != Navigation.State.Scared && !InfoManager.Instance.hasWateringCan && !InfoManager.Instance.hasAxe) {
            return "Pet Animal";
        }

        return null;
    }

    public Transform GetTransform() {
        return transform;
    }

    public void AlterReputation() {
        InfoManager.Instance.reputation = (float)Math.Min(10, InfoManager.Instance.reputation + 0.5);
    }
}