using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testinginputs : MonoBehaviour
{

    public PlayerInput input;
    public Rigidbody2D turnaBody;
    public float jumpStrength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("player jumping")]
    public void Jump()
    {
        Debug.Log("Jump");
        turnaBody.velocity = Vector2.up * jumpStrength;
    }

}
