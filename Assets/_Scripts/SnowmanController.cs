/* Filename: SnowmanController.cs
 * Author: Catt Symonds
 * Student number: 101209214
 * Date last modified:  08/12/2020
 * Description:enemy AI
 * 
 * Revision History
 * 
 08/12/2020: file created */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanController : MonoBehaviour
{

    public float runForce;
    public Rigidbody2D rigidbody2D;
    public Transform lookAheadPoint;
    public bool isGroundAhead;
    public LayerMask ground;
    public PlayerController player;


    private AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        hitSound = GetComponent<AudioSource>();
 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _LookAhead();
        _Move();

 
    }

    private void _LookAhead()
    {
        var groundHit = Physics2D.Linecast(transform.position, lookAheadPoint.position, ground);
        if (groundHit)
        {
            isGroundAhead = true;
        }
        else
        {
            isGroundAhead = false;
        }

    }


    private void _Move()
    {
        if (isGroundAhead)
        {
            Debug.Log("moving at force: " + runForce);
            rigidbody2D.AddForce(Vector2.right* runForce * Time.deltaTime * transform.localScale.x);

            rigidbody2D.velocity *= 0.90f;
        }
        else
        {
            _FlipX();
        }
    }


    private void _FlipX()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.Hurt(10);
        }
    }



}