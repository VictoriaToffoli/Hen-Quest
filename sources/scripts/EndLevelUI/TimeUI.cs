using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class  TimeUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    public void Start()
    {
        text = GetComponent<TextMeshProUGUI>();;
        text.text = "Time " + StaticData.time.ToString("F2");
       
    }
}