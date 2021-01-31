using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnboardingManager : MonoBehaviour
{
    private void Start()
    {
        Object.DontDestroyOnLoad(gameObject);
    }

    public void InterruptOnboarding()
    {
        gameObject.SetActive(false);

        GetComponent<OnboardingSignal>().enabled = false;
        GetComponent<OnboardingFocus>().enabled = false;
        GetComponent<OnboardingDirection>().enabled = false;
        GetComponent<OnboardingCooldown>().enabled = false;
        GetComponent<OnboardingGuide>().enabled = false;
    }

    public void Restart()
    {
        GetComponent<OnboardingSignal>().enabled = true;
        gameObject.SetActive(true);
    }
}
