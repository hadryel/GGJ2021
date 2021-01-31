using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SpotlightTrail : MonoBehaviour
{
    public Transform LeftPoint;
    public Transform RightPoint;

    private Light2D LightCone;

    void Start()
    {
        LightCone = GetComponent<Light2D>();
    }

    void Update()
    {
        LightCone.shapePath[1] = RightPoint.position;
        LightCone.shapePath[2] = LeftPoint.position;
    }
}
