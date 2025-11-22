using Managers;
using UnityEngine;

namespace Items.SuccessActions
{
    public class RugFlaskSuccessAction : ItemSuccessActionBase
    {
        [SerializeField] private GameObject lockBox;
        private bool _firstJump;
        private bool _isSuccess;
        private float _timer;

        protected override void Start()
        {
            base.Start();
            lockBox.SetActive(false);
        }

        private void Update()
        {
            if (!_isSuccess) return;

            _timer += Time.unscaledDeltaTime;

            switch (_timer)
            {
                case >= 1f when !_firstJump:
                    SceneStateManager.BackgroundProgress.Invoke();
                    _firstJump = true;
                    break;
                case >= 2f:
                    SceneStateManager.BackgroundProgress.Invoke();
                    SceneStateManager.Instance.LockPuzzleAvailable = true;
                    PauseControl.ResumeGame();
                    lockBox.SetActive(true);
                    Destroy(gameObject);
                    break;
            }
        }

        public override void OnSuccess()
        {
            PauseControl.PauseGame();
            _isSuccess = true;
        }
    }
}