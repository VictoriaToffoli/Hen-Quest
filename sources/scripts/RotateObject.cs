using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWaterMelon : MonoBehaviour
{
    public float rotationSpeed = 20.00f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
