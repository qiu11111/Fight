using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffBulletController : MonoBehaviour
{
    public bool isPre;
    public bool isAction;
    private int counter;
    private CircleCollider2D collider;
    private Rigidbody2D rb;
    private GameObject groundCheck;
    public LayerMask whatIsGround;
    public float timer;
    public Player player;

    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
        collider.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        groundCheck = transform.Find("GroundCheck").gameObject;
        player = PlayerManager.instance.player;
    }
    private void Update()
    {
        if (isPre)
        {
            transform.localScale += new Vector3(0.005f, 0.005f, 0);
            counter++;
            if (counter == 500)
                isPre = false;
        }
        if (Physics2D.Raycast(groundCheck.transform.position, Vector2.down, 1.0f, whatIsGround)){
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            timer += Time.deltaTime;
        }
        if (timer > 5.0f)
        {
            Destroy(this.gameObject);
        }
        
    }
    public void shoot(Vector2 dir)
    {
        isPre = false;
        collider.enabled = true;
        rb.gravityScale = 0.6f;
        rb.velocity = new Vector2(5*dir.x, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<Enemy>().takeDamage(player.getDamage(Weapons.Staff));
    }

}
