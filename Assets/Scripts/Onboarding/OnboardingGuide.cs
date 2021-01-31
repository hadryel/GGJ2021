using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingGuide : MonoBehaviour
{
    public GameObject TextGO;
    public bool Completed;

    GameObject bigIsland;
    GameObject smallIsland;

    private void OnEnable()
    {
        if (!Completed)
        {
            TextGO.SetActive(true);
            bigIsland = GameObject.Find("BigIsland");
            bigIsland.GetComponentInChildren<TargetFlag>(true).gameObject.SetActive(true);
            smallIsland = GameObject.Find("SmallIsland");
            smallIsland.GetComponentInChildren<TargetFlag>(true).gameObject.SetActive(true);
        }
        //else
        //    NextStep();
    }

    private void OnDisable()
    {
        TextGO.SetActive(false);

        if(bigIsland != null)
        {
            bigIsland.GetComponentInChildren<TargetFlag>(true).gameObject.SetActive(false);
        }

        if (smallIsland != null)
        {
            smallIsland.GetComponentInChildren<TargetFlag>(true).gameObject.SetActive(false);
        }
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
