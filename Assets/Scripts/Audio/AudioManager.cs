// https://www.youtube.com/watch?v=1VXeyeLthdQ

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;

    [SerializeField] private AudioClip defaultAmbience;

    private AudioSource track01, track02;
    private bool _isPlayingTrack01;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        track01 = gameObject.AddComponent<AudioSource>();
        track01.loop = true;
        track02 = gameObject.AddComponent<AudioSource>();
        track02.loop = true;
        track02.volume = 0.75f;
        
        _isPlayingTrack01 = true;

        
        SwapTrack(defaultAmbience);
    }

    public void SwapTrack(AudioClip newTrack) {
        StopAllCoroutines();

        StartCoroutine(FadeTrack(newTrack));

        _isPlayingTrack01 = !_isPlayingTrack01;
    }

    public void ResetTracks() {
        SwapTrack(defaultAmbience);
    }

    private IEnumerator FadeTrack(AudioClip newTrack) {
        float timeToFade = 2.0f;
        float timeElapsed = 0f;
        
        if (_isPlayingTrack01) {
            track02.clip = newTrack;
            track02.Play();
            while (timeElapsed < timeToFade) {
                track02.volume = Mathf.Lerp(0, 0.75f, timeElapsed / timeToFade);
                track01.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            track01.Stop();
        }
        else {
            track01.clip = newTrack;
            track01.Play();
            while (timeElapsed < timeToFade) {
                track01.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                track02.volume = Mathf.Lerp(0.75f, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            track02.Stop();
        }
    }
}
