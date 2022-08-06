using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//add the scene management above

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject methBag;
    [SerializeField] private AudioSource collectSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(methBag);
            collectSound.Play();
        }
    }
}