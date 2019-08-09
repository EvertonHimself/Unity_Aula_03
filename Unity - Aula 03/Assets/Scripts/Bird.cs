using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Checks if player is dead or not.
    private bool isDead = false;
    // Gets the rigidbody2d attached to this game object.
    private Rigidbody2D rb2d;
    // Gets the ANIMATOR attached to this game object.
    private Animator anim;

    // The force the player is pushed upwards.
    public float upForce = 200f;
    void Start()
    {
        // Assign this game object's rigidbody to the rb2d variable.
        rb2d = GetComponent<Rigidbody2D>();
        // Assign this game object's animator to the anim variable.
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (isDead == false)
        {
            // Checks if player pressed the right click.
            if (Input.GetMouseButtonDown(0))
            {
                // Resets the velocity to zero everytime the player jumps.
                rb2d.velocity = Vector2.zero;
                // The x force is zero because the player doesn't move on the x axis.
                rb2d.AddForce(new Vector2(0, upForce));
                // Fires the Flap trigger.
                anim.SetTrigger("Flap");
            }
        }
    }
    // Checks if the player touched something, if so, turns isDead to true.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Triggers the Die trigger.
        anim.SetTrigger("Die");
        isDead = true;
    }
}
