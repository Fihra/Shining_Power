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
    private bool prepareToFire;
    private bool toggleShoot;

    public GameObject projectile;

    [Range(10.0f, 200.0f)]
    public float speed = 100f;

    public float secondsPerAttack = 1f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<Collider2D>();
        isMoving = false;
        //InvokeRepeating("Attack", 1.0f, secondsPerAttack);
    }

    void Attack(Vector3 touchPos)
    {
        //Vector2 projectilePosition = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 projectilePosition = new Vector2(touchPos.x, touchPos.y);
        Instantiate(projectile, projectilePosition, Quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Debug.Log(Input.touchCount);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                    if(bc == touchedCollider)
                    {
                        isMoving = true;
                    }
                    else
                    {
                        prepareToFire = true;
                        toggleShoot = true;
                    }

                    break;
                case TouchPhase.Moved:
                    if(isMoving)
                    {
                        transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    }
                    if(prepareToFire)
                    {
                        if(toggleShoot == true)
                        {
                            Attack(touchPosition);
                        }
                        toggleShoot = false;
                        
                    }
                    break;
                case TouchPhase.Ended:
                    isMoving = false;
                    prepareToFire = false;
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

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
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
