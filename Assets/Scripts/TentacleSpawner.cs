using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSpawner : MonoBehaviour
{
    public float Range = 2f;

    public GameObject TentaclePrefab;

    void Start()
    {
        Spawn(TentaclePrefab);
    }

    // TODO: Make Spawners a base class?
    public void Spawn(GameObject tentaclePrefab)
    {
        Vector3 offset = new Vector2(Random.Range(-Range, Range), Random.Range(-Range, Range));
        var tentacleGO = Instantiate(tentaclePrefab, transform.position + offset, Quaternion.identity);
        tentacleGO.transform.parent = transform;
    }
}
