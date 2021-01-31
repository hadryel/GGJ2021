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

    public int[]   shipsLimit;                      // number of ships for each of the timesteps defined below
    public float[] secondsElapsedForShipsLimitTier; // seconds to consider this limit, this array size must be the same as shipsLimit
    public float[]   secondsIntervalForEachShip;    // interval between ships spawning for this tier

    public int currentTier; // for debugging

    private int getNdxForCurrentTier()
    {
        float now = Time.timeSinceLevelLoad;
        for (int i = 0; i < secondsElapsedForShipsLimitTier.Length; i++)
        {
            if (now < secondsElapsedForShipsLimitTier[i])
            {
                return i;
            }
        }
        return secondsElapsedForShipsLimitTier.Length - 1;
    }

    void Start()
    {
        StartCoroutine(ShipSpawnerRoutine());
    }

    void Update()
    {
        currentTier = getNdxForCurrentTier();
    }

    IEnumerator ShipSpawnerRoutine()
    {
        while (true)
        {
            int tierNdx = getNdxForCurrentTier();
            yield return new WaitForSeconds(secondsIntervalForEachShip[tierNdx]);
            if (Ship.CountShips() < shipsLimit[tierNdx])
            {
                float rnd = Random.Range(0f, 1f);
                int size = Random.Range(0, 3);

                if (rnd < 0.25f)
                {
                    SpawnDirection(ShipPrefabs[size], ShipDirection.North);
                } else if (rnd < 0.5f)
                {
                    SpawnDirection(ShipPrefabs[size], ShipDirection.South);
                } else if (rnd < 0.75f)
                {
                    SpawnDirection(ShipPrefabs[size], ShipDirection.East);
                } else
                {
                    SpawnDirection(ShipPrefabs[size], ShipDirection.West);
                }
            }
        }
    }


    public void SpawnDirection(GameObject shipPrefab, ShipDirection direction)
    {
        Vector2 position = Vector2.zero;

        switch (direction)
        {
            case ShipDirection.North:
                position = new Vector2(Random.Range(LowerLeftLimit.x + MarginOffset, UpperRightLimit.x - MarginOffset), UpperRightLimit.y);
                while ((position.x > -9 && position.x < 4.3) || (position.x > 7.25 && position.x < 9.94) )
                {
                    position = new Vector2(Random.Range(LowerLeftLimit.x + MarginOffset, UpperRightLimit.x - MarginOffset), UpperRightLimit.y);
                }
                break;
            case ShipDirection.South:
                position = new Vector2(Random.Range(LowerLeftLimit.x + MarginOffset, UpperRightLimit.x - MarginOffset), LowerLeftLimit.y);
                while ((position.x > -9 && position.x < 4.3) || (position.x > 7.25 && position.x < 9.94) ) 
                { 
                    position = new Vector2(Random.Range(LowerLeftLimit.x + MarginOffset, UpperRightLimit.x - MarginOffset), LowerLeftLimit.y);
                }
                break;
            case ShipDirection.East:
                position = new Vector2(UpperRightLimit.x, Random.Range(LowerLeftLimit.y + MarginOffset, UpperRightLimit.y - MarginOffset));
                while (position.y > 5.7 && position.y < 9.2) { 
                    position = new Vector2(UpperRightLimit.x, Random.Range(LowerLeftLimit.y + MarginOffset, UpperRightLimit.y - MarginOffset));
                }
                break;
            case ShipDirection.West:
                position = new Vector2(LowerLeftLimit.x, Random.Range(LowerLeftLimit.y + MarginOffset, UpperRightLimit.y - MarginOffset));
                while (position.y > 5.7 && position.y < 9.2)
                {
                    position = new Vector2(LowerLeftLimit.x, Random.Range(LowerLeftLimit.y + MarginOffset, UpperRightLimit.y - MarginOffset));
                }
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
