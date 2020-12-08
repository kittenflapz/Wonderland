/* Filename: FloatingIcePlatform.cs
 * Author: Catt Symonds
 * Student number: 101209214
 * Date last modified: 08/12/2020
 * Description: floating ice platform
 * 
 * Revision History
 * 08/12/2020: File created */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatingIcePlatform : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public bool isActive;
    public float platformTimer;

    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        platformTimer = 0;
        isActive = false;
        distance = end.position - start.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            platformTimer += Time.deltaTime;
            _Move();
        }
    }

    private void _Move()
    {
        var distanceX = (distance.x > 0) ? start.position.x + Mathf.PingPong(platformTimer, distance.x) : start.position.x;
        var distanceY = (distance.y > 0) ? start.position.y + Mathf.PingPong(platformTimer, distance.y) : start.position.y;

        transform.position = new Vector3(distanceX, distanceY, 0.0f);
    }
}