using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSkybox : MonoBehaviour
{
    public float rotationSpeed = 10f;

    // Update is called once per frame
    void FixedUpdate()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
