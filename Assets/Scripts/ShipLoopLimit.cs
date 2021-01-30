using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLoopLimit : MonoBehaviour
{
    // Looping from north will make the Ship to appear on south
    public ShipDirection LoopDirection;
    public Vector3 LowerLeftLimit;
    public Vector3 UpperRightLimit;

    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var shipGO = collision.gameObject;

        switch (LoopDirection)
        {
            case ShipDirection.North:
                shipGO.transform.position = new Vector3(shipGO.transform.position.x, LowerLeftLimit.y, shipGO.transform.position.z);
                break;
            case ShipDirection.South:
                shipGO.transform.position = new Vector3(shipGO.transform.position.x, UpperRightLimit.y, shipGO.transform.position.z);
                break;
            case ShipDirection.East:
                shipGO.transform.position = new Vector3(LowerLeftLimit.x, shipGO.transform.position.y, shipGO.transform.position.z);
                break;
            case ShipDirection.West:
                shipGO.transform.position = new Vector3(UpperRightLimit.x, shipGO.transform.position.y, shipGO.transform.position.z);
                break;
        }
    }
}
