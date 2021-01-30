using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestiny : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("PLAYER SCORED A POINT");
        Destroy(collision.gameObject);
    }
}
