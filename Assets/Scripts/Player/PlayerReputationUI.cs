using UnityEngine;
using UnityEngine.UI;

public class PlayerReputationUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite bad;
    [SerializeField] private Sprite neutral;
    [SerializeField] private Sprite good;

    private void Update() {
        image.sprite = InfoManager.Instance.reputation switch {
            <= -5 => bad,
            >= 3 => good,
            _ => neutral
        };
    }
}