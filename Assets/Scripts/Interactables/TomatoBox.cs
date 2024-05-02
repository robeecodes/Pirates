using System;
using Unity.VisualScripting;
using UnityEngine;

public class TomatoBox : MonoBehaviour, IReputable {
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private AudioClip squishSFX;
    
    private bool _triggered;

    private void Start() {
        _triggered = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (!_triggered) {
            if (other.gameObject.name == "PlayerArmature") {
                AudioSource.PlayClipAtPoint(squishSFX, transform.position,
                    1f);
                foreach (Transform child in transform)
                    child.AddComponent<Rigidbody>();
                _triggered = true;
            }
            AlterReputation();
        }
    }

    public void AlterReputation() {
        playerInfo.reputation = (float)Math.Max(-10, playerInfo.reputation - 0.25);
    }
}
