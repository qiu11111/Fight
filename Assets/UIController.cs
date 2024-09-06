using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject Character;
    public GameObject Material;
    public void switchTo(int s)
    {
        ZombieManager.instance.setLevel(s);
    }

    public void switchToInfo(GameObject aim)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive (false);
            transform.Find("message").gameObject.SetActive(true);
        }
        if (aim != null)
        {
            aim.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            switchByKey(Character);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            switchByKey(Material);
        }
    }
    public void switchByKey(GameObject menu)
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
            return;
        }
        switchToInfo(menu);
    }
    private void Start()
    {
        switchToInfo(null);
    }
}
