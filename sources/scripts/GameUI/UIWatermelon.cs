using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIWatermelon : MonoBehaviour
{
private TextMeshProUGUI text;
public string totalWatermelon;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();;
    }

    public void UpdateTextWatermelon(PlayerInventory playerInventory)
    {
        text.text = playerInventory.NumberOfWatermelons.ToString() + " / " + totalWatermelon;
    }
}
