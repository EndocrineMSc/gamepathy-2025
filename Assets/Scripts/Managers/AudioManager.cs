using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        #region Fields and Properties

        public static AudioManager Instance { get; private set; }

        [field: SerializeField] public AudioMixer MasterMixer { get; private set; }
        [field: SerializeField] public float MasterVolume { get; private set; } = 1;
        [field: SerializeField] public float MusicVolume { get; private set; } = 1;
        [field: SerializeField] public float SoundVolume { get; private set; } = 1;

        private AudioSource _sfxVolumePreviewSound;

        private List<AudioSource> _voiceLines = new();

        #endregion

        #region Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }

            _sfxVolumePreviewSound = GetComponent<AudioSource>();

            //Sets start volumes if they should be adjusted immediately
            SetMasterVolume(MasterVolume);
            SetMusicVolume(MusicVolume);
            SetSoundVolume(SoundVolume, false);
        }

        public void FadeInGameTrack(AudioSource audioSource)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();

            audioSource.DOFade(1f, 3f);
        }

        public void FadeOutGameTrack(AudioSource audioSource, bool keepSilentlyPlaying = false)
        {
            if (!keepSilentlyPlaying)
                audioSource.DOFade(0, 3f).OnComplete(() => StopTrack(audioSource));
            else
                audioSource.DOFade(0, 3f);
        }

        private static void StopTrack(AudioSource audioSource)
        {
            audioSource.Stop();
        }

        //Plays a Sound Effect according to the enum index if it isn't playing already
        public static void PlayOneShot(AudioSource audioSource, bool isVoiceLine = false)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();

            if (isVoiceLine)
                Instance._voiceLines.Add(audioSource);
        }

        //Plays a Sound Effect according to the enum index
        public void PlayUnlimited(AudioSource audioSource)
        {
            audioSource.Play();
        }

        public void PlayBreaking(AudioSource audioSource)
        {
            foreach (var voiceLine in _voiceLines.Where(voiceLine => voiceLine.isPlaying && voiceLine != audioSource))
                voiceLine.Stop();

            if (audioSource.isPlaying) return;

            audioSource.Play();
            _voiceLines.Add(audioSource);
        }

        public void SetMasterVolume(float volume)
        {
            var newVolume = GetLogCorrectedVolume(volume);
            MasterMixer.SetFloat("Master", newVolume);
            MasterVolume = newVolume;
        }

        public void SetMusicVolume(float volume)
        {
            var newVolume = GetLogCorrectedVolume(volume);
            MasterMixer.SetFloat("Music", newVolume);
            MusicVolume = newVolume;
        }

        public void SetSoundVolume(float volume, bool changedBySlider = true)
        {
            var newVolume = GetLogCorrectedVolume(volume);
            MasterMixer.SetFloat("Sound", newVolume);
            SoundVolume = newVolume;

            //Play an exemplary SFX to give the play an auditory volume feedback
            if (changedBySlider)
                PlayOneShot(_sfxVolumePreviewSound);
        }

        private static float GetLogCorrectedVolume(float volume)
        {
            return volume > 0 ? Mathf.Log(volume) * 20f : -80f;
        }

        private void Update()
        {
            var vlCopy = _voiceLines.Where(voiceLine => voiceLine.isPlaying).ToList();
            _voiceLines = vlCopy;
        }

        #endregion
    }
}