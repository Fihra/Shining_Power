using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform target;
    public GameObject projectile;
    public GameObject shootingNozzle;

    [Range(1.0f, 100.0f)]
    public float moveSpeed = 25.0f;

    [Range(0.01f, 10.0f)]
    public float secondsToAttack = 1f;

    [Range(0.05f, 10.0f)]
    public float shotSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Shooting", 2.5f, secondsToAttack);
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Shooting()
    {
        Vector2 projectilePosition = shootingNozzle.transform.position;
        GameObject shot = Instantiate(projectile, projectilePosition, Quaternion.identity);
        shot.transform.position = projectilePosition + Vector2.down * shotSpeed * Time.deltaTime;
    }

    void Moving()
    {
        //transform.Translate(Vector2.down * speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.AddForce(Vector2.down * moveSpeed * Time.deltaTime);
        if (rb.position.y <= -6.0f)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

    }
}
