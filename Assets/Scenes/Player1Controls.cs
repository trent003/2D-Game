using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //controls
    public Key leftKey = Key.A;
    public Key rightKey = Key.D;
    public Key jumpKey = Key.W;

    //movement speed
    public float moveSpeed = 5f;
    public float jumpSpeed = 10f;

    //setting layer for ground
    public LayerMask groundLayer;


    Rigidbody2D rb;

    float currMoveInput;
    bool jumpKeyPressed;


    //for checking if player is on ground
    bool isGrounded;

    //JUMP SOUND EFFECT
    public AudioClip jumpSoundEffect;
    public AudioSource audioSource;



    void Awake()
    {
        //gets objects RigidBody2d

        rb = GetComponent<Rigidbody2D>();

        //getting jump SE
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        //connects to keyboard
        var kb = Keyboard.current;

        //stops if no keyboard
        if (kb == null)
        {
            return;
        }

        //resets input each frame & check what is keyboard input each frame for movement
        currMoveInput = 0f;

        //moving left
        if (kb[leftKey].isPressed)
        {
            currMoveInput -= 1f;
        }

        //moving right
        if (kb[rightKey].isPressed)
        {
            currMoveInput += 1f;
        }

        //jump
        if (kb[jumpKey].wasPressedThisFrame)
        {
            jumpKeyPressed = true;
        }

    }



    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(currMoveInput * moveSpeed, rb.linearVelocity.y);

        //jumping only if player on ground and pressed jump key
        if (jumpKeyPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            //adding jump sound
            audioSource.PlayOneShot(jumpSoundEffect);

        }

        //resetting
        jumpKeyPressed = false;
        isGrounded = false;
    }
    void OnCollisionStay2D(Collision2D col)
    {

        //seeing if player is on ground object
        if (col.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            return;
        }

        // checking each point when player touches ground object
        foreach (ContactPoint2D contact in col.contacts)
        {
            //if close to 1 then on floor
            // if close to 0 then a wall so doesnt allow jump
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                return;
            }
        }

    }


}