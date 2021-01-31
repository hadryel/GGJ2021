using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingCooldown : MonoBehaviour
{
    public GameObject TextGO;
    public bool Completed;

    public SpotlightController Spotlight;

    float Duration = 3f;
    public float MessageDuration = 3f;

    private void OnEnable()
    {
        Spotlight = GetComponent<OnboardingSignal>().Spotlight;

        if (!Completed)
        {
            TextGO.SetActive(true);
            Duration = MessageDuration;
        }
        else
            NextStep();
    }

    private void OnDisable()
    {
        TextGO.SetActive(false);
    }

    void Start()
    {
    }

    void Update()
    {
        Duration -= Time.deltaTime;

        if (Completed || Duration <= 0)
        {
            Completed = true;
            GetComponent<OnboardingGuide>().enabled = true;
            enabled = false;
        }
    }

    public void NextStep()
    {
        GetComponent<OnboardingGuide>().enabled = true;
        enabled = false;
    }
}
