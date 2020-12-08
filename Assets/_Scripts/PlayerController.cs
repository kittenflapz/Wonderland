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
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Animator animator;

    [SerializeField]
    Image forceMeter;

    [SerializeField]
    float force;

    [SerializeField]
    float maxForce;

    bool flying;

     int starNumber;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        forceMeter.fillAmount = force / maxForce;

        animator.SetFloat("MoveVectorMagnitude", rigidbody.velocity.magnitude);

        flying = rigidbody.velocity.magnitude > float.Epsilon ? true : false;


        if (!SceneButtonManager.gameIsPaused)
        { // If screen is touched
            if (Input.GetMouseButton(0))
            {
                if (!flying)
                {
                    if (force < maxForce)
                    { force++; }
                }

            }

            if (Input.GetMouseButtonUp(0))
            {
                if (!flying)
                {
                    // Add a velocity in that direction
                    Vector2 playerToTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
                    rigidbody.AddForce(playerToTarget * force);
                    force = 0;
                }
            }
            if (transform.position.y < -10.0f)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public void AddStar()
    {
        starNumber++;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
 

        if (other.gameObject.CompareTag("Moving Platform"))
        {
            other.gameObject.GetComponent<FloatingIcePlatform>().isActive = true;
            transform.SetParent(other.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Moving Platform"))
        {
            other.gameObject.GetComponent<FloatingIcePlatform>().isActive = false;
        }
    }
}
