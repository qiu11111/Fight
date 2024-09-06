using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hbssController : MonoBehaviour
{
    private float timer;
    public int bulletNumber;
    public Vector2 dir;
    public SpriteRenderer sr;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        dir = PlayerManager.instance.player.faceDir;
        if (dir.x > 0)
        {
            sr.flipX = false;
        }
        if (dir.x < 0)
        {
            sr.flipX = true;
        }
    }

    private void Update()
    {
        transform.localScale = new Vector3(2, 2, 2);
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            shoot();
            bulletNumber--;
            timer = 0;
        }
        if (bulletNumber <= 0&&timer>0.9f)
        {

            GameObject.Destroy(this.gameObject);
        }
    }
    public virtual void shoot()
    {
        GameObject bullet=Instantiate(Bulletmanager.instance.hbssBullet, transform.position + (Vector3.right * 0.5f)*dir.x+Vector3.up*0.22f, Quaternion.identity);
        bullet.GetComponent<bullet>().setDirection(dir);
    }
}
