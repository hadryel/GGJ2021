using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public static WindManager Instance;
    public Vector2 WindDirection;

    public float maxChange = 0.2f;
    public float updateIntervalInSeconds = 4f;
    public float suddenChangeProbability = 0.2f;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        StartCoroutine(WindUpdate());
        WindDirection.x = Random.Range(-1, 1);
        WindDirection.y = Random.Range(-1, 1);
    }

    IEnumerator WindUpdate()
    {
        while (true)
        {
            if (Random.Range(0f, 1f) <= suddenChangeProbability)
            {
                WindDirection.x = Random.Range(-1, 1);
                WindDirection.y = Random.Range(-1, 1);
            } else
            {
                WindDirection.x += Random.Range(-1 * maxChange, maxChange);
                WindDirection.y += Random.Range(-1 * maxChange, maxChange);
            }

            if (WindDirection.x < -1) WindDirection.x = -1;
            if (WindDirection.y < -1) WindDirection.y = -1;
            if (WindDirection.x >  1) WindDirection.x =  1;
            if (WindDirection.y >  1) WindDirection.y =  1;

            yield return new WaitForSeconds(updateIntervalInSeconds); // use seconds rather than frames so it's easy to calculate probabilities
        }
    }
}
