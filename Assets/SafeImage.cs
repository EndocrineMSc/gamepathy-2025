using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SafeImage : MonoBehaviour
{
    [SerializeField] private GameObject fadeObject;
    private Image _fadeImage;
    private bool _isFading;
    private bool _isSuccess;
    private float _timer;

    private void Awake()
    {
        _fadeImage = fadeObject.GetComponent<Image>();
        _fadeImage.color = new Color(0, 0, 0, 0);
    }

    private void Update()
    {
        if (!_isSuccess) return;

        _timer += Time.deltaTime;

        if (!(_timer > 3f) || _isFading) return;

        _isFading = true;
        _fadeImage.DOFade(1, 1f);
    }

    public void OnSuccess()
    {
        _isSuccess = true;
    }
}