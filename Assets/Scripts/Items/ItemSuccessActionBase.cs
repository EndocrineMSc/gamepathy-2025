using UnityEngine;

namespace Items
{
    public abstract class ItemSuccessActionBase : MonoBehaviour
    {
        private AudioSource _successVoiceLine;

        protected virtual void Start()
        {
            _successVoiceLine = GetComponent<AudioSource>();
        }

        public virtual void OnSuccess()
        {
            // AudioManager.Instance.PlayBreaking(_successVoiceLine);
        }
    }
}