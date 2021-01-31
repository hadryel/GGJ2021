using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWreckage : MonoBehaviour
{
    public float Duration = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        Duration -= Time.deltaTime;

        if (Duration <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
            collision.gameObject.GetComponent<Ship>().ObstacleCollision();
    }
}
