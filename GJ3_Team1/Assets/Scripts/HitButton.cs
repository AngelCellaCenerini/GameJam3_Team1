using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitButton : MonoBehaviour
{
    public GameObject stairs;

    void Awake()
    {
        if (stairs.activeSelf)
        {
            stairs.SetActive(false);
        }
        
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ButtonToPress")
        {
            // Unlock Stairs
            stairs.SetActive(true);
        }
    }
}
