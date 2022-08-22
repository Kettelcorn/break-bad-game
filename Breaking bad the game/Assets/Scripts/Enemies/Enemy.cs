using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Enemy
{
    void OnCollisionEnter2D(Collision2D collision);
    void Movement();
    void Death();
}
