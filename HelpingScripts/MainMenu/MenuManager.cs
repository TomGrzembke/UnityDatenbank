using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    #region Access
    /// <summary>
    /// The GameObjects holding the Menus
    /// </summary>
    [SerializeField] GameObject main, options, credits, loading;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider, sfxSlider;
    [SerializeField] Toggle screenToggle;
    [SerializeField] SoundController soundController;
    #endregion

    private void Start()
    {
        Time.timeScale = 1f;

        main.SetActive(true);
        options.SetActive(false);
        credits.SetActive(false);
        loading.SetActive(false);

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

    public void PlayGame()
    {
        ButtonClickSound();
        main.SetActive(false);
        loading.SetActive(true);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        ButtonClickSound();
        Application.Quit();
    }

    public void FromTo(GameObject From, GameObject To)
    {
        From.SetActive(false);
        To.SetActive(true);
    }


    #region To
    public void ToOptions()
    {
        ButtonClickSound();
        options.SetActive(true);
        main.SetActive(false);
        credits.SetActive(false);
    }

    public void ToMain()
    {
        BackClickSound();
        main.SetActive(true);
        credits.SetActive(false);
        options.SetActive(false);
    }

    public void ToCredits()
    {
        ButtonClickSound();
        credits.SetActive(true);
        main.SetActive(false);
    }
    #endregion
    public void OnMusicSliderChanged()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("musicVolume", volume);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        musicSlider.value = volume;
    }
    public void OnSfxSliderChanged()
    {

        ButtonClickSound();

        float volume = sfxSlider.value;
        audioMixer.SetFloat("sfxVolume", volume);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
    public void SetSfxVolume(float volume)
    {
        sfxSlider.value = volume;
    }
    public void FullScreenToggle(bool isFullscreen)
    {
        ButtonClickSound();
        isFullscreen = screenToggle.isOn;
        Debug.Log(isFullscreen);
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("fullscreenID", (isFullscreen ? 0 : 1));
    }

    public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }

    #region Sounds
    void ButtonClickSound()
    {
        if (soundController == null) return;
        soundController.ButtonClickSound();
    }
    void BackClickSound()
    {
        if (soundController == null) return;
        soundController.BackClickSound();
    }

    public void HoverButtonSfx()
    {
        if (soundController == null) return;
        soundController.HoverButtonSfx();
    }
    #endregion
}
