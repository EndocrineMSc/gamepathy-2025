using UnityEngine;

namespace Items
{
    public class Highlighter : MonoBehaviour
    {
        [SerializeField] private Sprite itemDefault;
        [SerializeField] private Sprite itemHighlighted;

        private SpriteRenderer _spriteRenderer;

        public void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) _spriteRenderer.sprite = itemHighlighted;

            if (Input.GetKeyUp(KeyCode.Space)) _spriteRenderer.sprite = itemDefault;
        }

        private void OnMouseEnter()
        {
            _spriteRenderer.sprite = itemHighlighted;
        }

        private void OnMouseExit()
        {
            if (Input.GetKey(KeyCode.Space)) return;
            _spriteRenderer.sprite = itemDefault;
        }
    }
}