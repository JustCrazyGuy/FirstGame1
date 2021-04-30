using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

    
     private float m_MySliderValue;

    void Start()
    {

    }
    public void OnSpeedValue(float volume)
    {
        //  m_MyAudioSource.volume = volume;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().volume = volume;
        VolumeFromMenu.GlobalVolume = volume;
    }
  
}
