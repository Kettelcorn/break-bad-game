using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;

    private Rigidbody2D rb;
    private bool isJumping;
    private float move;
    private bool jumpCounter;


    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;

    public bool hasGun;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCounter = false;

        hasGun = false;
    }


    // Update is called once per frame
    void Update()
    {
        // horizontal movement
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        // lets jump
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            jumpCounter = true;
            Debug.Log("jump");
        } else if (Input.GetButtonDown("Jump") && jumpCounter == true) 
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            jumpCounter = false;
            Debug.Log("jump");
        }

        if (Input.GetButtonDown("Fire1") && hasGun)
        {
                Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            jumpCounter = false;
        }   
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            jumpCounter = true;
        }
    }


}
