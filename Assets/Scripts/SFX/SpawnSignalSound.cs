using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSignalSound : MonoBehaviour
{
    public GameObject FirstSound;
    public GameObject SecondSound;
    public float SoundInterval = 0.3f;
    void OnEnable()
    {
        StartCoroutine(PlaySoundRoutine());
    }

    void OnDisable()
    {
        FirstSound.SetActive(false);
        SecondSound.SetActive(false);
    }

    IEnumerator PlaySoundRoutine()
    {
        FirstSound.SetActive(true);

        yield return new WaitForSeconds(SoundInterval);

        SecondSound.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
