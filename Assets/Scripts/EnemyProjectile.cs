using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Range(0.05f, 10.0f)]
    public float shotSpeed = 1.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 projectilePosition = new Vector2(transform.position.x, transform.position.y);
        transform.position = projectilePosition + Vector2.down * shotSpeed * Time.deltaTime;

        if (transform.position.y <= -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
