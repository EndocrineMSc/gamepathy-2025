using UnityEngine;

namespace Items.SuccessActions
{
    public class TestSuccessAction : ItemSuccessActionBase
    {
        public override void OnSuccess()
        {
            Debug.Log("Success");
        }
    }
}