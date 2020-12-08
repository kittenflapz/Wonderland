/* Filename: PlayerController.cs
 * Author: Catt Symonds
 * Student number: 101209214
 * Date last modified: 09/11/2020
 * Description: Player control and animation
 * 
 * Revision History
 * 09/11/2020: File created 
 08/12/2020: more movement and collision 
 08/12/2020: health feedback 
 08/12/2020: sfx*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Animator animator;

    public TextMeshProUGUI starText;

    [SerializeField]
    Image forceMeter;

    public AudioSource hohoho;


    [SerializeField]
    Image healthMeter;

    [SerializeField]
    float force;

    [SerializeField]
    float maxForce;

    [SerializeField]
    float health;

    [SerializeField]
    float maxHealth;


    bool flying;

     int starNumber;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        hohoho = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        forceMeter.fillAmount = force / maxForce;
        healthMeter.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

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
                    hohoho.Play();
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
       starText.SetText(starNumber.ToString());
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

    public void Hurt(int amount)
    {
        health -= amount;
    }
}
