using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Highlighter))]
    [RequireComponent(typeof(ItemSuccessActionBase))]
    public class SceneItem : MonoBehaviour
    {
        [SerializeField] private InteractableItem item;
        [SerializeField] private InventoryItem successItem;
        
        
    }
}