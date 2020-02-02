﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlayerCollisionHandler : MonoBehaviour
{
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        TeleportToSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TeleportToSpawnPoint()
    {
        this.transform.position = spawnPoint.position;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Debug.Log("Collision.");
        TeleportToSpawnPoint();
    }
}