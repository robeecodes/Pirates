using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainInfo", menuName = "Persistence")]
public class MainInfo : ScriptableObject {
    // Choose if player should spawn in front of tavern door
    [SerializeField] public bool isTavernExit;

    private void OnEnable() {
        isTavernExit = false;
    }
}
