using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetup : MonoBehaviour
{
    void OnEnable()
    {
        // TODO: Use PlayerPref to set this (and let it be configured in settings)
        AudioListener.volume = 0.05f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
