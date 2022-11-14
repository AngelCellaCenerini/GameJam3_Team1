using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointRespawn : MonoBehaviour
{
    Transform respawnCoordinates;
    public Transform firstRespawn;
    public Transform respawnCoordinates1;
    public Transform respawnCoordinates2;
    public GameObject player;

    bool progress1 = false;
    bool progress2 = false;
    bool currentProgress;

    public GameObject dropOffF1;

    public LivesStringCounter skinChange;
    public GameObject floor2;

    public bool lifeIsLost = false;

    public GameObject cameraAngle;
    Animator animator;


    void Awake()
    {
        // Set Default Respawn
        respawnCoordinates = firstRespawn;
        // Reference Camera Animator
        animator = cameraAngle.GetComponent<Animator>();
    }

    void Start()
    {
        respawnCoordinates = firstRespawn;
    }

    void Update()
    {
        // Check if Second Floor
        if (skinChange.isChanged) 
        {
            // Trigger Respawn
            StartCoroutine(ExecuteAfterTime(2.95f));
        }
        else
        {
            return;
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        // Respawn when Skin is Switched
        if (skinChange.isChanged)
        {
            // Reset
            skinChange.isChanged = false;
            // Respawn Player
            player.transform.position = respawnCoordinates.transform.position;
        }
    }

        void OnTriggerEnter(Collider other)
    {
        // Check if Player meets Checkpoint
        // Identify Checkpoint
        if (other.gameObject.name == "CheckPoinTrigger1")
        {
            progress1 = true;
            dropOffF1.SetActive(true);
            currentProgress = progress1;
            respawnCoordinates = respawnCoordinates1;

            // Change Camera
            animator.SetBool("secondFloor", true);
        }
        else if (other.gameObject.name == "CheckPoinTrigger2")
        {
            progress2 = true;
            currentProgress = progress2;
            respawnCoordinates = respawnCoordinates2;

            // Change Camera
            animator.SetBool("thirdFloor", true);
        }

        // Check if Player drops off platform
        if (other.gameObject.tag == "DropOff")
        {
            // Check if User Reached CHeckpoint
            if (currentProgress)
            {
                Debug.Log("Drop2");
                // Respawn Player
                player.transform.position = respawnCoordinates.transform.position;
            }
            else {
                // Respawn Player
                player.transform.position = respawnCoordinates.transform.position;
                Debug.Log("Drop1");
                // Apply Damage
                lifeIsLost = true;
            }
        }
    }
}
