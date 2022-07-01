using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] private string musicParameter = "MusicVolume";
    [SerializeField] private string sfxParameter = "SFXVolume";
    
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;

    [SerializeField] private float _multiplier = 30f;

    private void Awake()
    {
        MusicSlider.onValueChanged.AddListener(HandleMusicSliderValueChange);
        SFXSlider.onValueChanged.AddListener(HandleSfxSliderValueChange);
        
    }

    private void HandleSfxSliderValueChange(float value)
    {
        _audioMixer.SetFloat(sfxParameter, Mathf.Log10(value) * _multiplier);
    }

    private void HandleMusicSliderValueChange(float value)
    {
        _audioMixer.SetFloat(musicParameter, Mathf.Log10(value) * _multiplier);
    }
}
