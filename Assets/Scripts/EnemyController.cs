using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform target;

    [Range(0.01f, 10.0f)]
    public float speed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        //transform.Translate(Vector2.down * speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.AddForce(Vector2.down * speed * Time.deltaTime);
        if (rb.position.y <= -6.0f)
        {
            Destroy(gameObject);
        }
        
    }
}
