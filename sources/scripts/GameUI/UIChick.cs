using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIChick : MonoBehaviour
{
private TextMeshProUGUI text;
    // Start is called before the first frame update
public string total;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();;
    }

    public void UpdateTextChick(PlayerInventory playerInventory)
    {
        text.text = playerInventory.NumberOfChicks.ToString() + " /  " + total;;
    }

}
