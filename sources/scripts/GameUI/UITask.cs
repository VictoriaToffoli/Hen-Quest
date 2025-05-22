using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITask : MonoBehaviour
{
    private TextMeshProUGUI text;
        // Start is called before the first frame update

        void Start()
        {
            text = GetComponent<TextMeshProUGUI>();;
        }

        public void UpdateObjectiveNest()
        {
            text.text =   "Objective: Return to the nest";
        }

        public void UpdateObjectiveChick()
        {
            text.text =   "Objective: Find a chick";
        }

}