using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Slider slider;
    public float SliderValue;
    public Image MuteImage;

    public Toggle toggle;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumeAudio", 0.5f);
        AudioListener.volume=slider.value;
        CheckIfMuted();

        if (Screen.fullScreen)
        {

            toggle.isOn = true;

        }

        else 
        {
        
        toggle.isOn=false;
        
        }
    }

    public void ChangeSlider (float value)
    {
        SliderValue = value;
        PlayerPrefs.SetFloat("VolumeAudio", SliderValue);
        AudioListener.volume = slider.value;
        CheckIfMuted() ;
    }

    public void CheckIfMuted () 
    {
        if (slider.value == 0)
        {

            MuteImage.enabled = true;

        }
        else
        {
            MuteImage.enabled =false;
        }

    }

    public void Return()
    {

        SceneManager.LoadScene("MainMenu");

    }

    public void FullScreenMode(bool FullScreen)
    {

        Screen.fullScreen=FullScreen;

    }
}
