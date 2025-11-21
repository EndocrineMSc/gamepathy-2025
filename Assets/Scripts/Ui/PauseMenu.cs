using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    /// <summary>
    ///     A simple pause menu for volume control and pausing the game.
    ///     Put into every scene you want to have the menu in.
    ///     Default button set to "P", because of WebGL "Esc" incompability.
    /// </summary>
    public class PauseMenu : MonoBehaviour
    {
        #region Fields and Properties

        private Canvas _settingsCanvas;
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundSlider;

        #endregion

        #region Methods

        private void Start()
        {
            _settingsCanvas = GetComponent<Canvas>();
            _settingsCanvas.enabled = false;
            masterSlider.onValueChanged.AddListener(SetMasterVolume);
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
            soundSlider.onValueChanged.AddListener(SetSoundVolume);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.P)) return;

            if (PauseControl.GameIsPaused)
            {
                PauseControl.ResumeGame();
                _settingsCanvas.enabled = false;
            }
            else
            {
                PauseControl.PauseGame();
                _settingsCanvas.enabled = true;

                masterSlider.value = AudioManager.Instance.MasterVolume;
                musicSlider.value = AudioManager.Instance.MusicVolume;
                soundSlider.value = AudioManager.Instance.SoundVolume;
            }
        }

        private static void SetMasterVolume(float value)
        {
            AudioManager.Instance.SetMasterVolume(value);
        }

        private static void SetMusicVolume(float value)
        {
            AudioManager.Instance.SetMusicVolume(value);
        }

        private static void SetSoundVolume(float value)
        {
            AudioManager.Instance.SetSoundVolume(value);
        }

        public void ResumeGameButton()
        {
            PauseControl.ResumeGame();
            _settingsCanvas.enabled = false;
        }

        #endregion
    }
}