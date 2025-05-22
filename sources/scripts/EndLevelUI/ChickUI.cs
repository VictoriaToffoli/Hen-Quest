using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChickUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    public void Start()
    {
        text = GetComponent<TextMeshProUGUI>();;
        text.text = "Chicks found: " + StaticData.chickCollected.ToString() + " / " + StaticData.chickTotal.ToString();
       
    }
}
