using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnaMovement : MonoBehaviour
{
    public bool turnaIsActive;
    public GameObject brussPlayer;
    public GameObject turnaPlayer;

    public PlayerInput turnaInput;
    public Rigidbody2D turnaBody;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float speed = 8f;
    public float jumpStrength = 20;
    public bool isGrounded = false;
    private float horizontal;
    public bool facingRight = true;
    public bool isMoving = false;

    //public Animator tAnimator;
    public BrussMovement brussScript;

    private void Start()
    {
        turnaIsActive = false;
    }

    void Update()
    {
        turnaBody.velocity = new Vector2(horizontal * speed, turnaBody.velocity.y);
       // tAnimator.SetFloat("playerSpeed", Mathf.Abs(horizontal)); // Math f Abs (absolute) makes it so the returned value is always pos
    }

    private void FixedUpdate()
    {
  
        if(turnaIsActive == false)
        {
           Follow();
        }

        if(Mathf.Abs(horizontal) == 0f)
        {
            isMoving = false;
        }

        if (horizontal > 0f && !facingRight)
        {
            isMoving = true;
            Flip();
        }
        else if (horizontal < 0f && facingRight)
        {
            isMoving = true;
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
            Debug.Log("jumping!!!!!");
            turnaBody.velocity = new Vector2(turnaBody.velocity.x, jumpStrength);
        }

        if (context.canceled && turnaBody.velocity.y > 0f)
        {
            turnaBody.velocity = new Vector2(turnaBody.velocity.x, turnaBody.velocity.y * 0.5f);
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {

        if(context.performed && isMoving)
        {
            Debug.Log("look at you go!!!");
            speed = 12f;
          //  tAnimator.SetBool("IsRunning", true);
        }

        if(context.canceled)
        {
            speed = 8f;
          //  tAnimator.SetBool("IsRunning", false);
        }
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            speed = 4f;
            Vector3 currentHeight = gameObject.transform.localScale;
            currentHeight.y = 0.5f;
            gameObject.transform.localScale = currentHeight;
        }

        if (context.canceled)
        {
            speed = 8f;
            Vector3 currentHeight = gameObject.transform.localScale;
            currentHeight.y = 1;
            gameObject.transform.localScale = currentHeight;
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Flip()
    {
        Vector3 curentScale = gameObject.transform.localScale;
        curentScale.x *= -1;
        gameObject.transform.localScale = curentScale;

        facingRight = !facingRight;
    }

    public void Swap(InputAction.CallbackContext context)
    {
        if (context.performed && turnaIsActive == true)
        {
            Debug.Log("swap is pressed");
            turnaIsActive = false;
            turnaInput.enabled = false;
            brussScript.brussIsActive = true;
            brussScript.brussInput.enabled = true;
        }
    }

    private void Follow()
    {
        Debug.Log("Following!");

        transform.position = Vector2.MoveTowards(this.transform.position, brussPlayer.transform.position, speed * Time.deltaTime);

    }
}
