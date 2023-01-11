using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning(1);
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHit>().Hit();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
