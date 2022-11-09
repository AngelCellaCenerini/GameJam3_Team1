using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRamp : MonoBehaviour
{
    public GameObject rampUp;
    public GameObject rampDown;

    void Awake()
    {
        // Push Ramp
        rampDown.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ramp")
        {
            // Push Ramp
            rampUp.SetActive(false);
            rampDown.SetActive(true);
        }
    }
}
