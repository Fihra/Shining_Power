using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Range(0.0005f, 5.0f)]
    public float shotSpeed = 0.05f;
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
        transform.position = projectilePosition + shotSpeed * Time.deltaTime * Vector2.down;

        if (transform.position.y <= -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
