using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour
{
    public Settings _settings;
    public AudioMixer _audioMixer;

    //
    public Slider _volumeSlider;
    public Slider _sensivitySldier;
    public TMP_Dropdown _qualityDropdown;
    public TMP_Dropdown _resolutionDropdown;
    public Toggle _toggleFullScreen;

    Resolution[] resolutions;

    private void Awake()
    {
        _volumeSlider.onValueChanged.AddListener((value) =>
        {
            _audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
            _settings.Volume = value;
        });

        _sensivitySldier.onValueChanged.AddListener((value) =>
        {
            _settings.Sensivity = value;
        });

        _qualityDropdown.onValueChanged.AddListener((value) =>
        {
            _settings.Quality = value;
            QualitySettings.SetQualityLevel(value);
        });

        _resolutionDropdown.onValueChanged.AddListener((value) =>
        {
            SetResolution(value);
            _settings.Resolution = value;
        });

        _toggleFullScreen.onValueChanged.AddListener((value) =>
        {
            Screen.fullScreen = value;
            _settings.FullScreen = value;
        });
    }

    private void Start()
    {
        LoadResolutions();

        _volumeSlider.value = _settings.Volume;
        _sensivitySldier.value = _settings.Sensivity;
        _qualityDropdown.value = _settings.Quality;
        _resolutionDropdown.value = _settings.Resolution;
        _toggleFullScreen.isOn = _settings.FullScreen;
        SetResolution(_settings.Resolution);
    }

    private void LoadResolutions()
    {
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        _resolutionDropdown.ClearOptions();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


}
