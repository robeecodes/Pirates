using UnityEngine;

public class Tavern : MonoBehaviour, IInteractable {
    [SerializeField] private LevelLoader LevelLoader;
    private void EnterTavern() {
        InfoManager.Instance.isTavernExit = true;
        LevelLoader.LoadLevel("PirateTavern");
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