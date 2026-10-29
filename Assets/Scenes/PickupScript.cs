using UnityEngine;

public class Pickup : MonoBehaviour
{
    public DoorScript door;
    //determine which player(fire/water) can go through
    public string requiredElement = "";   

    void OnTriggerEnter2D(Collider2D player)
    {
        bool isPlayer = player.CompareTag("Fire") || player.CompareTag("Water");
        if (!isPlayer)
        {
            return;
        }
        if (!player.CompareTag(requiredElement))
        {
            return;
        }

        //after pick up key opens door and removes key object
        door.Open();
        Destroy(gameObject);  
    }
}