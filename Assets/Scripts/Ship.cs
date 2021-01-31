using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float BaseSpeed = 2f;
    public float WindInfluence = 0f;
    public ShipSize Size = ShipSize.Small;
    public Vector2 Direction;

    private SpriteRenderer thisSpriteRenderer;
    private IEnumerator directionChangeCoroutine;

    public float TurnSpeed = 1f;

    public float Life = 1f;
    public float CommandCooldown = 2f;
    public float LastCommandTime;

    Rigidbody2D Rb2d;
    public ShipSpawner Spawner;

    public GameObject WreckagePrefab;
    public SpotlightController Spotlight;

    Sprite GetSprite(ShipDirection dir, ShipSize size)
    {
        string path = "Graphics/Ships/" + size.ToString().ToLower() + "_ship_" + dir.ToString().ToLower();
        return Resources.Load<Sprite>(path);
    }

    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();

        thisSpriteRenderer = GetComponent<SpriteRenderer>();

        LastCommandTime = 0f;
    }

    void UpdateSprite()
    {
        if (Mathf.Abs(Rb2d.velocity.x) > Mathf.Abs(Rb2d.velocity.y))
        {
            // use either down/up sprite
            if (Rb2d.velocity.x > 0)
            {
                thisSpriteRenderer.sprite = GetSprite(ShipDirection.East, Size);
            }
            else
            {
                thisSpriteRenderer.sprite = GetSprite(ShipDirection.West, Size);
            }
        }
        else
        {
            // use either left/right sprite
            if (Rb2d.velocity.y > 0)
            {
                thisSpriteRenderer.sprite = GetSprite(ShipDirection.North, Size);
            }
            else
            {
                thisSpriteRenderer.sprite = GetSprite(ShipDirection.South, Size);
            }
        }
    }

    void Update()
    {
        Rb2d.velocity = Direction.normalized * BaseSpeed + WindManager.Instance.WindDirection * WindInfluence;
        UpdateSprite();
    }

    static public int CountShips()
    {
        return GameObject.FindGameObjectsWithTag("Ship").Length;
    }

    public void ChangeDirection(ShipDirection direction)
    {
        LastCommandTime = Time.time;

        StartCoroutine(NoSignalRoutine());

        if (directionChangeCoroutine != null)
        {
            StopCoroutine(directionChangeCoroutine);
        }

        var newDirection = GetDirectionFrom(direction);
        directionChangeCoroutine = ChangeDirectionRoutine(newDirection);
        StartCoroutine(directionChangeCoroutine);
    }

    // TODO: Change this to handle destruction
    IEnumerator NoSignalRoutine()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(CommandCooldown);

        transform.GetChild(0).gameObject.SetActive(false);
    }

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

        directionChangeCoroutine = null;
    }

    // To be called by the obstacle OnCollisionEnter2D
    public void ObstacleCollision()
    {
        Destroy(gameObject);
        RenderCollision();
    }

    public void ShipCollision()
    {
        Destroy(gameObject);
        RenderCollision();
    }

    public void RenderCollision()
    {
        // TODO: Instantiate particles as well
        Instantiate(WreckagePrefab, transform.position, Quaternion.identity);
        LevelManager.Instance.ReducePoint();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            collision.gameObject.GetComponent<Ship>().ShipCollision();
        }
    }
}

public enum ShipDirection
{
    North,
    South,
    East,
    West
}

public enum ShipSize
{
    Small,
    Medium,
    Big
}