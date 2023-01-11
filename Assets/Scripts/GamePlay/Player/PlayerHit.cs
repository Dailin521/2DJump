using UnityEngine;
using UnityEngine.Events;

public class PlayerHit : MonoBehaviour
{
    public UnityEvent OnHit;
    public void Hit()
    {
        OnHit?.Invoke();
    }

}
