using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class UiItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [field: SerializeField] public InventoryItem Item { get; private set; }

        private Canvas _canvas;
        private CanvasGroup _canvasGroup;
        private Transform _originalParent;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _canvas = GetComponentInParent<Canvas>();
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _originalParent = transform.parent;
            transform.SetParent(_canvas.transform);

            SceneStateManager.ItemSelected.Invoke(Item);

            _canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;

            Vector2 worldPos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null)
            {
                var interactable = hit.collider.GetComponent<SceneItem>();
                if (interactable != null) interactable.OnItemDropped(Item);
            }

            SceneStateManager.ItemSelected.Invoke(InventoryItem.None);

            // (Optionally) snap item back to inventory
            transform.SetParent(_originalParent);
        }
    }
}