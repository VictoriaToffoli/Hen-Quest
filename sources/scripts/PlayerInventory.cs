using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfWatermelons {get; private set;}
    public int NumberOfChicks {get; private set;}
    public int NumberOfDeath {get; private set;}

    private float lastTimeDeath = 0;

    public bool isChickOnBack = false;
    public GameObject chickOnBack = null;

    public UnityEvent<PlayerInventory> OnChickSaved;
    public UnityEvent<PlayerInventory> OnWatermelonCollected;
    public UnityEvent OnChickCollected;
    public UnityEvent<PlayerInventory> OnDeath;
    
    public void WatermelonCollected()
    {
        NumberOfWatermelons++;
         OnWatermelonCollected.Invoke(this);
        
    }

    public void ChickCollected( GameObject chick)
    {
        //NumberOfChicks++;
        isChickOnBack = true;
        chickOnBack = chick;

        OnChickCollected.Invoke();

    }

    public void ChickSaved()
    {
        NumberOfChicks++;

        OnChickSaved.Invoke(this);
    }

    public void Death(Collider player)
    {
        ChickenController chickenController = player.GetComponent<ChickenController>();

        if (chickenController != null)
        {

           

                
           if (Time.timeSinceLevelLoad - lastTimeDeath < 1)
            {
                //Death to close, not a real death
                return;
            }

            lastTimeDeath = Time.timeSinceLevelLoad;
            NumberOfDeath++;
            chickenController.goToSpawnPoint();
            OnDeath.Invoke(this);

            if (chickOnBack != null)
            {
                Chick chick = chickOnBack.GetComponent<Chick>();

                if (chick != null)
                {
                    chick.returnToSpawnPoint();
                    chickOnBack = null;
                    isChickOnBack = false;
                }
            }

        }


    }

    public bool hasChickOnBack()
    {
        return isChickOnBack;
    }

}
