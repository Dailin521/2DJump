using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D mRigidbody2D;
    private PlayerMovement mPlayerMovement;
    private Vector3 Scale;
    private float xOffest;
    void Start()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
        mPlayerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        xOffest = Mathf.Abs(mRigidbody2D.velocity.x / mPlayerMovement.horizontalMovementSpeed);
        Scale = new Vector3(0.7f + 0.3f * xOffest, 0.7f + 0.3f, 1);
        transform.localScale = Scale;
    }
}
