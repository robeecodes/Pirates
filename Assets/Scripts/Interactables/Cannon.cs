using System;
using UnityEngine;

public class Cannon : MonoBehaviour, IInteractable, IReputable {
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private AudioClip boomSFX;
    [SerializeField] private PlayerInfo _playerInfo;
    
    private static readonly int Shoot = Animator.StringToHash("Shoot");

    private Animator _cannonAnimator;

    private void Start() {
        _cannonAnimator = GetComponent<Animator>();
    }

    private void ShootCannon() {
        _cannonAnimator.SetTrigger(Shoot);
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        ShootCannon();
        AlterReputation();
    }

    public string GetInteractText() {
        return "Shoot Cannon";
    }

    public Transform GetTransform() {
        return transform;
    }

    public void AlterReputation() {
        _playerInfo.reputation = (float)Math.Max(-10, _playerInfo.reputation - 0.25);
    }

    private void Bang() {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        AudioSource.PlayClipAtPoint(boomSFX, transform.position,
            3f);
    }
}