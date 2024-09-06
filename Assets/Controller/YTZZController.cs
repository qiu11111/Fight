using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YTZZController : MonoBehaviour
{
    public float boomDistance;
    public LayerMask whatIsEnemy;
    public float damage;
    public float lastTime;
    private float timer;



    public void boomEvent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, boomDistance, whatIsEnemy);
        foreach(Collider2D collider in colliders)
        {
            collider.GetComponent<Enemy>().takeDamage(damage);
        }
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > lastTime)
        {
            Destroy(gameObject);
        }
    }
}
