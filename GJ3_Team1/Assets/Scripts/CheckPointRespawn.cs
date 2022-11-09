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

    public bool lifeIsLost = false;

    void Awake()
    {
        respawnCoordinates = firstRespawn;
    }

    void Start()
    {
        respawnCoordinates = firstRespawn;
    }

    void Update()
    {
        // Respawn when Skin is Switched
        if (skinChange.isChanged)
        {
            // Respawn Player
            player.transform.position = respawnCoordinates.transform.position;

            // Reset
            skinChange.isChanged = false;
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
        }
        else if (other.gameObject.name == "CheckPoinTrigger2")
        {
            progress2 = true;
            currentProgress = progress2;
            respawnCoordinates = respawnCoordinates2;
        }

        // Check if Player drops off platform
        if (other.gameObject.tag == "DropOff")
        {
            // Check if User Reached CHeckpoint
            if (currentProgress)
            {
                // Respawn Player
                player.transform.position = respawnCoordinates.transform.position;
            }
            else {
                // Respawn Player
                player.transform.position = respawnCoordinates.transform.position;
                // Apply Damage
                lifeIsLost = true;
            }
        }
    }
}
