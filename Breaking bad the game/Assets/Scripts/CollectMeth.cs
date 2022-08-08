using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//add the scene management above

public class CollectMeth : MonoBehaviour
{
    [SerializeField] private GameObject methBag;
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
            Destroy(methBag);
            collectSound.Play();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = walterGun;
        }
    }
}
