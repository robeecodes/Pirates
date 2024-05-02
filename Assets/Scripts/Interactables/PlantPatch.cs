using System.Collections;
using UnityEngine;

public class PlantPatch : MonoBehaviour, IInteractable {
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private ParticleSystem _destruction;
    [SerializeField] private GameObject _mud;
    [SerializeField] private AudioClip waterSFX;
    [SerializeField] private AudioClip deathSFX;

    private bool _watered;
    private static readonly int Watering = Animator.StringToHash("Watering");
    private static readonly int Color1 = Shader.PropertyToID("_Color");

    private void Awake() {
        _watered = false;
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        if (!_playerInfo.hasWateringCan) {
            StartCoroutine(DestroyPlants());
        }
        else if (!_watered) {
            Animator playerAnimator = player.GetComponent<Animator>();
            playerAnimator.SetTrigger(Watering);
            AudioSource.PlayClipAtPoint(waterSFX, transform.position,
                1f);
            StartCoroutine(WaterPlants());
            _watered = true;
        }
    }

    IEnumerator DestroyPlants() {
        Instantiate(_destruction, transform.position, _destruction.transform.rotation);
        AudioSource.PlayClipAtPoint(deathSFX, transform.position,
            1.5f);

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    IEnumerator WaterPlants() {
        yield return new WaitForSeconds(1);

        _mud.GetComponent<MeshRenderer>().material.SetColor(Color1, new Color(0.86f, 0.32f, 0.22f, 1));
    }

    public string GetInteractText() {
        if (!_playerInfo.hasWateringCan) {
            return "Destroy Plants";
        }

        if (!_watered) {
            return "Water Plants";
        }

        return null;
    }

    public Transform GetTransform() {
        return transform;
    }
}