using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float BaseSpeed = 2f;
    public float WindInfluence = 0f;
    public Vector2 Direction;

    public float TurnSpeed = 1f;

    Rigidbody2D Rb2d;

    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();

        // Testing
        //Direction = Vector2.down;
        //ChangeDirection(ShipDirection.East);
    }

    void Update()
    {
        // TODO: Update this after creating WindManager
        Rb2d.velocity = Direction.normalized * BaseSpeed + WindManager.Instance.WindDirection * WindInfluence;
    }

    public void ChangeDirection(ShipDirection direction)
    {
        var newDirection = GetDirectionFrom(direction);

        StartCoroutine(ChangeDirectionRoutine(newDirection));
    }

    // TODO: Move this?
    public static Vector2 GetDirectionFrom(ShipDirection direction)
    {
        var newDirection = Vector2.zero;

        switch (direction)
        {
            case ShipDirection.North:
                return Vector2.up;
            case ShipDirection.South:
                return Vector2.down;
            case ShipDirection.East:
                return Vector2.right;
            case ShipDirection.West:
                return Vector2.left;
        }

        return Vector2.zero;
    }

    // TODO: Change the behaviour of switching to opposite direction?
    IEnumerator ChangeDirectionRoutine(Vector2 newDirection)
    {
        float elapsedTime = 0;

        do
        {
            elapsedTime += (TurnSpeed / 100) * Time.deltaTime;
            Direction = Vector2.Lerp(Direction, newDirection, elapsedTime);
            yield return null;
        } while (Direction != newDirection);
    }

    // To be called by the obstacle OnCollisionEnter2D
    public void ObstacleCollision()
    {

    }
}

public enum ShipDirection
{
    North,
    South,
    East,
    West
}