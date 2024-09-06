using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HBXGBullet : MonoBehaviour
{
    public Vector2 targetPosition;
    public float distance;
    public LayerMask whatIsEnemy;
    public Vector2 direction;
    public float attackDistance;
    public Vector2 HBXGPosition;
    public float speed;
    public GameObject dot;
    

    public float boomRadius;
    public float damage;
    private float timer;


    public void getTheClostEnemyPosition()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position, attackDistance, whatIsEnemy);
        if (colliders.Length == 0)
            return;
        foreach(Collider2D collider in colliders)
        {
            if ((collider.transform.position - transform.position).magnitude < distance)
            {
                distance = (collider.transform.position - transform.position).magnitude;
                targetPosition = collider.transform.position;
            }
        }
    }

    public void  setV()
    {
        float dx = targetPosition.x - HBXGPosition.x;
        float dy = targetPosition.y - HBXGPosition.y;
        float g = Physics2D.gravity.y;
        float t = Mathf.Abs(dx / speed);
        float vy = dy / t - 0.5f * g * t;
        if (dx< 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, vy);
        }
        if (dx > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, vy);
        }
    }
    private void Awake()
    {
        distance = 10000.0f;
        getTheClostEnemyPosition();
    }
    private void Start()
    {
        if (targetPosition != null)
            setV();
    }

    public void hitEnemy()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position, boomRadius, whatIsEnemy);
        if (colliders.Length != 0)
        {
            foreach (Collider2D collider in colliders)
            {
                collider.GetComponent<Enemy>().takeDamage(damage);
            }
            Destroy(this.gameObject);
        }
        
    }
    private void Update()
    {
        hitEnemy();
        timer += Time.deltaTime;
        if (timer > 10.0f)
            Destroy(gameObject);
    }







}
