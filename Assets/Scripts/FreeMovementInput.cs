using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovementInput : MonoBehaviour
{
    Rigidbody2D Rb2d;
    SpotlightController Controller;

    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        Controller = GetComponent<SpotlightController>();
    }

    void Update()
    {
        GetDirectionInput();
        GetTargetInput();
    }

    void GetDirectionInput()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        Rb2d.velocity = direction * Controller.Speed;
    }

    void GetTargetInput()
    {
        if (Input.GetButtonDown("Target"))
        {
            if (Controller.TargetShip != null)
            {
                GetComponent<FreeMovementInput>().enabled = false;
                GetComponent<TargetLockedInput>().enabled = true;
            }
        }
    }
}
