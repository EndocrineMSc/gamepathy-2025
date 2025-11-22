using Managers;
using UnityEngine;

namespace Items.SuccessActions
{
    public class FlaskSuccessAction : ItemSuccessActionBase
    {
        [SerializeField] private GameObject rugFlask;

        protected override void Start()
        {
            base.Start();
            rugFlask.SetActive(false);
        }

        public override void OnSuccess()
        {
            base.OnSuccess();
            SceneStateManager.BackgroundProgress.Invoke();
            rugFlask.SetActive(true);
            Destroy(gameObject);
        }
    }
}