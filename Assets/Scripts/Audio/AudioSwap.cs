// https://www.youtube.com/watch?v=1VXeyeLthdQ

using System;
using UnityEngine;

public class AudioSwap : MonoBehaviour {
    [SerializeField] private AudioClip newTrack;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "PlayerArmature") {
            AudioManager.instance.SwapTrack(newTrack);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "PlayerArmature") {
            AudioManager.instance.ResetTracks();
        }
    }
}
