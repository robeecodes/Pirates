using UnityEngine;

public class Cannon : MonoBehaviour, IInteractable {
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private AudioClip boomSFX;
    
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
    }

    public string GetInteractText() {
        return "Shoot Cannon";
    }

    public Transform GetTransform() {
        return transform;
    }

    private void Bang() {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        AudioSource.PlayClipAtPoint(boomSFX, transform.position,
            3f);
    }
}