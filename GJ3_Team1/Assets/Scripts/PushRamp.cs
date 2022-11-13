using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRamp : MonoBehaviour
{
    public GameObject ramp;
    Animator animator;


    void Awake()
    {
        animator = ramp.GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ramp")
        {
            // Push Ramp
            animator.SetBool("goesDown", true);

        }
    }
}
