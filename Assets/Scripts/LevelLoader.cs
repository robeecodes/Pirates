using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    [SerializeField] private Animator crossfade;
    private static readonly int Property = Animator.StringToHash("End Level");

    public void LoadLevel(string scene) {
        StartCoroutine(ManageLoad(scene));
        
    }

    IEnumerator ManageLoad(string scene) {
        crossfade.SetTrigger(Property);

        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
