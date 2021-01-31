using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingDirection : MonoBehaviour
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
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        if (Spotlight.TargetShip != null && (x + y) != 0f)
        {
            Completed = true;
            NextStep();
        }
    }

    public void NextStep()
    {
        GetComponent<OnboardingCooldown>().enabled = true;
        enabled = false;
    }
}
