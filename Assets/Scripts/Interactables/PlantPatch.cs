using System.Collections;
using UnityEngine;

public class PlantPatch : MonoBehaviour, IInteractable {
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private ParticleSystem _destruction;
    [SerializeField] private GameObject _mud;

    private bool _watered;
    private static readonly int Watering = Animator.StringToHash("Watering");

    private void Awake() {
        _watered = false;
    }

    public void Interact(Transform interactor, PlayerInteract player) {
        if (!_playerInfo.hasWateringCan) {
            StartCoroutine(DestroyPlants());
        } else if (!_watered) {
            Animator playerAnimator = player.GetComponent<Animator>();
            _mud.GetComponent<Material>().SetColor("_Color", new Color(0.86f, 0.32f, 0.22f, 1));
            playerAnimator.SetTrigger(Watering);
            _watered = true;
        }

    }

    IEnumerator DestroyPlants() {
        Instantiate(_destruction, transform.position, _destruction.transform.rotation);

        yield return new WaitForSeconds(1);
        
        Destroy(gameObject);
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