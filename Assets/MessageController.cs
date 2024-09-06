using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    private TextMeshProUGUI grade;
    private TextMeshProUGUI timer;

    private void Awake()
    {
        grade = transform.Find("grade").GetComponent<TextMeshProUGUI>();
        timer= transform.Find("timer").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        grade.text = "grade--" + ZombieManager.instance.grade;
        timer.text = "next--" + (20 - Mathf.Floor( ZombieManager.instance.timer)) + "s";
    }

}
