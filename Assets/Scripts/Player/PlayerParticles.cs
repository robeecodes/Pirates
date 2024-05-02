using UnityEngine;

public class PlayerParticles : MonoBehaviour {
    [SerializeField] private AudioClip[] ladderSFX;
    [SerializeField] private AudioClip[] swimSFX;
    [SerializeField] private ParticleSystem waterRipple;

    private CharacterController _controller;

    private void Start() {
        _controller = GetComponent<CharacterController>();
    }

    private void WaterRipple() {
        Instantiate(waterRipple, transform.position, waterRipple.transform.rotation);

        if (swimSFX.Length <= 0) return;
        var index = Random.Range(0, swimSFX.Length);
        AudioSource.PlayClipAtPoint(swimSFX[index], transform.TransformPoint(_controller.center),
            0.75f);
    }

    private void ClimbLadder() {
        if (ladderSFX.Length <= 0) return;
        var index = Random.Range(0, ladderSFX.Length);
        AudioSource.PlayClipAtPoint(ladderSFX[index], transform.TransformPoint(_controller.center),
            0.75f);
    }
}