using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Navigation : MonoBehaviour {
    public enum State {
        Neutral,
        Happy,
        Scared
    }

    public State state;
    
    private bool _seesPlayer;
    
    private NavMeshAgent _agent;

    private Bounds _bounds;
    private Vector3 _position;

    private float _idleTimer;

    private Animator _animator;

    private static readonly int AnimatorWalkSpeed =
        Animator.StringToHash("WalkSpeed");

    private static readonly int AnimatorState =
        Animator.StringToHash("State");

    private void Start() {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _seesPlayer = false;

        _bounds = _agent.navMeshOwner.GetComponent<NavMeshSurface>().navMeshData.sourceBounds;
        _position = _agent.navMeshOwner.GetComponent<NavMeshSurface>().navMeshData.position;

        _idleTimer = Random.Range(5, 10);

        CreateRandomDestination();

        state = State.Neutral;
    }

    private void Update() {
        if (_agent.remainingDistance < 0.5f  && !_seesPlayer) {
            if (_idleTimer > 0) {
                _idleTimer -= Time.deltaTime;
            }
            else {
                _idleTimer = Random.Range(5, 10);
                CreateRandomDestination();
            }
        }

        // Agents are scared if the player has an axe, but happy if player has watering can.
        // Otherwise, _state is based on player's reputation
        if (InfoManager.Instance.hasAxe) {
            state = State.Scared;
        } else if (InfoManager.Instance.hasWateringCan && state != State.Scared) {
            state = State.Happy;
        }
        else {
            float rep = InfoManager.Instance.reputation;
            state = rep switch {
                <= -5 => State.Scared,
                >= 3 => State.Happy,
                _ => State.Neutral
            };
        }
    }
    

    private void OnTriggerStay(Collider other) {
        // Agents stop moving when near the player
        if (other.gameObject.name == "PlayerArmature") {
            _seesPlayer = true;
            _agent.destination = _agent.transform.position;
            _animator.SetFloat(AnimatorWalkSpeed, 0);
            _animator.SetInteger(AnimatorState, (int)state);
        }
    }

    private void OnTriggerExit(Collider other) {
        // Normal movement if player is not nearby
        if (other.gameObject.name == "PlayerArmature") {
            _seesPlayer = false;
            _animator.SetInteger(AnimatorState, 0);
        }
    }

    private void LateUpdate() {
        float speed = _agent.velocity.magnitude;
        _animator.SetFloat(AnimatorWalkSpeed, speed);
    }

    private void CreateRandomDestination() {
        // Generate a random destination on the navmesh
        float x = Random.Range(_position.x - _bounds.extents.x, _position.x + _bounds.extents.x);
        float z = Random.Range(_position.z - _bounds.extents.z, _position.z + _bounds.extents.z);

        var destination = new Vector3(x, 0, z);

        _agent.SetDestination(destination);
    }
}