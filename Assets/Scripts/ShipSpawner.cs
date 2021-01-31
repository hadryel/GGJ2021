using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public Vector3 UpperRightLimit;
    public Vector3 LowerLeftLimit;

    public float MarginOffset = 3f;
    public GameObject[] ShipPrefabs;

    public GameObject SpawnSignalPrefab;

    void Start()
    {
        SpawnDirection(ShipPrefabs[0], ShipDirection.North);
        SpawnDirection(ShipPrefabs[1], ShipDirection.South);
        SpawnDirection(ShipPrefabs[2], ShipDirection.East);
        SpawnDirection(ShipPrefabs[2], ShipDirection.West);
    }

    void Update()
    {

    }

    public void SpawnDirection(GameObject shipPrefab, ShipDirection direction)
    {
        Vector2 position = Vector2.zero;

        switch (direction)
        {
            case ShipDirection.North:
                position = new Vector2(Random.Range(LowerLeftLimit.x + MarginOffset, UpperRightLimit.x - MarginOffset), UpperRightLimit.y);
                break;
            case ShipDirection.South:
                position = new Vector2(Random.Range(LowerLeftLimit.x + MarginOffset, UpperRightLimit.x - MarginOffset), LowerLeftLimit.y);
                break;
            case ShipDirection.East:
                position = new Vector2(UpperRightLimit.x, Random.Range(LowerLeftLimit.y + MarginOffset, UpperRightLimit.y - MarginOffset));
                break;
            case ShipDirection.West:
                position = new Vector2(LowerLeftLimit.x, Random.Range(LowerLeftLimit.y + MarginOffset, UpperRightLimit.y - MarginOffset));
                break;
        }

        Spawn(shipPrefab, position, direction);
    }

    void Spawn(GameObject shipPrefab, Vector2 position, ShipDirection direction)
    {
        var shipGO = Instantiate(shipPrefab, position, Quaternion.identity);

        var ship = shipGO.GetComponent<Ship>();
        ship.Direction = Ship.GetDirectionFrom(direction);
        ship.Spawner = this;

        SpawnSignal(shipGO);
    }

    void SpawnSignal(GameObject shipGO)
    {
        var signalGO = Instantiate(SpawnSignalPrefab, Vector3.zero, Quaternion.identity);
        signalGO.GetComponent<ShipSpawnSignal>().TargetShip = shipGO;
    }
}
