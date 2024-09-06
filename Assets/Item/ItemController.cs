using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ItemData itemData;
    public SpriteRenderer sr;
    public bool isUp;


    private void Awake()
    {
        isUp = true;
    }
    public void setup(ItemData itemData)
    {
        GetComponent<SpriteRenderer>().sprite = itemData.sprite;
        gameObject.name = itemData.itemName;
        this.itemData = itemData;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5, 5), Random.Range(15, 25));
    }
    
    public void add()
    {
        Inventory.instance.addItem(itemData);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isUp)
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    private void Update()
    {
        if (isUp)
        {
            if (GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                isUp = false;
            }
        }
        
    }

}
