using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipObstacleSpawner : MonoBehaviour
{
    public float Range = 1f;

    void Start()
    {
        string path = "Prefabs/Rocks/";
        var rocks = Resources.LoadAll<GameObject>(path);

        SpawnRock(rocks[Random.Range(0, rocks.Length)]);
    }

    public void SpawnRock(GameObject rockPrefab)
    {
        Vector3 offset = new Vector2(Random.Range(-Range, Range), Random.Range(-Range, Range));
        var rockGO = Instantiate(rockPrefab, transform.position + offset, Quaternion.identity);
        rockGO.transform.parent = transform;
    }
}
