using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Persistence")]
public class PlayerInfo : ScriptableObject {
    [SerializeField] public bool hasAxe;
    [SerializeField] public bool hasWateringCan;
    [SerializeField] public float reputation;
    [SerializeField] public bool hasOpenedChest;
    
    private void OnEnable() {
        // 0 is a neutral reputation
        reputation = 0;

        hasAxe = false;
        hasWateringCan = false;
        hasOpenedChest = false;
    }
}
