using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu:MonoBehaviour
{
    public AudioMixer _audioMixer;
    private float _currentVolume = 0f; // исправить загрузку данных из файла.

    private Resolution[] resolutions;

    public Dropdown resolutionDropdown;
    void Start()
    {
        _audioMixer.SetFloat("Volume", _currentVolume);
        
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width} x {resolutions[i].height}";
            if(!resolutions[i].refreshRate.Equals(Screen.currentResolution.refreshRate))continue;
            
            options.Add(option);



            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    
    public void SetVolume(float value)
    {
        _audioMixer.SetFloat("Volume", value);
        _currentVolume = value;
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
