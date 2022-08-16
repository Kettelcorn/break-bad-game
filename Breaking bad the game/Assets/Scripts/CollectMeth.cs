using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//add the scene management above

public class CollectMeth : MonoBehaviour
{
    [SerializeField] private GameObject methBag;
    [SerializeField] private AudioSource collectSound;

    // on collision, destroy meth bag
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(methBag);
            collectSound.Play();
        }
    }
}
