using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject walter;

    public int bulletDirection = 1;

    private void Start()
    {
        walter = GameObject.Find("Player");
        if (walter.GetComponent<Player>().direction == -1)
            bulletDirection = -1;
    }
    // transform position of projectile
    private void Update()
    {   
            transform.position += transform.right * Time.deltaTime * speed * bulletDirection;
    }

    // on collision, destroy projectile
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    // when leaves screen, destroy bullet
    private void OnBecameInvisible()
    {
        Destroy(gameObject);   
    }
}
