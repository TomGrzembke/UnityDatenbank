using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace JustASpoonful
{
    public class MainMenuManager : MonoBehaviour
    {
        #region Cashes
        [Header("Menu")]
        [SerializeField] GameObject[] menuObjects;
        [SerializeField] GameObject menuBG;
        [SerializeField] Animator transitionAnim;
        [Header("Settings")]
        [SerializeField] Slider musicSlider;
        [SerializeField] Slider sfxSlider;
        [SerializeField] AudioMixer audioMixer;
        [SerializeField] Toggle screenToggle;
        #endregion

        #region Variables

        #endregion

        void Start() => CheckSavedSettings();

        void CheckSavedSettings()
        {
            SetMusicVolume(PlayerPrefs.GetFloat("musicVolume"));
            SetSfxVolume(PlayerPrefs.GetFloat("sfxVolume"));

            //Gets and sets the State of the screentoggle
            bool screenToggleState = PlayerPrefs.GetInt("fullscreenState") == 0;
            Screen.fullScreen = screenToggleState;
            screenToggle.isOn = screenToggleState;
        }

        public void StartCutscene()
        {
            menuBG.SetActive(false);
            for (int i = 0; i < menuObjects.Length; i++)
            {
                menuObjects[i].SetActive(false);
            }
        }

        /// <summary>
        /// Enables one given object and disables the rest
        /// </summary>
        public void EnableMenuObject(GameObject objectToEnable)
        {
            for (int i = 0; i < menuObjects.Length; i++)
            {
                menuObjects[i].SetActive(menuObjects[i] == objectToEnable);
            }
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void OpenURL(string link)
        {
            Application.OpenURL(link);
        }

        #region Settings
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
            float volume = sfxSlider.value;
            audioMixer.SetFloat("sfxVolume", volume);
            PlayerPrefs.SetFloat("sfxVolume", volume);
        }

        public void SetSfxVolume(float volume)
        {
            sfxSlider.value = volume;
        }

        public void FullScreenToggle(bool state)
        {
            state = screenToggle.isOn;
            Screen.fullScreen = state;
            PlayerPrefs.SetInt("fullscreenState", state ? 0 : 1);
        }
        #endregion

        #region Loadscene overload
        /// <summary> Will wait the delay amount of time and play a transition if you specify one at the second index </summary> 
        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }


        /// <summary> Will wait the delay amount of time and play a transition if you specify one at the second index </summary>
        public void LoadScene(int sceneID)
        {
            SceneManager.LoadScene(sceneID);
        }

        /// <summary> Will wait the delay amount of time </summary>
        public void LoadScene(int sceneID, float delay)
        {
            StartCoroutine(LoadSceneWithDelay(sceneID, delay));
        }

        /// <summary> Will wait the delay amount of time </summary>   
        public void LoadScene(string scene, float delay)
        {
            StartCoroutine(LoadSceneWithDelay(scene, delay));
        }

        /// <summary> Will wait the delay amount of time </summary>   
        IEnumerator LoadSceneWithDelay(string scene, float delay)
        {
            transitionAnim.SetTrigger("fadeOut");
            yield return new WaitForSeconds(delay);
            LoadScene(scene);
        }

        /// <summary> Will wait the delay amount of time </summary>   
        IEnumerator LoadSceneWithDelay(int sceneID, float delay)
        {
            transitionAnim.SetTrigger("fadeOut");
            yield return new WaitForSeconds(delay);
            LoadScene(sceneID);
        }
        #endregion
    }
}
