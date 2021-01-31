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
        LevelManager.Instance.ScorePoint();
        Destroy(collision.gameObject);
    }
}
