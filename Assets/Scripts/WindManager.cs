using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public static WindManager Instance;
    public Vector2 WindDirection;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Update()
    {
        
    }
}
