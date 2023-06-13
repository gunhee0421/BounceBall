using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Jump : MonoBehaviour
{
    // Start is called before the first frame update
    public float JumForce = 5f;
    public Rigidbody2D rigid2D;
    public AudioSource sound;
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Jump();
        sound.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Star")
        {
            Destroy(collider.gameObject);

            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.EndGame();
        }
    }
    void Jump()
    {
        float xposition = rigid2D.velocity.x;
        rigid2D.velocity = new Vector2(xposition, JumForce);
    }
}
