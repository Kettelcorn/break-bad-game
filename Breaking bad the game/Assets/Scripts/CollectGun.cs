using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGun : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject walter;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private Sprite walterGun;

    




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
            walter.GetComponent<Player>().hasGun = true;
            Destroy(gun);
            collectSound.Play();
            walter.gameObject.GetComponent<SpriteRenderer>().sprite = walterGun;
        }
    }
}
