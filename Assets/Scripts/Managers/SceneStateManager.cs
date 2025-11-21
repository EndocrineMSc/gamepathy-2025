using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class SceneStateManager : MonoBehaviour
    {
        public static UnityEvent<InventoryItem> ItemSelected = new();
        public static UnityEvent<InventoryItem> NewItemAvailable = new();
        public static UnityEvent<InventoryItem> NewItemUnavailable = new();
        public static UnityEvent<InventoryItem> ItemListChanged = new();
        public static UnityEvent<bool> ScreenChanged = new();

        public SceneItem targetSceneItem;
        public static SceneStateManager Instance { get; private set; }

        public List<InventoryItem> AvailableItems { get; } = new();

        public InventoryItem SelectedItem { get; private set; }
        public bool ExtraScreenOpen { get; private set; }

        private void Awake()
        {
            if (Instance != null) Destroy(gameObject);

            Instance = this;
        }

        private void OnEnable()
        {
            ItemSelected.AddListener(OnItemSelected);
            NewItemAvailable.AddListener(OnNewItemAvailable);
            NewItemUnavailable.AddListener(OnNewItemUnavailable);
            ScreenChanged.AddListener(OnScreenChanged);
        }

        private void OnDisable()
        {
            ItemSelected.RemoveListener(OnItemSelected);
            NewItemAvailable.RemoveListener(OnNewItemAvailable);
            NewItemUnavailable.RemoveListener(OnNewItemUnavailable);
            ScreenChanged.RemoveListener(OnScreenChanged);
        }

        private void OnItemSelected(InventoryItem item)
        {
            SelectedItem = item;
        }

        private void OnNewItemAvailable(InventoryItem item)
        {
            AvailableItems.Add(item);
            ItemListChanged.Invoke(item);
        }

        private void OnNewItemUnavailable(InventoryItem item)
        {
            AvailableItems.Remove(item);
            ItemListChanged.Invoke(item);
        }

        private void OnScreenChanged(bool isOpen)
        {
            ExtraScreenOpen = isOpen;
        }
    }
}