using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Settings _settings;
    [SerializeField] AudioMixer _audioMixer;
    [Space]
    [SerializeField] Slider _volumeSlider;
    [SerializeField] Slider _sensivitySldier;
    [SerializeField] TMP_Dropdown _qualityDropdown;
    [SerializeField] TMP_Dropdown _resolutionDropdown;
    [SerializeField] Toggle _toggleFullScreen;

    Resolution[] resolutions;

    private void Awake()
    {
        // Prisluškivanje svih opcija u postavkama te izima
        // njihove vrijendosti prilikom promjene te ih sprema
        // i postavlja te vrijednosti za stvari koje su namjenjene (Volume, grafika, full screen itd.)

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

    // ===================================================================================================

    private void Start()
    {
        // Prilikom starta igrice povlači sve spremljene informacije iz ScriptableObjecta
        // te ih implementira u UI.
        LoadResolutions();
        _volumeSlider.value = _settings.Volume;
        _sensivitySldier.value = _settings.Sensivity;
        _qualityDropdown.value = _settings.Quality;
        _resolutionDropdown.value = _settings.Resolution;
        _toggleFullScreen.isOn = _settings.FullScreen;
        SetResolution(_settings.Resolution);
    }

    // ===================================================================================================

    private void LoadResolutions()
    {

        // Uzima sve važeće rezolucije te ih sprema u listu
        // nakon ispisane liste sprema u dropdown.
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

    // ===================================================================================================

    public void SetResolution (int resolutionIndex)
    {
        // Postavlja odabranu rezoluciju nakon pritiska opcije u dropdownu.
        // Ova funckija se aktivira na eventu u Inspectoru.
        // Uzima stupčanju vrijednost (dropdown) i postavlja ovdje kako bi se znalo koju rezoluciju treba postaviti.
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


}
