/* Filename: PlayerController.cs
 * Author: Catt Symonds
 * Student number: 101209214
 * Date last modified: 09/11/2020
 * Description: Player control and animation
 * 
 * Revision History
 * 09/11/2020: File created */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;

    [SerializeField]
    float force;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If screen is touched
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("adding force");
            // Add a velocity in that direction
            Vector2 playerToTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            rigidbody.AddForce(playerToTarget * force);

        }
    }
}
