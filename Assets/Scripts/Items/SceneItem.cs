using System;
using Character;
using Managers;
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

        private void OnEnable()
        {
            PlayerClickNavigation.TargetReached.AddListener(OnPlayerNav);
        }

        private void OnDisable()
        {
            PlayerClickNavigation.TargetReached.RemoveListener(OnPlayerNav);
        }

        public void OnMouseDown()
        {
            Debug.Log("OnMouseDown");
            SceneStateManager.Instance.targetSceneItem = this;
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

        private void OnPlayerNav()
        {
            Debug.Log("Player Nav");
            if (SceneStateManager.Instance.targetSceneItem == this) _successAction();
        }
    }
}