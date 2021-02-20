using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<Interactive> interactives = new List<Interactive>();
    public Rigidbody rb;
    public float maxMove;
    public float accMove;
    public float dampMove;

    // public Animator animator;

    Vector2 input;

    void Start()
    {
        maxMove = maxMove > 0 ? maxMove : 1;
        accMove = accMove > 0 ? accMove : 1;
    }

    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        if(Input.GetKeyDown("space")&&interactives.Count!=0)
        {
            interactives[0].Interacted(); 
        }

        interactives.Clear();
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
    void onTriggerStay(Collider other)
    {
        transform.position = new Vector3(10, 10, 0);
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactive Npc"))
        {
            
            //interactives.Add(other.gameObject.GetComponent<Interactive>());
        }
    }
}
