using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Serializable]
    private sealed class Audio
    {
        public string Name = default;
        public TMP_Text audioValue = default;
        public Slider audioSlider = default;
    }

    [Header("Audio Mixer")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] List<Audio> audios;

    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip checkpoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        for (int i = 0; i < 2; i++) // sesuai banyaknya slider volume
            SetAudioVolume(0, i);

        if (background != null)
        {
            musicSource.clip = background;
            musicSource.Play();
        }
    }
    public void Play(AudioClip clip)
    {
        if (clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
    }

    public void SetAudioVolume(float volume,int index)
    {
        if (Mathf.Approximately(volume, 0))
            volume = PlayerPrefs.GetFloat(audios[index].Name, 0);

        audioMixer.SetFloat(audios[index].Name, volume / 5f);
        audios[index].audioValue.text = ((int)volume).ToString();
        audios[index].audioSlider.value = volume;
        PlayerPrefs.SetFloat(audios[index].Name, volume);
    }
}
