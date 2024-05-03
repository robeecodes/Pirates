using UnityEngine;

public class ExitTavern : MonoBehaviour, IInteractable {
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private MainInfo mainInfo;
    private void Leave() {
        if (!mainInfo.isTavernExit) {
            mainInfo.isTavernExit = true;
        }
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