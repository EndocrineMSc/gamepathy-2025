using Managers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Character
{
    public class PlayerClickNavigation : MonoBehaviour
    {
        public static UnityEvent TargetReached = new();
        private readonly int _hashSpeed = Animator.StringToHash("Speed");
        private NavMeshAgent _agent;
        private Animator _animator;
        private Camera _cam;
        private bool eventSent;
        private bool ReachedTarget => !_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance;

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
            if (Input.GetMouseButtonDown(0) && !PauseControl.GameIsPaused)
            {
                // Convert mouse to world position
                var mouseWorldPos = _cam.ScreenToWorldPoint(Input.mousePosition);

                // Lock Z (NavMesh plane)
                mouseWorldPos.z = 0f;

                // Move agent
                _agent.SetDestination(mouseWorldPos);
                eventSent = false;
                Debug.Log("Moving to: " + mouseWorldPos);
            }

            // Update animation parameter based on velocity
            /*
            var speedPercent = _agent.velocity.magnitude / _agent.speed;
            _animator.SetFloat(_hashSpeed, speedPercent);
            */

            if (!ReachedTarget || eventSent) return;

            eventSent = true;
            TargetReached.Invoke();
        }
    }
}