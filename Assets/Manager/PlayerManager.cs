using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Player player;

    //物体生成
    public GameObject item;
    public ItemData itemData;

    

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject o=Instantiate(item, player.transform.position + new Vector3(5, 0, 0), Quaternion.identity);
            o.GetComponent<ItemController>().setup(itemData);
        }
    }

}
