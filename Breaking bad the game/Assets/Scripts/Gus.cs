using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gus : MonoBehaviour
{

    [SerializeField] private int time;
    [SerializeField] private int pause;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private GameObject gus;
    [SerializeField] private GameObject blood;
    [SerializeField] private bool death;

    private Rigidbody2D rb;
    private int counter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        counter = 0;
        death = false;
    }

    void Update()
    {
        if (death)
        {
            gus.transform.rotation = Quaternion.Euler(0, 0, gus.transform.localRotation.eulerAngles.z - rotateSpeed);
                Destroy(gus, 1);
        }
        else
        {
            // makes gus move back and forth
            counter++;
            if (counter < time) rb.velocity = new Vector2(speed, 0);
            else if (counter < time + pause) rb.velocity = new Vector2(0, 0);
            else if (counter < time * 2 + pause) rb.velocity = new Vector2(-speed, 0);
            else if (counter < time * 2 + pause * 2) rb.velocity = new Vector2(0, 0);
            else counter = 0;

            // flips sprite based on direction gus is moving
            if (rb.velocity.x < 0) gus.gameObject.transform.localScale = new Vector3(-10, 10, 0);
            if (rb.velocity.x > 0) gus.gameObject.transform.localScale = new Vector3(10, 10, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Projectile"))
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            death = true;
        }
    }
}
