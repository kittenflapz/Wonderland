using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingPlatform : MonoBehaviour
{
    public bool isDamaged;
    public SpriteRenderer spriteRenderer;
    public AudioSource crateBreak;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        crateBreak = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            crateBreak.Play();

            if (isDamaged == false)
            {
                isDamaged  = true;
                spriteRenderer.color = Color.red;
            }
            else
            {
                crateBreak.Play();
                Destroy(gameObject);
            }

        }
    }
}
