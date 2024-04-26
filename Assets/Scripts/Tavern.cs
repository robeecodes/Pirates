using UnityEngine;
using UnityEngine.SceneManagement;

public class Tavern : MonoBehaviour, IInteractable {
    private void EnterTavern() {
        SceneManager.LoadScene("PirateTavern", LoadSceneMode.Single);
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        EnterTavern();
    }

    public string GetInteractText() {
        return "Enter Tavern";
    }

    public Transform GetTransform() {
        return transform;
    }
}