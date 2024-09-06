using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    public float liveTime;
    public float timer;
    public float damage;

    

    private void Awake()
    {
        transform.localScale = new Vector3(2, 2, 2);
        rb = GetComponent<Rigidbody2D>();
        liveTime = 10.0f;
    }

    private void Update()
    {
        rb.velocity = speed * direction;
        timer += Time.deltaTime;
        if (timer > liveTime)
        {
            Destroy(gameObject);
        }
    }
    public void setDirection(Vector2 dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().takeDamage(damage);
            Destroy(gameObject);
        }
            
    }
}
