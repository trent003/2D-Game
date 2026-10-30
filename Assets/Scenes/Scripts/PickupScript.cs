using UnityEngine;

public class Pickup : MonoBehaviour
{
    public DoorScript door;
    //determine which player(fire/water) can go through
    public string requiredElement = "";


    //adding pickip sound
    AudioSource audioSource;
    public AudioClip keyPickupSound;



    void OnTriggerEnter2D(Collider2D player)
    {
        //making sure that correct player picks up correct key element
        bool isPlayer = player.CompareTag("Fire") || player.CompareTag("Water");
        if (!isPlayer)
        {
            return;
        }
        if (!player.CompareTag(requiredElement))
        {
            return;
        }

        //playing sound on key pickup
        audioSource.PlayOneShot(keyPickupSound);
        //after pick up key opens door and removes key object
        door.Open();
        Destroy(gameObject, .25f);  
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}