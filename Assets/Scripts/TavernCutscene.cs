using UnityEngine;
using UnityEngine.Playables;

public class TavernCutscene : MonoBehaviour {
    [SerializeField] private TavernInfo tavernInfo;
    [SerializeField] private Dialogue dialogue;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject cutsceneCamera;
    [SerializeField] private GameObject skipUI;
    
    
    private PlayableDirector _director;

    private void Start() {
        if (!tavernInfo.isCutscenePlayed) {
            mainCamera.SetActive(false);
            cutsceneCamera.SetActive(true);
            skipUI.SetActive(true);
            _director = GetComponent<PlayableDirector>();
            _director.Play();
            dialogue.Talk();
            tavernInfo.isCutscenePlayed = true;
        }
        else {
            mainCamera.SetActive(true);
            cutsceneCamera.SetActive(false);
            skipUI.SetActive(false);
        }
    }
}
