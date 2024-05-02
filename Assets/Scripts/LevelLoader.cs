using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    [SerializeField] private Animator crossfade;
    [SerializeField] private MainInfo mainInfo;
    [SerializeField] private PlayerInteract player;
    private static readonly int Property = Animator.StringToHash("End Level");
    
    private void Start() {
        if (SceneManager.GetActiveScene().name == "Main" && mainInfo.isTavernExit) {
            player.transform.position = new Vector3((float)-14.80, (float)5.52, (float)-1.05);
            player.transform.rotation = Quaternion.Euler(0, (float)0, 0);
        }
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
