using Items;
using UnityEngine;
using UnityEngine.AI;

namespace Character
{
    public class PlayerClickNavigation : MonoBehaviour
    {
        private readonly int _hashSpeed = Animator.StringToHash("Speed");
        private NavMeshAgent _agent;
        private Animator _animator;
        private Camera _cam;
        private SceneItem _targetItem;
        private bool reachedTarget => !_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance;


        private void Awake()
        {
            _cam = Camera.main;
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();

            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Convert mouse to world position
                var mouseWorldPos = _cam.ScreenToWorldPoint(Input.mousePosition);

                // Lock Z (NavMesh plane)
                mouseWorldPos.z = 0f;

                // Move agent
                _agent.SetDestination(mouseWorldPos);
                Debug.Log("Moving to: " + mouseWorldPos);
            }


            if (reachedTarget)
            {
                if (_targetItem == null) return;

                _targetItem.OnPlayerNav();
                _targetItem = null;
            }

            // Update animation parameter based on velocity
            /*
            var speedPercent = _agent.velocity.magnitude / _agent.speed;
            _animator.SetFloat(_hashSpeed, speedPercent);
            */
        }
    }
}