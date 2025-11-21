using Managers;
using UnityEngine;

namespace Items.SuccessActions
{
    public class OpenScreenSuccess : ItemSuccessActionBase
    {
        [SerializeField] private GameObject screen;

        public override void OnSuccess()
        {
            if (SceneStateManager.Instance.ExtraScreenOpen) return;

            base.OnSuccess();
            screen.SetActive(true);
            SceneStateManager.ScreenChanged.Invoke(true);
        }

        public void CloseScreen()
        {
            if (!SceneStateManager.Instance.ExtraScreenOpen) return;

            screen.SetActive(false);
            SceneStateManager.ScreenChanged.Invoke(false);
        }
    }
}