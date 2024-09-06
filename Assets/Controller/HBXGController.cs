using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBXGController : hbssController
{
    public override void shoot()
    {
        GameObject bullet=Instantiate(Bulletmanager.instance.HBXGBullet, transform.position, Quaternion.identity);
        bullet.GetComponent<HBXGBullet>().HBXGPosition = transform.position;
        bullet.GetComponent<HBXGBullet>().direction = dir;
    }
}
