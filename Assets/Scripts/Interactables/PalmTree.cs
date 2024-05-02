using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : MonoBehaviour, IInteractable, IReputable {
    [SerializeField] private ParticleSystem leaves;
    [SerializeField] private PlayerInfo _playerInfo;
    
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AudioClip chopSFX;
    private static readonly int Chop = Animator.StringToHash("Chop");

    private bool _chopped;

    public void Interact(Transform interactor, PlayerInteract player) {
        if (_chopped || !_playerInfo.hasAxe) {
            return;
        }
        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Chop")) {
            gameObject.AddComponent<Rigidbody>();
            playerAnimator.SetTrigger(Chop);
            Instantiate(leaves, transform.position, leaves.transform.rotation);
            AudioSource.PlayClipAtPoint(chopSFX, transform.position, 0.75f);
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(player.transform.forward * 20, transform.position, ForceMode.Impulse);
            AlterReputation();
            _chopped = true;
        }
    }

    public string GetInteractText() {
        if (_chopped || !_playerInfo.hasAxe) {
            return null;
        }

        return "Chop Tree";
    }

    public Transform GetTransform() {
        return transform;
    }

    public void AlterReputation() {
        _playerInfo.reputation = (float)Math.Max(-10, _playerInfo.reputation - 0.75);
    }
}
