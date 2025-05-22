using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    public void Start()
    {
        text = GetComponent<TextMeshProUGUI>();;
        text.text = "Level " + StaticData.actualLevel.ToString();
       
    }
}
