using Managers;
using UnityEngine;

namespace Environment
{
    public class ZoomedCalender : MonoBehaviour
    {
        public void CloseCalender()
        {
            PauseControl.ResumeGame();
            gameObject.SetActive(false);
        }
    }
}