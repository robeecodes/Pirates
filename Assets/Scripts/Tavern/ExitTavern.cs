using UnityEngine;

public class ExitTavern : MonoBehaviour, IInteractable {
    [SerializeField] private LevelLoader levelLoader;
    private void Leave() {
        levelLoader.LoadLevel("Main");
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        Leave();
    }

    public string GetInteractText() {
        return "Exit Tavern";
    }

    public Transform GetTransform() {
        return transform;
    }
}