using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private GameObject pauseMenu;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.GetComponent<PauseMenu>().Pause();
        }
    }
}