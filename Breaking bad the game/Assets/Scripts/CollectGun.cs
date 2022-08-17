using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGun : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject walter;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private Sprite walterGun;

    // on trigger, destroy gun and play sound
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            walter.GetComponent<Player>().hasGun = true;
            Destroy(gun);
            collectSound.Play();
        }
    }
}
