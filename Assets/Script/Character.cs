using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public float maxBlood;
    public float currentBlood;

    public float damage;

    public UnityEvent onHurt;
    public UnityEvent onDie;


    protected virtual void Start()
    {
        currentBlood = maxBlood;
    }

    public void takeDamage(float damage)
    {
        if (currentBlood - damage > 0)
        {
            currentBlood -= damage;
            onHurt?.Invoke();
        }
        else
        {
            currentBlood = 0;
            onDie?.Invoke();
        }
    }
}
