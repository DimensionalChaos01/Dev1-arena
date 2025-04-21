using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class volumecontrol : MonoBehaviour
{
    [SerializeField] private string _musicVolumeParameter = "MusicVolume"; // Parameter for music volume
    [SerializeField] private string _sfxVolumeParameter = "SFXVolume"; // Parameter for SFX volume
    [SerializeField] private AudioMixer _musicMixer; // AudioMixer for music
    [SerializeField] private AudioMixer _sfxMixer; // AudioMixer for SFX
    [SerializeField] private Slider _musicSlider; // Slider for music volume
    [SerializeField] private Slider _sfxSlider; // Slider for SFX volume
    [SerializeField] private float _multiplier = 30f; // Multiplier for logarithmic scaling

    private void Awake()
    {
        if (_musicSlider != null)
        {
            _musicSlider.onValueChanged.AddListener(HandleMusicSliderValueChanged);
        }

        if (_sfxSlider != null)
        {
            _sfxSlider.onValueChanged.AddListener(HandleSFXSliderValueChanged);
        }
    }

    private void HandleMusicSliderValueChanged(float value)
    {
        if (_musicMixer != null)
        {
            _musicMixer.SetFloat(_musicVolumeParameter, Mathf.Log10(value) * _multiplier);
        }
    }

    private void HandleSFXSliderValueChanged(float value)
    {
        if (_sfxMixer != null)
        {
            _sfxMixer.SetFloat(_sfxVolumeParameter, Mathf.Log10(value) * _multiplier);
        }
    }

    private void OnDisable()
    {
        if (_musicSlider != null)
        {
            PlayerPrefs.SetFloat(_musicVolumeParameter, _musicSlider.value);
        }

        if (_sfxSlider != null)
        {
            PlayerPrefs.SetFloat(_sfxVolumeParameter, _sfxSlider.value);
        }
    }

    private void Start()
    {
        if (_musicSlider != null)
        {
            _musicSlider.value = PlayerPrefs.GetFloat(_musicVolumeParameter, _musicSlider.value);
        }

        if (_sfxSlider != null)
        {
            _sfxSlider.value = PlayerPrefs.GetFloat(_sfxVolumeParameter, _sfxSlider.value);
        }
    }
}
