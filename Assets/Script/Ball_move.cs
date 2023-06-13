using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball_move : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    public float speed = 8f;
    public int Double1 = 0;
    public int Double2 = 0;

    public SpriteRenderer sprite;
    
    // Start is called before the first frame update
    public void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float xspeed = x * speed;
        float yspeed = rigid2D.velocity.y;

        Vector2 newVelocity = new Vector2(xspeed, yspeed);
        rigid2D.velocity = newVelocity;

        if (Double1 > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid2D.AddForce(new Vector2(1,1), ForceMode2D.Impulse); 
                sprite.material.color = Color.yellow;
                Double1--;
            }
        }
        if (Double2 > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid2D.AddForce(new Vector2(0f, 1.3f), ForceMode2D.Impulse);
                sprite.material.color = Color.yellow;
                Double2--;
            }
        }

    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Double1")
        {
            Destroy(collider.gameObject);
            Double1++;
            sprite.material.color = Color.blue;
        }
        else if (collider.gameObject.tag == "Double2")
        {
            Destroy(collider.gameObject);
            Double2++;
            sprite.material.color = Color.red;
        }
        else if(collider.gameObject.tag == "Finish")
        {
            Destroy(this.gameObject);
            reStart();
        }
    }
    public void reStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
