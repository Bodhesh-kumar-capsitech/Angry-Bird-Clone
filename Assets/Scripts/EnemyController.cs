using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Box"))
        {
            gameObject.SetActive(false);
        }
    }
}
