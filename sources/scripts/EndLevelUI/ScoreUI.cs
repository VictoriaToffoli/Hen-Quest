using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class  ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    public void Start()
    {
        text = GetComponent<TextMeshProUGUI>();;
        text.text = "Score: " + StaticData.calculateScore().ToString();
       
    }
}