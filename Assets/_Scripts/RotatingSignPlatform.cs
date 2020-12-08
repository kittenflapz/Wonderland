﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSignPlatform : MonoBehaviour
{
    public float rotateSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, rotateSpeed * Time.deltaTime));
    }
}
