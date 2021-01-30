using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public Vector3 UpperLeftLimit;
    public Vector3 UpperRightLimit;
    public Vector3 LowerLeftLimit;
    public Vector3 LowerRightLimit;

    public float MarginOffset = 3f;
    public GameObject ShipPrefab;

    void Start()
    {
        SpawnNorth(ShipPrefab);
        SpawnSouth(ShipPrefab);
        SpawnEast(ShipPrefab);
        SpawnWest(ShipPrefab);
    }

    void Update()
    {

    }

    public void SpawnNorth(GameObject shipGO)
    {
        Vector2 position = new Vector2(Random.Range(UpperLeftLimit.x + MarginOffset, UpperRightLimit.x - MarginOffset), UpperLeftLimit.y);

        var ship = Instantiate(shipGO, position, Quaternion.identity);

        ship.GetComponent<Ship>().Direction = Ship.GetDirectionFrom(ShipDirection.South);
    }

    public void SpawnSouth(GameObject shipGO)
    {
        Vector2 position = new Vector2(Random.Range(LowerLeftLimit.x + MarginOffset, LowerRightLimit.x - MarginOffset), LowerLeftLimit.y);

        var ship = Instantiate(shipGO, position, Quaternion.identity);

        ship.GetComponent<Ship>().Direction = Ship.GetDirectionFrom(ShipDirection.North);
    }

    public void SpawnEast(GameObject shipGO)
    {
        Vector2 position = new Vector2(UpperRightLimit.x, Random.Range(LowerRightLimit.y + MarginOffset, UpperRightLimit.y - MarginOffset));

        var ship = Instantiate(shipGO, position, Quaternion.identity);

        ship.GetComponent<Ship>().Direction = Ship.GetDirectionFrom(ShipDirection.West);
    }

    public void SpawnWest(GameObject shipGO)
    {
        Vector2 position = new Vector2(UpperLeftLimit.x, Random.Range(LowerLeftLimit.y + MarginOffset, UpperLeftLimit.y - MarginOffset));

        var ship = Instantiate(shipGO, position, Quaternion.identity);

        ship.GetComponent<Ship>().Direction = Ship.GetDirectionFrom(ShipDirection.East);
    }
}
