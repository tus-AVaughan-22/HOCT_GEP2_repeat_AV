using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CremuScript : MonoBehaviour
{

    public Rigidbody2D cremuBody;
    public float flapStrength;

    [SerializeField] Sprite[] cremuSprites;
    public Sprite cremu;
    private Sprite cremuJump;
    private Sprite cremuFall;
    public float FallingThreshold = -10f;
    public bool isFalling = true;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = cremu;

        cremuFall = cremuSprites[0];
        cremuJump = cremuSprites[1];
    }

    // Update is called once per frame
    void Update()
    {
        // if( InputValue
        if (cremuBody.velocity.y < FallingThreshold)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        if (isFalling)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = cremuFall;
        }

        if (isFalling == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = cremuJump;
        }
        //cremuBody.velocity = Vector2.up * flapStrength;
    }

    public void Jump()
    {
        Debug.Log("Jump");
        cremuBody.velocity = Vector2.up * flapStrength;
    }

}
