using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightTargetHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var controller = GetComponentInParent<SpotlightController>();

        if (controller.TargetShip == null)
            controller.TargetShip = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var controller = GetComponentInParent<SpotlightController>();

        if (controller.TargetShip == other.gameObject)
            controller.TargetShip = null;
    }
}
