using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactText;

    private void Update() {
        if (playerInteract.GetInteractableObject() != null) {
            string interactMessage = playerInteract.GetInteractableObject().GetInteractText();
            if (interactMessage != null) {
                Show(interactMessage);
            }
        }
        else {
            Hide();
        }
    }

    private void Show(string msg)
    {
        container.SetActive(true);
        interactText.text = msg;
    }

    private void Hide()
    {
        container.SetActive(false);
    }
}
