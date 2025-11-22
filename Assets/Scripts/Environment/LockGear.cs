using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockGear : MonoBehaviour
{
    [SerializeField] private int targetNumber;
    [SerializeField] private Button _upButton;
    [SerializeField] private Button _downButton;
    [SerializeField] private TextMeshProUGUI _currentNumberText;

    private int _currentNumber;
    public bool IsSuccess { get; private set; }

    private void Awake()
    {
        _currentNumberText.text = _currentNumber.ToString();
    }

    public void UpButtonClick()
    {
        _currentNumber = _currentNumber < 9 ? _currentNumber + 1 : 0;
        _currentNumberText.text = _currentNumber.ToString();

        IsSuccess = _currentNumber == targetNumber;
        SceneStateManager.LockGearChanged.Invoke();
    }

    public void DownButtonClick()
    {
        _currentNumber = _currentNumber > 0 ? _currentNumber - 1 : 9;
        _currentNumberText.text = _currentNumber.ToString();

        IsSuccess = _currentNumber == targetNumber;
        SceneStateManager.LockGearChanged.Invoke();
    }
}