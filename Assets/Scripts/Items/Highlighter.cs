using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class Highlighter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Sprite itemDefault;
        [SerializeField] private Sprite itemHighlighted;

        private SpriteRenderer spriteRenderer;

        public void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            spriteRenderer.sprite = itemHighlighted;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (Input.GetButtonDown("Highlight")) return;

            spriteRenderer.sprite = itemDefault;
        }
    }
}