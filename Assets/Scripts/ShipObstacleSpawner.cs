using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipObstacleSpawner : MonoBehaviour
{
    public GameObject[] RockPrefabs;

    void Start()
    {
        SpawnRock(RockPrefabs[0], new Vector2(12, 5));
        SpawnRock(RockPrefabs[1], new Vector2(12, -5));
        SpawnRock(RockPrefabs[2], new Vector2(-12, 5));
    }

    void Update()
    {
        
    }

    public void SpawnRock(GameObject rockPrefab, Vector2 position)
    {
        var rockGO = Instantiate(rockPrefab, position, Quaternion.identity);

        //var ship = shipGO.GetComponent<Ship>();
        //ship.Direction = Ship.GetDirectionFrom(direction);
        //ship.Spawner = this;
    }
}
