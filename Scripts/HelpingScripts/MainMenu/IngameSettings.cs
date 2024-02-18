using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class IngameSettings : MonoBehaviour
{
    #region Access
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider, sfxSlider;
    [SerializeField] Toggle screenToggle;
    [SerializeField] float currentMusicVolume;
    #endregion


    private void Start()
    {
        SetMusicVolume(PlayerPrefs.GetFloat("musicVolume"));
        SetSfxVolume(PlayerPrefs.GetFloat("sfxVolume"));

        if (PlayerPrefs.GetInt("fullscreenID") == 0)
        {
            Screen.fullScreen = true;
            screenToggle.isOn = true;
        }
        else
        {
            Screen.fullScreen = false;
            screenToggle.isOn = false;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnMusicSliderChanged()
    {
        float volume = musicSlider.value;
        currentMusicVolume = volume;
        audioMixer.SetFloat("musicVolume", volume);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void OnSfxSliderChanged()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("sfxVolume", volume);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        currentMusicVolume = volume;
        musicSlider.value = volume;
    }
    public void SetSfxVolume(float volume)
    {
        sfxSlider.value = volume;
    }
    public void FullScreenToggle(bool isFullscreen)
    {
        isFullscreen = screenToggle.isOn;
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("fullscreenID", (isFullscreen ? 0 : 1));
    }

    public float GetCurrentMusicVolume()
    {
        return currentMusicVolume;
    }
}
