using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornBush : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
  {
    //Set info to player
    ChickenController chickenController = other.GetComponent<ChickenController>();

    if (chickenController != null)
    {
        chickenController.activeSpeedReduction();
    }
  }
}
