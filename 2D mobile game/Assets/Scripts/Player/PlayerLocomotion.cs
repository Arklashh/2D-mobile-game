using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotion : MonoBehaviour
{
    PlayerControls _controls;

    float direction = 0;
    public float speed = 400;
    public bool isRight = true;

    public float jumpForce = 5;
    bool isGrounded;
    int numberOfJumps = 0;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody2D rb;

    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Enable();

        _controls.Player.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        _controls.Player.Move.canceled += ctx =>
        {
            direction = 0;
        };

        _controls.Player.Jump.performed += ctx => Jump();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        rb.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, rb.velocity.y);

        if (isRight && direction < 0 || !isRight && direction > 0)
            Flip();
    }

    void Flip()
    {
        isRight = !isRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            numberOfJumps++;
        }
        else
        {
            if(numberOfJumps == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                numberOfJumps++;
            }
        }
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

}
