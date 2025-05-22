using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DeathUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    public void Start()
    {
        text = GetComponent<TextMeshProUGUI>();;
        text.text = "Death " + StaticData.death.ToString();
       
    }
}
