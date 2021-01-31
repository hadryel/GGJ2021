using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ThunderManager : MonoBehaviour
{
    AudioSource Thunder;

    public float ThunderInterval = 10f;
    public float RandomOffset = 5f;

    float NextTime;

    public Light2D GlobalLight;
    public float ThunderIntensity = 1f;
    float baseLightIntensity;

    public float ThunderDuration = 0.5f;
    public float SoundDuration = 5f;

    Color FogBaseColor;
    public Color FogReducedColor;

    public SpriteRenderer[] FogLayers;

    void Start()
    {
        NextTime = GetNextTime();

        Thunder = GetComponent<AudioSource>();

        baseLightIntensity = GlobalLight.intensity;
        FogBaseColor = FogLayers[0].color;
    }

    void Update()
    {
        NextTime -= Time.deltaTime;

        if(NextTime <= 0)
        {
            NextTime = GetNextTime();
            StartCoroutine(DoThunder());
        }
    }

    //IEnumerator ThunderRoutine()
    //{
    //    yield return DoThunder();

    //    yield return new WaitForSeconds(5f);

    //    Thunder.enabled = false;
    //}

    public float GetNextTime()
    {
        return Time.time + ThunderInterval + Random.Range(0f, RandomOffset);
    }

    public IEnumerator DoThunder()
    {
        IncreaseLight();
        ReduceFog();

        yield return new WaitForSeconds(ThunderDuration);

        ReduceLight();
        IncreaseFog();

        Thunder.enabled = true;

        yield return new WaitForSeconds(SoundDuration);

        Thunder.enabled = false;
    }

    void IncreaseLight()
    {
        GlobalLight.intensity = ThunderIntensity;
    }

    void ReduceFog()
    {
        for (int i = 0; i < FogLayers.Length; i++)
            FogLayers[i].color = FogReducedColor;
    }
    void ReduceLight()
    {
        GlobalLight.intensity = baseLightIntensity;
    }

    void IncreaseFog()
    {
        for (int i = 0; i < FogLayers.Length; i++)
            FogLayers[i].color = FogBaseColor;
    }
}
