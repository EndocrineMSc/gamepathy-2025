using Managers;
using UnityEngine;

namespace Items
{
    public class LockBox : MonoBehaviour
    {
        [SerializeField] private GameObject lockImage;
        [SerializeField] private GameObject safeObject;

        private void Start()
        {
            lockImage.SetActive(false);
            safeObject.SetActive(false);
        }

        public void OnMouseDown()
        {
            if (!SceneStateManager.Instance.LockPuzzleAvailable) return;

            lockImage.SetActive(true);
            safeObject.SetActive(true);
            PauseControl.PauseGame();
        }
    }
}