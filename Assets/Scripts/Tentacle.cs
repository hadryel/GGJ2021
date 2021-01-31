using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Tentacle : MonoBehaviour
{
    Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            collision.gameObject.GetComponent<Ship>().ObstacleCollision();
            Animator.SetTrigger("Attack");
        }
    }
}
