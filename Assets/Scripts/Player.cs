using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float width;
    private float height;
    private bool isMoving;
    private Vector3 startPos;
    private Rigidbody2D rb;
    public Collider2D bc;

    [Range(10.0f, 200.0f)]
    public float speed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<Collider2D>();
        isMoving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                    if(bc == touchedCollider)
                    {
                        isMoving = true;
                    }                   
                    break;
                case TouchPhase.Moved:
                    if(isMoving)
                    {
                        transform.position = new Vector2(touchPosition.x, touchPosition.y);
                        //startPos = touchPosition * speed * Time.deltaTime;
                        //rb.MovePosition(rb.transform.position + startPos);
                    }
                    break;
                case TouchPhase.Ended:
                    isMoving = false;
                    break;

                    
            }
            //TouchMovement();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log(collision.gameObject);
            rb.velocity = Vector2.zero;
        }
    }

    //void TouchMovement()
    //{
    //    Touch touch = Input.GetTouch(0);
    //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    //    touchPosition = touchPosition * speed * Time.deltaTime;
    //    rb.MovePosition(rb.transform.position + touchPosition);
    //}

}
