using UnityEngine;

namespace Items.SuccessActions
{
    public class TestSuccessAction : ItemSuccessActionBase
    {
        public override void OnSuccess()
        {
            base.OnSuccess();
            Debug.Log("Success");
        }
    }
}