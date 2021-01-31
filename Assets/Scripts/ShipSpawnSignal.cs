using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawnSignal : MonoBehaviour
{
    public float Duration = 3f;
    public GameObject TargetShip;

    void Start()
    {
        var leftLimit = Camera.main.transform.position.x - 9f;
        var rightLimit = Camera.main.transform.position.x + 9f;
        var x = Mathf.Clamp(TargetShip.transform.position.x, leftLimit, rightLimit);
        transform.position = new Vector3(x, TargetShip.transform.position.y, 0f);
    }

    void Update()
    {
        Duration -= Time.deltaTime;

        if (Duration <= 0)
            Destroy(gameObject);

        if(TargetShip != null)
        {
            var leftLimit = Camera.main.transform.position.x - 9f;
            var rightLimit = Camera.main.transform.position.x + 9f;
            var x = Mathf.Clamp(TargetShip.transform.position.x, leftLimit, rightLimit);
            transform.position = new Vector3(x, TargetShip.transform.position.y, 0f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Used to remove signal when spotlight hits
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
