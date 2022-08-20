using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gus : MonoBehaviour
{

    [SerializeField] private int time;
    [SerializeField] private int pause;
    [SerializeField] private float speed;
    [SerializeField] private GameObject gus;

    private Rigidbody2D rb;
    private int counter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        counter = 0;
    }

    void Update()
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
