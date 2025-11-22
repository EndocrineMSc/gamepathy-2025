using Managers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Character
{
    public class PlayerClickNavigation : MonoBehaviour
    {
        public static UnityEvent TargetReached = new();
        private NavMeshAgent _agent;
        private Camera _cam;
        private SpriteRenderer _spriteRenderer;
        private bool eventSent;
        private bool ReachedTarget => !_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance;

        private void Awake()
        {
            _cam = Camera.main;
            _agent = GetComponent<NavMeshAgent>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        private void Update()
        {
            if (SceneStateManager.Instance.ExtraScreenOpen) return;

            if (Input.GetMouseButtonDown(0) && !PauseControl.GameIsPaused)
            {
                // Convert mouse to world position
                var mouseWorldPos = _cam.ScreenToWorldPoint(Input.mousePosition);

                // Lock Z (NavMesh plane)
                mouseWorldPos.z = 0f;

                var dir = mouseWorldPos - transform.position;
                _spriteRenderer.flipX = dir.x < transform.position.x;

                // Move agent
                _agent.SetDestination(mouseWorldPos);
                eventSent = false;
            }

            if (!ReachedTarget || eventSent) return;

            eventSent = true;
            TargetReached.Invoke();
        }
    }
}