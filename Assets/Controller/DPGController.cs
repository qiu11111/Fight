using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPGController : hbssController
{
    public float attackDistance;
    public float damage;
    public LayerMask whatIsEnemy;
    public override void shoot()
    {

        attackAndHurt();
        GameObject bullet = Instantiate(Bulletmanager.instance.DPGBullet, transform.position + (Vector3.right * 0.5f) * dir.x + Vector3.up * 0.22f, Quaternion.identity);
        //bullet.GetComponent<DPGBulletController>().position = transform;
        bullet.gameObject.SetActive(true);
        bullet.transform.SetParent(transform);
        bullet.transform.localPosition = new Vector3(0, 0, 0);
        //bullet.GetComponent<DPGBulletController>().setupPosition(transform.position);
        if (dir.x < 0)
            bullet.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void attackAndHurt()
    {
        RaycastHit2D[] hits= Physics2D.RaycastAll(transform.position, dir, attackDistance,whatIsEnemy);
        foreach(RaycastHit2D hit in hits)
        {
            hit.collider.GetComponent<Enemy>().takeDamage(damage);
        }
    }
}
