using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public ItemController itemController;

    private void Awake()
    {
        itemController = GetComponentInParent<ItemController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            itemController.add();
        }

    }
}
