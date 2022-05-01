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

    private List<TouchLocations> touches = new List<TouchLocations>();
    private List<int> touchIDs = new List<int>();

    private int movingID;
    private int shootingID;

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
        Vector2 projectilePosition = new Vector2(touchPos.x, touchPos.y);
        Instantiate(projectile, projectilePosition, Quaternion.identity);
    }

    private Vector3 OutputScreenToWorld(Touch touchInput)
    {
        return Camera.main.ScreenToWorldPoint(touchInput.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int i = 0;

        while (i < Input.touchCount)
        {
            Touch touch = Input.GetTouch(i);
            Vector3 touchPosition = OutputScreenToWorld(touch);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                    touchIDs.Add(touch.fingerId);
                    if (bc == touchedCollider)
                    {
                        isMoving = true;
                        movingID = touchIDs.Find(tID => tID == touch.fingerId);
                    }
                    else
                    {
                        prepareToFire = true;
                        toggleShoot = true;
                        shootingID = touchIDs.Find(tID => tID == touch.fingerId);
                    }
                    break;
                case TouchPhase.Moved:
                    if (isMoving && movingID == touch.fingerId)
                    {
                        transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    }
                    if (prepareToFire && shootingID == touch.fingerId)
                    {
                        if (toggleShoot == true)
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
            i++;
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

        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
    }
}
