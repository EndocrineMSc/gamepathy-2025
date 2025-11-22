using Managers;
using UnityEngine;

namespace Environment
{
    public class Calender : MonoBehaviour
    {
        [SerializeField] private GameObject calenderZoomed;

        private void Start()
        {
            calenderZoomed.SetActive(false);
        }

        public void OnMouseDown()
        {
            calenderZoomed.SetActive(true);
            PauseControl.PauseGame();
        }
    }
}