using UnityEngine;
using UnityEngine.Events;

public class Apple : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnGet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnGet?.Invoke();
            Destroy(gameObject);
        }
    }
}
