using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SwimInWater : MonoBehaviour {
    [SerializeField] private ParticleSystem splash;
    [SerializeField] private AudioClip splashSFX;

    private static readonly int IsSwimming = Animator.StringToHash("IsSwimming");
    private static readonly int Grounded = Animator.StringToHash("Grounded");
    private static readonly int FreeFall = Animator.StringToHash("FreeFall");
    private static readonly int Jump = Animator.StringToHash("Jump");

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "PlayerArmature") {
            Animator playerAnimator = other.GetComponent<Animator>();
            playerAnimator.SetBool(IsSwimming, true);
            if (!playerAnimator.GetBool(Grounded) || playerAnimator.GetBool(FreeFall) || playerAnimator.GetBool(Jump)) {
                AudioSource.PlayClipAtPoint(splashSFX, other.gameObject.transform.position, 1f);
                Instantiate(splash, other.gameObject.transform.position, splash.transform.rotation);
            }
        }
        else if (other.gameObject.GetComponent<NavMeshAgent>()) {
            
            Animator animator = other.GetComponent<Animator>();
            animator.SetBool(IsSwimming, true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "PlayerArmature") {
            Animator playerAnimator = other.GetComponent<Animator>();
            playerAnimator.SetBool(IsSwimming, false);
        }
        else if (other.gameObject.GetComponent<NavMeshAgent>()) {
            Animator animator = other.GetComponent<Animator>();
            animator.SetBool(IsSwimming, false);
        }
    }
}