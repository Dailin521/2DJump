using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger2D : MonoBehaviour
{
    public LayerMask layerMask;
    public bool Triggered = false;
    private HashSet<Collider2D> mCollider2ds = new();
    public UnityEvent OnTriggerEnter;
    public UnityEvent OnTriggerExit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMaskUtility.Contains(layerMask, collision.gameObject.layer))
        {
            mCollider2ds.Add(collision);
            if (!Triggered && mCollider2ds.Count > 0)
            {
                Triggered = true;
                OnTriggerEnter?.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMaskUtility.Contains(layerMask, collision.gameObject.layer))
        {
            mCollider2ds.Remove(collision);
            if (Triggered && mCollider2ds.Count == 0)
            {
                Triggered = false;
                OnTriggerExit?.Invoke();
            }
        }
    }
}
