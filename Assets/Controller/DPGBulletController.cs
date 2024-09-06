using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPGBulletController : MonoBehaviour
{
    public Animator anim;
    public AnimatorStateInfo info;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        info = anim.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime > 0.99f)
            Destroy(gameObject);
    }


}
