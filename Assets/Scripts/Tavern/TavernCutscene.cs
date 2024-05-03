using StarterAssets;
using UnityEngine;
using UnityEngine.Playables;

public class TavernCutscene : MonoBehaviour {
    [SerializeField] private TavernInfo tavernInfo;
    [SerializeField] private MainInfo mainInfo;
    [SerializeField] private Dialogue dialogue;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject cutsceneCamera;
    [SerializeField] private GameObject skipUI;
    [SerializeField] private GameObject playerUI;
    
    [SerializeField] private GameObject player;
    
    private PlayableDirector _director;

    private void Start() {
        if (!tavernInfo.isCutscenePlayed) {
            tavernInfo.isCutscenePlayed = true;
            mainInfo.isTavernExit = true;
            player.GetComponent<ThirdPersonController>().enabled = false;
            mainCamera.SetActive(false);
            cutsceneCamera.SetActive(true);
            skipUI.SetActive(true);
            playerUI.SetActive(false);
            _director = GetComponent<PlayableDirector>();
            _director.Play();
            dialogue.Talk();
        }
        else {
            mainCamera.SetActive(true);
            cutsceneCamera.SetActive(false);
            skipUI.SetActive(false);
        }
    }
}
