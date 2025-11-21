using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundScaler : MonoBehaviour
    {
        private void Start()
        {
            var sr = GetComponent<SpriteRenderer>();
            if (sr == null) return;

            var cam = Camera.main;
            if (cam == null) return;

            // Get the size of the sprite in world units
            var spriteHeight = sr.sprite.bounds.size.y;
            var spriteWidth = sr.sprite.bounds.size.x;

            // Get camera world size
            var worldHeight = cam.orthographicSize * 2f;
            var worldWidth = worldHeight * cam.aspect;

            // Scale the sprite to fit the camera
            transform.localScale = new Vector3(
                worldWidth / spriteWidth,
                worldHeight / spriteHeight,
                1f
            );
        }
    }
}