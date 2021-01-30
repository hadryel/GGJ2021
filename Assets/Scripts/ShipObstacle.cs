using System.Collections;
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
        collision.gameObject.GetComponent<Ship>().ObstacleCollision();
    }
}
