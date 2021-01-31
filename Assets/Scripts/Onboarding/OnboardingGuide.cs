using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingGuide : MonoBehaviour
{
    public GameObject TextGO;
    public bool Completed;

    private void OnEnable()
    {
        if (!Completed)
        {
            TextGO.SetActive(true);
        }
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
        if (LevelManager.Instance.Score > 0)
        {
            Completed = true;
            NextStep();
        }
    }

    public void NextStep()
    {
        //GetComponent<OnboardingCooldown>().enabled = true;
        enabled = false;
    }
}
