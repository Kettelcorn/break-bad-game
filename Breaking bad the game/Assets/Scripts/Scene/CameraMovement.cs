using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private GameObject target;
    
    // camera follows position of player
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, -10);    
    }
}
