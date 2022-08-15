using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed;

    
    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
