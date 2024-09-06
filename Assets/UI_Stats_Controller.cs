using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Stats_Controller : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI value;

    public string inputName;


    private void OnValidate()
    {
        gameObject.name = "Ststs-" + inputName;
        if (inputName != null)
        {
            name.text = inputName;
        }
        
    }
    private void Start()
    {
        getValue();
    }

    public void getValue()
    {
        value.text = PlayerManager.instance.player.getStats(inputName).ToString();
    }
}
