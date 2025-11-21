using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;

namespace Managers
{
    public class InventoryManager : MonoBehaviour
    {
        private List<UiItem> _inventory;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            _inventory = transform.GetComponentsInChildren<UiItem>().ToList();
            Debug.Log(_inventory.Count.ToString());
            UpdateInventory();
        }

        private void OnEnable()
        {
            SceneStateManager.ItemListChanged.AddListener(UpdateWrapper);
        }

        private void OnDisable()
        {
            SceneStateManager.ItemListChanged.RemoveListener(UpdateWrapper);
        }

        private void UpdateWrapper(InventoryItem _)
        {
            UpdateInventory();
        }

        private void UpdateInventory()
        {
            Debug.Log("Updating Inventory");
            Debug.Log(_inventory.Count.ToString());
            foreach (var item in _inventory)
            {
                Debug.Log(item.name);
                item.gameObject.SetActive(SceneStateManager.Instance.AvailableItems.Contains(item.Item));
            }
        }
    }
}