using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class OptionsController : MonoBehaviour {



    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown, textureQualityDropdown, antialiasingDropdown, vSyncDropdown;

    public Slider musicVolumeSlider, soundVolumeSlider;
    public AudioSource music, sound;

    public OptionSettings settings;
    public Resolution[] resolutions;

    void OnEnable()
    {
        settings = new OptionSettings();

        //Dynamically allocates possible screen resolutions:
        //Gets array of available resolutions
        resolutions = Screen.resolutions;

        List<Dropdown.OptionData> resolutionString = new List<Dropdown.OptionData>();
        for(int i = 0; i < resolutions.Length; i++)
        {
            //turns every element of that array into strtring, then places in an OptionData
            resolutionString.Add( new Dropdown.OptionData(resolutions[i].ToString()));
        }

        //Sets the options of the resolution setting as the OptionData
        resolutionDropdown.options = resolutionString;
        
    }

    //toggles fullscreen
    public void FullscreenToggleChange()
    {
        settings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    //changes the resolution based on which index is selected
    public void ResolutionDropdownChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, settings.fullscreen, resolutions[resolutionDropdown.value].refreshRate);
        settings.resolutionIndex = resolutionDropdown.value;
    }

    //changes texture quality
    public void TextureQualityDropdownChange()
    {
        settings.textureQuality = QualitySettings.masterTextureLimit = textureQualityDropdown.value;
        
    }

    //changes antialiasing
    public void AntialiasingDropdownChange()
    {
        settings.antialiasing = QualitySettings.antiAliasing = (int)(System.Math.Pow(2.0, (double)antialiasingDropdown.value));
    }

    //changes vsync 
    public void VSyncDropdownChange()
    {
        settings.vSync = QualitySettings.vSyncCount = vSyncDropdown.value;
    }

    //changes volume on music source
    public void MusicVolumeSliderChange()
    {
        settings.musicVolume = music.volume = musicVolumeSlider.value;
    }

    //changer volume on sound source
    public void SoundVolumeSliderChange()
    {
        settings.soundVolume = sound.volume = soundVolumeSlider.value;
    }
}
