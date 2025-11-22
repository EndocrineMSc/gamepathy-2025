using Environment;
using Managers;
using UnityEngine;

namespace Items.SuccessActions
{
    public class CassetteSuccessAction : ItemSuccessActionBase
    {
        [SerializeField] private GameObject cassetteScreen;

        private void Awake()
        {
            cassetteScreen.SetActive(false);
        }

        public override void OnSuccess()
        {
            base.OnSuccess();
            cassetteScreen.SetActive(true);
            cassetteScreen.GetComponent<CassetteScreen>().StartSuccess();
            PauseControl.PauseGame();
        }
    }
}