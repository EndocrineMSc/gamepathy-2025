using Managers;
using UnityEngine;

namespace Items.SuccessActions
{
    public class DeskSuccessAction : ItemSuccessActionBase
    {
        [SerializeField] private GameObject drawer;
        private bool _isFinished;
        private bool _isSuccess;
        private float _timer;


        protected override void Start()
        {
            base.Start();
            drawer.SetActive(false);
        }

        private void Update()
        {
            if (!_isSuccess || _isFinished) return;

            _timer += Time.unscaledDeltaTime;
            if (!(_timer >= 2f)) return;

            SceneStateManager.NewItemAvailable.Invoke(InventoryItem.BallpointPen);
            PauseControl.ResumeGame();
            Destroy(drawer);
            _isFinished = true;
        }

        public override void OnSuccess()
        {
            base.OnSuccess();
            drawer.SetActive(true);
            _isSuccess = true;
            PauseControl.PauseGame();
        }
    }
}