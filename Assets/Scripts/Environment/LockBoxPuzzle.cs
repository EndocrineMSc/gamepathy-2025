using System.Collections.Generic;
using System.Linq;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Environment
{
    public class LockBoxPuzzle : MonoBehaviour, IPointerClickHandler
    {
        private List<LockGear> _lockGears;

        private void Awake()
        {
            _lockGears = transform.GetComponentsInChildren<LockGear>().ToList();
        }

        private void OnEnable()
        {
            SceneStateManager.LockGearChanged.AddListener(CheckSuccess);
        }

        private void OnDisable()
        {
            SceneStateManager.LockGearChanged.RemoveListener(CheckSuccess);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PauseControl.ResumeGame();
            gameObject.SetActive(false);
        }

        private void CheckSuccess()
        {
            var size = _lockGears.Count(g => !g.IsSuccess);
            if (size == 0)
            {
                SceneStateManager.BackgroundProgress.Invoke();
                SceneStateManager.Instance.LockPuzzleSolved = true;
                PauseControl.ResumeGame();
                Destroy(gameObject);
            }
        }
    }
}