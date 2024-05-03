using UnityEngine;

public class InfoManager : MonoBehaviour
{
    public static InfoManager Instance;

    [SerializeField] public bool isCutscenePlayed;
    [SerializeField] public bool isTavernExit;
    [SerializeField] public bool hasAxe;
    [SerializeField] public bool hasWateringCan;
    [SerializeField] public float reputation;
    [SerializeField] public bool hasOpenedChest;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        isCutscenePlayed = false;
        isTavernExit = false;
        hasAxe = false;
        hasWateringCan = false;
        reputation = 0;
        hasWateringCan = false;
    }
}
