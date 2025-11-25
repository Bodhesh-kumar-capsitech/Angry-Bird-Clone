using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    
}
