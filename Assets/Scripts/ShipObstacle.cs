﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipObstacle : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
            collision.gameObject.GetComponent<Ship>().ObstacleCollision();
    }
}
