using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WatermelonUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    public void Start()
    {
        text = GetComponent<TextMeshProUGUI>();;
        text.text = "Watermelon found: " + StaticData.watermelonCollected.ToString() + " / " + StaticData.watermelonTotal.ToString();
       
    }
}
