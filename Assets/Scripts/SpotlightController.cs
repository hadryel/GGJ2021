using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public float Speed = 15f;

    public GameObject TargetShip;

    void Start()
    {
    }

    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("SpotlightLimit"))
        {
            if (TargetShip != null && GetComponent<TargetLockedInput>().enabled)
                GetComponent<TargetLockedInput>().FreeMovement();
        }
    }
}
