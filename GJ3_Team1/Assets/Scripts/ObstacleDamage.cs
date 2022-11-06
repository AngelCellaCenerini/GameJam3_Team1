using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    public bool isDamaged = false;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ToAvoid")
        {
            isDamaged = true;
        }
    }
}
