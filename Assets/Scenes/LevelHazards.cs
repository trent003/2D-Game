using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHazards : MonoBehaviour
{
    public bool killsFire;
    public bool killsWater;

    void OnCollisionStay2D(Collision2D hit)
    {
        
        // fixes so player doesnt die hitting below pool of opp element
        //player foot position
        float playerBottom = hit.collider.bounds.min.y;
        //getting where player hit the element
        float contact = hit.contacts[0].point.y;

        //ignoring touch unless its at feet
        if (contact > playerBottom + 0.1f)
        {
            return;
        }

        //killing player if they touch wrong element and restarting
        if (killsFire && hit.collider.CompareTag("Fire"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (killsWater && hit.collider.CompareTag("Water"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}