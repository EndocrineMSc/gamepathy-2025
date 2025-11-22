using Items;
using Managers;
using UnityEngine;

namespace Environment
{
    public class CassetteScreen : MonoBehaviour
    {
        [SerializeField] private Sprite nextScreen;
        private bool _isSuccess;
        private SpriteRenderer _spriteRenderer;
        private float _timer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (!_isSuccess) return;

            _timer += Time.unscaledDeltaTime;

            if (_timer >= 1f && _spriteRenderer.sprite != nextScreen)
            {
                _spriteRenderer.sprite = nextScreen;
            }
            else if (_timer >= 2f && _spriteRenderer.sprite == nextScreen)
            {
                SceneStateManager.NewItemAvailable.Invoke(InventoryItem.Wristwatch);
                PauseControl.ResumeGame();
                Destroy(gameObject);
            }
        }

        public void StartSuccess()
        {
            _isSuccess = true;
        }
    }
}