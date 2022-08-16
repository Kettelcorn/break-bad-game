using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGun : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject walter;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private Sprite walterGun;

    // on collision, change sprite to have walter carry gun
    // and destroy gun
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            walter.GetComponent<Player>().hasGun = true;
            Destroy(gun);
            collectSound.Play();
            walter.gameObject.GetComponent<SpriteRenderer>().sprite = walterGun;
        }
    }
}
