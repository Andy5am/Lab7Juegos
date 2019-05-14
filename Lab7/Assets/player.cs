using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool poweredUp = false;
    public Sprite powered;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && rb)
        {
            rb.AddForce(new Vector2(0, 12), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (rb)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*1, 0),ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!poweredUp)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("powerUp"))
        {
            Destroy(collision.gameObject);
            poweredUp = true;
            GetComponent<SpriteRenderer>().sprite = powered;
        }
    }
}
