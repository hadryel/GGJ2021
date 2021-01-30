using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target;
    public float SmoothTime = 0.3f;

    private Vector3 Velocity = Vector3.zero;
    private Vector3 Offset;

    public Vector3 UpperLeftLimit;
    public Vector3 UpperRightLimit;
    public Vector3 LowerLeftLimit;
    public Vector3 LowerRightLimit;

    void Start()
    {
        Offset = transform.position;
    }

    void Update()
    {
        Vector3 targetPosition = Target.transform.TransformPoint(Offset);

        var x = Mathf.Clamp(targetPosition.x, UpperLeftLimit.x, UpperRightLimit.x);
        var y = Mathf.Clamp(targetPosition.y, LowerLeftLimit.y, UpperLeftLimit.y);

        targetPosition = new Vector3(x, y, Offset.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref Velocity, SmoothTime);
    }
}
