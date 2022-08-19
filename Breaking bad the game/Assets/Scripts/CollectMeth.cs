using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//add the scene management above

public class CollectMeth : MonoBehaviour
{
    [SerializeField] private GameObject methBag;
    [SerializeField] private GameObject walter;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private string textValue;
    [SerializeField] private Text textElement;

    private void Start()
    {
        textElement.text = textValue + 0;
    }
    // on trigger, destroy meth bag
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            walter.gameObject.GetComponent<Player>().methCount++;
            textElement.text = textValue + walter.gameObject.GetComponent<Player>().methCount;
            Destroy(methBag);
            collectSound.Play();
        }
    }
}
