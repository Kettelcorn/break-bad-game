using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ProjectileBehaviour ProjectilePrefab;
    [SerializeField] private Transform LaunchOffset;

    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float offset;

    private Rigidbody2D rb;
    private bool isJumping;
    private bool jumpTracker;
    private float move;

    public bool hasGun;
    public int direction;

    // set rigid body and jumpTracker/hasGun to false
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTracker = false;
        hasGun = false;
        direction = 1;
    }

    // set up inputs for play actions
    void Update()
    {
        // horizontal movement
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        // orients sprite based on which way you are moving
        if (move > 0)
        {
            gameObject.transform.localScale = new Vector3(10, 10, 0);
            direction = 1;
        }
        
        if (move < 0)
        {
            gameObject.transform.localScale = new Vector3(-10, 10, 0);
            direction = -1;
        }


        // jump
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            jumpTracker = true;
            Debug.Log("jump");
        }
        // double jump
        else if (Input.GetButtonDown("Jump") && jumpTracker == true) 
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            jumpTracker = false;
            Debug.Log("jump");
        }

        // gun fire
        if (Input.GetButtonDown("Fire1") && hasGun)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }
    }

    // on collision with ground, set jumping trackers to false
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            jumpTracker = false;
        }   
    }

    // on exiting collision with ground, set jumping trackers to true
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            jumpTracker = true;
        }
    }


}
