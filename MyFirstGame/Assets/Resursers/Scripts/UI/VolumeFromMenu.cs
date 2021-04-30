using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public static class VolumeFromMenu
{
    // Start is called before the first frame update
    public static float GlobalVolume;

    public static float Prefab
    {
        get
        {
            return GlobalVolume;
        }
        set
        {
            GlobalVolume = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().volume;
            
        }
    }
}
