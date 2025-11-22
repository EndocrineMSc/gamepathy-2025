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
        private bool _isSuccess;

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
            SceneStateManager.Instance.targetSceneItem = this;
        }

        public void OnItemDropped(InventoryItem inventoryItem)
        {
            if (inventoryItem == successItem) _successAction();

            // Do fail stuff
        }

        private void OnPlayerNav()
        {
            if (SceneStateManager.Instance.targetSceneItem != this || _isSuccess) return;

            if (successItem != InventoryItem.None && SceneStateManager.Instance.SelectedItem != successItem) return;

            _successAction();
            _isSuccess = true;
        }
    }
}