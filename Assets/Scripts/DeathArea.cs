using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DeathArea : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent onDeath;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            onDeath?.Invoke();

            StartCoroutine(LevelPass.Dely(4.5f, () =>
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }));

        }
    }
}
