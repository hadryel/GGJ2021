using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLockedInput : MonoBehaviour
{
    SpotlightController Controller;

    void Start()
    {
        Controller = GetComponent<SpotlightController>();
    }

    void Update()
    {
        UpdatePosition();
        ProcessTargetInput();
        ProcessDirectionInput();
    }

    void UpdatePosition()
    {
        transform.position = Controller.TargetShip.transform.position;
    }

    void ProcessTargetInput()
    {
        if (Input.GetButtonDown("Target"))
        {
            FreeMovement();
        }
    }

    void ProcessDirectionInput()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            var direction = (Input.GetAxis("Vertical") > 0) ? ShipDirection.North : ShipDirection.South;
            Controller.TargetShip.GetComponent<Ship>().ChangeDirection(direction);
            FreeMovement();
        }
        else if (Input.GetButtonDown("Horizontal"))
        {
            var direction = (Input.GetAxis("Horizontal") > 0) ? ShipDirection.East : ShipDirection.West;
            Controller.TargetShip.GetComponent<Ship>().ChangeDirection(direction);
            FreeMovement();
        }
    }

    void FreeMovement()
    {
        GetComponent<FreeMovementInput>().enabled = true;
        GetComponent<TargetLockedInput>().enabled = false;
    }
}
