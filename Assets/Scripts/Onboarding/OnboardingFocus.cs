using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingFocus : MonoBehaviour
{
    public GameObject TextGO;
    public bool Completed;

    public SpotlightController Spotlight;

    void Start()
    {
    }

    private void OnEnable()
    {
        Spotlight = GetComponent<OnboardingSignal>().Spotlight;

        if (!Completed)
            TextGO.SetActive(true);
        //else
        //    NextStep();
    }

    private void OnDisable()
    {
        TextGO.SetActive(false);
    }

    void Update()
    {
        if (Spotlight.TargetShip != null && Input.GetButtonDown("Target"))
        {
            Completed = true;
            NextStep();
        }
    }

    public void NextStep()
    {
        GetComponent<OnboardingDirection>().enabled = true;
        enabled = false;
    }
}
