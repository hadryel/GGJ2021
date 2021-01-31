using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLife : MonoBehaviour
{
    public ShipLifeSpawner Spawner;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            LevelManager.Instance.AddLife();
            Spawner.CurrentSpawnedLifes--;
            Destroy(gameObject);
        }
    }
}
