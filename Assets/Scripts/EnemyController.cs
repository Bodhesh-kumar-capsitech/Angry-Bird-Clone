using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject[] enemyBirds;

    void Start()
    {
        enemyBirds = GameObject.FindGameObjectsWithTag("Enemy");
        print("Birds count is: " + enemyBirds.Length);
    }

    void Update()
    {
        
        if(enemyBirds! == null)
        {
            return;
        }

        if(enemyBirds == null)
        {
            Time.timeScale = 0;
            GameManager2.manager.OnLevelCompleted();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            // gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    


    
}
