using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public List<DropData> dropDatas;
    public GameObject itemPrefab;

    public void generateDrops()
    {
        if (dropDatas.Count > 0)
        {
            foreach(DropData data in dropDatas)
            {
                if (Random.Range(0, 1000) < data.rate)
                {
                    GameObject item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
                    item.GetComponent<ItemController>().setup(data.itemData);
                }
            }
        }
    }



}
