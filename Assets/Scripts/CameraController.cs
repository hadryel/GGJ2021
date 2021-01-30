using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target;
    public float SmoothTime = 0.3f;

    private Vector3 Velocity = Vector3.zero;
    private Vector3 Offset;

    public Vector3 UpperRightLimit;
    public Vector3 LowerLeftLimit;

    void Start()
    {
        Offset = transform.position;
    }

    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        Vector3 targetPosition = Target.transform.TransformPoint(Offset);

        var x = Mathf.Clamp(targetPosition.x, LowerLeftLimit.x, UpperRightLimit.x);
        var y = Mathf.Clamp(targetPosition.y, LowerLeftLimit.y, UpperRightLimit.y);

        targetPosition = new Vector3(x, y, Offset.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref Velocity, SmoothTime);
    }
}
