using System.Collections.Generic;
using System.Linq;
using Managers;
using UnityEngine;

namespace Environment
{
    public class Background : MonoBehaviour
    {
        [SerializeField] private List<Sprite> sprites;
        private int _currentProgress;
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.sprite = sprites[_currentProgress];
        }

        private void OnEnable()
        {
            SceneStateManager.BackgroundProgress.AddListener(OnBackgroundProgress);
        }

        private void OnDisable()
        {
            SceneStateManager.BackgroundProgress.RemoveListener(OnBackgroundProgress);
        }

        private void OnBackgroundProgress()
        {
            _currentProgress++;
            _renderer.sprite = sprites.Count - 1 > _currentProgress ? sprites[_currentProgress] : sprites.Last();
        }
    }
}