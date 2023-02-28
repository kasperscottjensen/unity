using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    bool dead;
    
    void Update()
    {
        if (transform.position.y < -1.5)
        {
            Die();
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBody") && !dead)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        dead = true;
        Invoke(nameof(ReloadLevel), 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
