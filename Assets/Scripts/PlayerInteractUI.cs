using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactText;

    private void Update() {
        if (playerInteract.GetInteractableObject() != null) {
            Show();
        }
        else {
            Hide();
        }
    }

    private void Show()
    {
        container.SetActive(true);
        interactText.text = playerInteract.GetInteractableObject().GetInteractText();
    }

    private void Hide()
    {
        container.SetActive(false);
    }
}
