using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PWXBulletController : MonoBehaviour
{
    public LayerMask whatIsEnemy;
    private bool isStatic;
    private Vector2 dir;
    private float timer;

    private void Awake()
    {
        transform.parent = null;
    }
    public void setup(Vector2 speed,Sprite sprite,Vector2 dir)
    {
        GetComponent<Rigidbody2D>().velocity = speed;
        GetComponent<SpriteRenderer>().sprite = sprite;
        this.dir = dir;
    }

    private void Update()
    {
        if (!isStatic)
        {
            rotate();
            
        }
        else
        {
            timer += Time.deltaTime;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (timer > 5.0f)
            Destroy(this.gameObject);
            


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GetComponent<Rigidbody2D>().simulated = false;
            isStatic = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 4.0f, whatIsEnemy);
            foreach(Collider2D collider in colliders)
            {
                collider.GetComponent<Enemy>().takeDamage(PlayerManager.instance.player.getDamage(Weapons.Bow));
            }
            Destroy(this.gameObject);
        }
            
    }
    private void rotate()
    {
        //为什么箭矢插在地上会自动往水平方向摆正
        transform.Rotate(0, 0, -0.2f * dir.x) ;
    }

    
}
