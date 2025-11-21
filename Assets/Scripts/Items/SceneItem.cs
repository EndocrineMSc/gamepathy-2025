using System;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Highlighter))]
    [RequireComponent(typeof(ItemSuccessActionBase))]
    public class SceneItem : MonoBehaviour
    {
        [SerializeField] private InteractableItem item;
        [SerializeField] private InventoryItem successItem;

        private Action _successAction;

        private void Awake()
        {
            _successAction = () => GetComponent<ItemSuccessActionBase>().OnSuccess();
        }

        public void OnItemDropped(InventoryItem inventoryItem)
        {
            if (inventoryItem == successItem)
            {
                Debug.Log("richtiges item");
                _successAction();
                return;
            }

            Debug.Log("falsches item");
            // Do fail stuff
        }

        public void OnPlayerNav()
        {
            _successAction();
        }
    }
}