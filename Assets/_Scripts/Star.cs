/* Filename: Star.cs
 * Author: Catt Symonds
 * Student number: 101209214
 * Date last modified:  08/12/2020
 * Description: star pickup
 * 
 * Revision History
 * 08/12/2020: File created */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    AudioSource twinkle;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            twinkle.Play();
            player.AddStar();
            spriteRenderer.color = Color.clear;
            StartCoroutine(killMe());
        }
    }
    IEnumerator killMe()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
