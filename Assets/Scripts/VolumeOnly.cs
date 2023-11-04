using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeOnly : MonoBehaviour
{
    public Slider slider;
    public float SliderValue;


    private void Start()
    {

        slider.value = PlayerPrefs.GetFloat("VolumeAudio", 0.5f);
        AudioListener.volume = slider.value;
        
    }

    public void ChangeSlider(float value)
    {
        SliderValue = value;
        PlayerPrefs.SetFloat("VolumeAudio", SliderValue);
        AudioListener.volume = slider.value;
        

    }



}
