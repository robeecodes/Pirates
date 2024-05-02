using UnityEngine;
using UnityEngine.UI;

public class PlayerReputationUI : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private Image image;
    [SerializeField] private Sprite bad;
    [SerializeField] private Sprite neutral;
    [SerializeField] private Sprite good;

    private void Update() {
        image.sprite = playerInfo.reputation switch {
            <= -5 => bad,
            >= 3 => good,
            _ => neutral
        };
    }
}