using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(1f, 10f)]
    public float speed = 5f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        transform.position = currentPos + Vector2.up * speed * Time.deltaTime;

        if(transform.position.y >= 6.0f)
        {
            Destroy(gameObject);
        }
    }
}
