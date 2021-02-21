using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerIntField f;
    public Rigidbody rb;
    public float maxMove;
    public float accMove;
    public float dampMove;
    public Vector3 PlayerPos;
    public bool Possessioning = false;
    // public Animator animator;

    Vector2 input;

    void Start()
    {
        maxMove = maxMove > 0 ? maxMove : 1; 
        accMove = accMove > 0 ? accMove : 1;
    }

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            f.tryInteract();
        }

        if (Possessioning == true)
        {
            PlayerPos = transform.position;
        }

        if (Input.GetKeyDown("e"))
        {
            gameObject.GetComponent<Collider>().enabled = true;
            Possessioning = false;
            gameObject.GetComponentInChildren<Renderer>().enabled = true;
            f.tryUnpossess();
            //still need to change the Interactive Possessed bool
        }

    }

    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        

        input = new Vector2(horizontal, vertical);
        Vector3 velocity = rb.velocity;

        input = input.normalized;

        Vector2 targetVelocity = input * maxMove;
        Vector2 deltaVelocity = targetVelocity - new Vector2(velocity.x, velocity.y);

        if (input.magnitude > 0)
        {
            deltaVelocity *= accMove;
            rb.AddForce(deltaVelocity.x, deltaVelocity.y, 0);
        }
        else
        {
            deltaVelocity *= dampMove;
            rb.AddForce(deltaVelocity.x, deltaVelocity.y, 0);
        }

        rb.velocity = velocity;
    }
    
    public void Possession()
    {
        gameObject.GetComponentInChildren<Renderer>().enabled = false;
        Possessioning = true;
        

    }
}
