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

    // Update is called once per frame
    void Update()
    {
        
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
