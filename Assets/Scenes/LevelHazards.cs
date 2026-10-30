using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHazards : MonoBehaviour
{
    public bool killsFire;
    public bool killsWater;


    //death sound effects
    AudioSource audioSource;
    public AudioClip dyingSound;
    bool isPLayerDying;


    //getting the dying sound effect on awake
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            //sound it doesn't repeat sound effect while touching hazard
            if (isPLayerDying)
            {
                return;
            }
            isPLayerDying = true;


            //getting the death sound but also waiting so that level doesnt reset
            // before audio can play fully
            audioSource.PlayOneShot(dyingSound);
            Invoke("resetLevel", 1f);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (killsWater && hit.collider.CompareTag("Water"))
        {
            //sound it doesn't repeat sound effect while touching hazard
            if (isPLayerDying)
            {
                return;
            }
            isPLayerDying = true;

            //getting the death sound but also waiting so that level doesnt reset
            // before audio can play fully
            audioSource.PlayOneShot(dyingSound);
            Invoke("resetLevel", 1f);
        }

    }

    void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}