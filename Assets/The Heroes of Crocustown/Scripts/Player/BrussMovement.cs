using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BrussMovement : MonoBehaviour
{

    public Rigidbody2D brussBody;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isFacingRight = true;

    public float speed = 8f;
    public float jumpStrength;

    private float horizontal;


    void Start()
    {
        Debug.Log("Jumping!!!");
    }

    void Update()
    {
        brussBody.velocity = new Vector2(horizontal * speed, brussBody.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        if (context.performed && IsGrounded())
        {
            Debug.Log("Jumping!!!");
            brussBody.velocity = new Vector2(brussBody.velocity.x, jumpStrength);

        }

        //if(context.canceled && brussBody.velocity.y > 0f)
       // {
       //     brussBody.velocity = new Vector2(brussBody.velocity.x, brussBody.velocity.y * 0.5f);
      //  }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= 1f;
        transform.localScale = localScale;
    }

    public void IAMGoingToLoseItAll()
    {
        Debug.Log("I am dropping out");
    }
}
