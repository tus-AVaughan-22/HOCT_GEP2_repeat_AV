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
    public PlayerInput input;
    public AudioSource cremuNoise;
    public AudioClip deathNoise;
    public float deathVolume = 0.5f;

    public float deathHeight;
    public float deathDrop;

    public LogicScript logic;
    public bool cremuIsAlive = true;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = cremu;

        cremuFall = cremuSprites[0];
        cremuJump = cremuSprites[1];

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
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

        if(cremuIsAlive == false)
        {
            input.actions.Disable();
            cremuNoise.PlayOneShot(deathNoise, deathVolume);

        }

        if (cremuBody.position.y > deathHeight)
        {
            CremuDeath();
        }

        if (cremuBody.position.y < deathDrop)
        {
            CremuDeath();
        }
}

    public void Jump()
    {
        Debug.Log("Jump");
        cremuBody.velocity = Vector2.up * flapStrength;
    }

    public void ExitGame()
    {
        Debug.Log("You are leaving the game :(((");
        Application.Quit();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        CremuDeath();
    }

    void CremuDeath()
    {
        logic.gameOver();
        cremuIsAlive = false;
    }

}
