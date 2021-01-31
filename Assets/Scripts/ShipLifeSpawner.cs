using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLifeSpawner : MonoBehaviour
{
    public float Range = 1f;
    public GameObject LifePrefab;
    public int LimitOfSpawnedLifes = 1;
    public int CurrentSpawnedLifes = 0;

    public float SpawnLifeTryDelay = 2f;
    float CurrentTryTime;

    void Start()
    {

    }

    void Update()
    {
        CurrentTryTime -= Time.deltaTime;

        if (LevelManager.Instance.GetLifes() < LevelManager.Instance.Deaths && CurrentSpawnedLifes < 1 && CurrentTryTime <= 0)
        {
            CurrentTryTime = SpawnLifeTryDelay;
            if (Random.Range(0f, 1f) > 0.3f)
                SpawnRandomLife();
        }
    }

    public void SpawnRandomLife()
    {
        Vector3 randomPoint = transform.GetChild(Random.Range(0, transform.childCount)).position;

        Vector3 offset = new Vector2(Random.Range(-Range, Range), Random.Range(-Range, Range));
        var lifeGO = Instantiate(LifePrefab, randomPoint + offset, Quaternion.identity);
        lifeGO.GetComponent<ShipLife>().Spawner = this;
        CurrentSpawnedLifes++;
    }

}
