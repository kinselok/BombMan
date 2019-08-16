using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static float MusicVolume = 1;
    public static float SoundVolume = 1;
    public AudioSource audioVolume;
    public GameObject MainMenu;
    public GameObject SettingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        audioVolume.volume = MusicVolume;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("lvl1");
    }
    public void MusicSliderChanged(float value)
    {
        MusicVolume = value;
        audioVolume.volume = value;
    }
    public void SoundSliderChanged(float value)
    {
        SoundVolume = value;
    }
    public void BackButton()
    {
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void SettingsButton()
    {
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
