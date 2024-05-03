using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    [SerializeField] private Animator crossfade;
    private static readonly int Property = Animator.StringToHash("End Level");
    
    // Load in a different position when exiting the tavern
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadLevel(string scene) {
        StartCoroutine(ManageLoad(scene));
    }

    IEnumerator ManageLoad(string scene) {
        crossfade.SetTrigger(Property);

        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
