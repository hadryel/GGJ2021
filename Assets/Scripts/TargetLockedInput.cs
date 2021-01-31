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
        if (Controller.TargetShip == null)
            FreeMovement();

        UpdatePosition();
        ProcessTargetInput();
        ProcessDirectionInput();
    }

    void UpdatePosition()
    {
        if (Controller.TargetShip)
        {
            transform.position = Controller.TargetShip.transform.position;
        }
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
        if (Controller.TargetShip == null)
            return;

        Ship targetShip = Controller.TargetShip.GetComponent<Ship>();

        if (Time.time - targetShip.LastCommandTime < targetShip.CommandCooldown)
        {
            return;
        }

        if (Input.GetButtonDown("Vertical"))
        {
            var direction = (Input.GetAxis("Vertical") > 0) ? ShipDirection.North : ShipDirection.South;
            targetShip.ChangeDirection(direction);
        }
        else if (Input.GetButtonDown("Horizontal"))
        {
            var direction = (Input.GetAxis("Horizontal") > 0) ? ShipDirection.East : ShipDirection.West;
            targetShip.ChangeDirection(direction);
        }
    }

    public void FreeMovement()
    {
        GetComponent<FreeMovementInput>().enabled = true;
        GetComponent<TargetLockedInput>().enabled = false;
    }
}
