using UnityEngine;

namespace Character
{
    public class YScaler : MonoBehaviour
    {
        [Header("Y position bounds")] public float yMin; // bottom of screen

        public float yMax = 10f; // top of screen

        [Header("Scale bounds")] public Vector3 scaleAtBottom = Vector3.one * 1.5f;

        public Vector3 scaleAtTop = Vector3.one * 0.5f;

        private void Update()
        {
            // Clamp Y to bounds
            var clampedY = Mathf.Clamp(transform.position.y, yMin, yMax);

            // Get normalized value (0 at bottom, 1 at top)
            var t = (clampedY - yMin) / (yMax - yMin);

            // Lerp scale
            transform.localScale = Vector3.Lerp(scaleAtBottom, scaleAtTop, t);
        }
    }
}