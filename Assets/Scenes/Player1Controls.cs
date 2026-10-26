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

    void Awake()
    {
        //gets objects RigidBody2d
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //connects to keyboard
        var kb = Keyboard.current;
        
        if (kb == null) //stops if no keyboard
        {
            return;
        }

        //resets input each frame & check what is keyboard input each frame for movement
        currMoveInput = 0f;
        
        if (kb[leftKey].isPressed) //moving left
        {
            currMoveInput -= 1f;
        }
        
        if (kb[rightKey].isPressed) //moving right
        {
            currMoveInput += 1f;
        }
        
        if (kb[jumpKey].wasPressedThisFrame) //jump
        {
            jumpKeyPressed = true;
        }
    }

    void FixedUpdate()
    {
        //checking if player is on ground
        bool isGrounded = rb.IsTouchingLayers(groundLayer);


        rb.linearVelocity = new Vector2(currMoveInput * moveSpeed, rb.linearVelocity.y);

        if (jumpKeyPressed && isGrounded) //jumping only if player on ground and pressed jump key
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        }

        jumpKeyPressed = false;
    }


}