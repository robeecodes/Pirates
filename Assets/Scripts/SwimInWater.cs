using UnityEngine;

public class SwimInWater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        print("hit");
        if (other.gameObject.name == "PlayerArmature") {
            Animator playerAnimator = other.GetComponent<Animator>();
            playerAnimator.SetBool("IsSwimming", true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "PlayerArmature") {
            Animator playerAnimator = other.GetComponent<Animator>();
            playerAnimator.SetBool("IsSwimming", false);
        }
    }
}
