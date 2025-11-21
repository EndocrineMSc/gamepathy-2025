using Managers;
using UnityEngine;

namespace Items.SuccessActions
{
    public class AddToInventorySuccess : ItemSuccessActionBase
    {
        [SerializeField] private InventoryItem item;

        public override void OnSuccess()
        {
            Debug.Log("Item successfully added to Inventory");
            Debug.Log(item.ToString());
            SceneStateManager.NewItemAvailable.Invoke(item);
            base.OnSuccess();
        }
    }
}