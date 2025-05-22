using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour
{

  public AudioClip sound;

  private void OnTriggerEnter(Collider other)
  {
    PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

    if (playerInventory != null)
    {
        playerInventory.WatermelonCollected();
        AudioSource.PlayClipAtPoint(sound, transform.position);
        gameObject.SetActive(false);
    }

    //Set info to player
    ChickenController chickenController = other.GetComponent<ChickenController>();

    if (chickenController != null)
    {
        chickenController.speedBoostActived = true;
    }
  }
}
