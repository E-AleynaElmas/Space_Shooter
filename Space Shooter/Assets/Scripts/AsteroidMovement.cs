﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    Rigidbody physics;
    public float speed;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.velocity = transform.forward * speed;
    }
}
