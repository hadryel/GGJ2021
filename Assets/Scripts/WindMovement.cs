using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMovement : MonoBehaviour
{
    Rigidbody2D Rb2d;
    public float WindInfluence = 1f;

    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rb2d.velocity = WindManager.Instance.WindDirection * WindInfluence;
    }
}
