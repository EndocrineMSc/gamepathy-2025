using Items;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Managers
{
    public class SceneStateManager : MonoBehaviour
    {
        public static SceneStateManager Instance {get; private set;}
        
        public UnityEvent<InventoryItem> onItemSelectionChanged = new();
        
        public InventoryItem SelectedItem { get; private set;}

        private void Awake()
        {
            if (Instance != null) Destroy(gameObject);

            Instance = this;
        }
        
        private void OnEnable()
        {
            onItemSelectionChanged.AddListener(OnItemSelectionChanged);
        }

        private void OnDisable()
        {
            onItemSelectionChanged.RemoveListener(OnItemSelectionChanged);
        }

        private void OnItemSelectionChanged(InventoryItem item)
        {
            SelectedItem = item;
        }
    }
}