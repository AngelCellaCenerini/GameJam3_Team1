using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLadder : MonoBehaviour
{
    public GameObject finalLadder;
    Animator animator;

    float mass;
    Rigidbody rb;

    void Awake()
    {
        animator = finalLadder.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //rb.mass = mass;
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinalButton")
        {
            // Push Ramp
            animator.SetBool("goesDown", true);
            rb.mass = 20f;

        }
    }
}
