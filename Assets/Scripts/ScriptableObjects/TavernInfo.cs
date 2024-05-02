using UnityEngine;

[CreateAssetMenu(fileName = "TavernInfo", menuName = "Persistence")]
public class TavernInfo : ScriptableObject {
    [SerializeField] public bool isCutscenePlayed;

    private void OnEnable() {
        isCutscenePlayed = false;
    }
}
