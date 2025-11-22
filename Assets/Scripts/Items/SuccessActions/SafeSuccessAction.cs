using UnityEngine;

namespace Items.SuccessActions
{
    public class SafeSuccessAction : ItemSuccessActionBase
    {
        [SerializeField] private GameObject safeImage;

        protected override void Start()
        {
            base.Start();
            safeImage.SetActive(false);
        }

        public override void OnSuccess()
        {
            base.OnSuccess();
            safeImage.SetActive(true);
            safeImage.GetComponent<SafeImage>().OnSuccess();
            Destroy(gameObject);
        }
    }
}