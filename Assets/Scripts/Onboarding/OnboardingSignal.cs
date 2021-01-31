using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingSignal : MonoBehaviour
{
    public GameObject TextGO;
    public bool Completed;

    public SpotlightController Spotlight;

    private void OnEnable()
    {
        StartCoroutine(WaitInitialize());
    }

    IEnumerator WaitInitialize()
    {
        yield return new WaitForSeconds(2f);

        Spotlight = GameObject.Find("Spotlight").GetComponent<SpotlightController>();

        if (!Completed)
            TextGO.SetActive(true);
        //else
        //    NextStep();
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
        if (Spotlight != null && Spotlight.TargetShip != null)
        {
            Completed = true;
            NextStep();
        }
    }

    public void NextStep()
    {
        GetComponent<OnboardingFocus>().enabled = true;
        enabled = false;
    }
}
