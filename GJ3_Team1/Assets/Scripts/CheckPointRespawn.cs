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
    public SwitchCharacter characterChoice;
    public GameObject floor2;

    public bool lifeIsLost = false;

    public GameObject cameraAngle;
    Animator animator;

    // SFXs
    public AudioSource audio;
    public AudioClip catRespawn;

    // Ramp
    public GameObject ramp;
    Animator animatorRamp;


    void Awake()
    {
        // Set Default Respawn
        respawnCoordinates = firstRespawn;
        // Reference Camera Animator
        animator = cameraAngle.GetComponent<Animator>();
        animatorRamp = ramp.GetComponent<Animator>();
        // Audio Resource
        audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        respawnCoordinates = firstRespawn;
    }

    void Update()
    {
        // Check if Second Floor
        if (skinChange.isChanged && characterChoice.isConfirmed) 
        {
            // No change
            characterChoice.isConfirmed = false;
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
            // SFX
            playSFX();
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

            // Ramp
            // Push Ramp
            animatorRamp.SetBool("isDown", true);

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
            //if (currentProgress)
            //{
                // Respawn Player
                player.transform.position = respawnCoordinates.transform.position;
                // SFX
                playSFX();
                if (!currentProgress)
                {
                    // Apply Damage
                    lifeIsLost = true;
                }
            //}
            //else {
                // Respawn Player
                //player.transform.position = respawnCoordinates.transform.position;
                // SFX
                //playSFX();
                // Apply Damage
                //lifeIsLost = true;
            //}
        }
    }

    void playSFX()
    {
        //AudioClip.PlayOneShot(catRespawn, 0.2f);
        audio.clip = catRespawn;
        audio.Play();
    }
}
