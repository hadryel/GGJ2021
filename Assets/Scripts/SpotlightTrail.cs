using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SpotlightTrail : MonoBehaviour
{
    public Transform LeftPoint;
    public Transform RightPoint;

    private Light2D LightCone;

    void Awake()
    {
        //GetComponent<Light2D>(). = new Vector3[]{ Vector3.zero, Vector3.zero, Vector3.zero };
        LightCone = GetComponent<Light2D>();
        Debug.Log(LightCone.shapePath.Length);
        for (int i = 0; i < LightCone.shapePath.Length; i++)
        {
            Debug.Log(LightCone.shapePath[i]);
        }
    }

    void Update()
    {
        //Debug.Log();
        LightCone.shapePath[1] = RightPoint.position;
        LightCone.shapePath[2] = LeftPoint.position;
    }
}
