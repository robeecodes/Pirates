using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainInfo", menuName = "Persistence")]
public class MainInfo : ScriptableObject {
    // This stores data about the main scene, so players don't get additional reputation for doing the same action twice
    [SerializeField] public bool barrelsKicked;
    [SerializeField] public bool cannonsFired;
    
    // Store all trees which have been chopped
    [SerializeField] public List<GameObject> choppedTrees;
    [SerializeField] public List<GameObject> cropsDestroyed;
    
    // Choose if player should spawn in front of tavern door
    [SerializeField] public bool isTavernExit;

    private void OnEnable() {
        barrelsKicked = false;
        cannonsFired = false;

        choppedTrees = new List<GameObject>();
        cropsDestroyed = new List<GameObject>();
        
        isTavernExit = false;
    }
}
