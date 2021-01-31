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

    public float[] secondsElapsedForWindDifficultyTier; // seconds to consider this tier
    public float[] windDifficultyTierMultiplier;        // float to multiply parameters of this tier to increase/decrease difficulty

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

    private int getNdxForCurrentTier()
    {
        float now = Time.timeSinceLevelLoad;
        for (int i = 0; i < secondsElapsedForWindDifficultyTier.Length; i++)
        {
            if (now < secondsElapsedForWindDifficultyTier[i])
            {
                return i;
            }
        }
        return secondsElapsedForWindDifficultyTier.Length - 1;
    }

    private float getTierDifficultyMultiplier()
    {
        if (getNdxForCurrentTier() < 0)
        { // exception if array is not defined
            return 1f;
        }
        return windDifficultyTierMultiplier[getNdxForCurrentTier()];
    }

    IEnumerator WindUpdate()
    {
        while (true)
        {
            float difficultyMultiplier = getTierDifficultyMultiplier();

            if (Random.Range(0f, 1f) <= suddenChangeProbability)
            {
                WindDirection.x = Random.Range(-1, 1) * difficultyMultiplier;
                WindDirection.y = Random.Range(-1, 1) * difficultyMultiplier;
            } else
            {
                float maxChangeD = maxChange * difficultyMultiplier;
                WindDirection.x += Random.Range(-1 * maxChangeD, maxChangeD);
                WindDirection.y += Random.Range(-1 * maxChangeD, maxChangeD);
            }

            if (WindDirection.x < -1 * difficultyMultiplier) WindDirection.x = -1 * difficultyMultiplier;
            if (WindDirection.y < -1 * difficultyMultiplier) WindDirection.y = -1 * difficultyMultiplier;
            if (WindDirection.x >  1 * difficultyMultiplier) WindDirection.x =  1 * difficultyMultiplier;
            if (WindDirection.y >  1 * difficultyMultiplier) WindDirection.y =  1 * difficultyMultiplier;

            yield return new WaitForSeconds(updateIntervalInSeconds); // use seconds rather than frames so it's easy to calculate probabilities
        }
    }
}
