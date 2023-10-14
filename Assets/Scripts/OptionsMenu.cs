using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider slider;
    public float SliderValue;
    public Image MuteImage;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumeAudio", 0.5f);
        AudioListener.volume=slider.value;
        CheckIfMuted();
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
}
