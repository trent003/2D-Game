using UnityEngine;
using UnityEngine.SceneManagement;

public class voidHazard : MonoBehaviour
{
    //how fast void rises and delay before it starts rising
    public float riseSpeed = 0.5f;
    public float startDelay = 3f;

    //adding sound effect for void
    AudioSource audioSource;
    public AudioClip voidDeathSound;
    bool isPlayerDying;

    void Update()
    {
        //countsdown delay before moving
        if (startDelay > 0)
        {
            startDelay -= Time.deltaTime;
            return;
        }

        //once countdown is 0 starts moving void every second
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        //if either ember or ripple touches void reset level
        if (player.CompareTag("Fire") || player.CompareTag("Water"))
        {
            //stops repeat audio
            if (isPlayerDying)
            {
                return;
            }
            isPlayerDying = true;

            audioSource.PlayOneShot(voidDeathSound);
            //waits so the sound can play before restarting
            Invoke("resetLevel", 1f);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
