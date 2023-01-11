using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D mRigidbody2D;
    private PlayerMovement mPlayerMovement;
    private Vector3 Scale;
    private float xOffest;
    private float yOffest;
    void Start()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
        mPlayerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mRigidbody2D.velocity.y > 5 || mRigidbody2D.velocity.y < -3)
        {
            yOffest = Mathf.Abs(mRigidbody2D.velocity.y / mPlayerMovement.jumptSpeed);
        }

        xOffest = Mathf.Abs(mRigidbody2D.velocity.x / mPlayerMovement.horizontalMovementSpeed);
        Scale = new Vector3(0.7f + 0.4f * xOffest, 0.7f + 0.3f * yOffest / 2, 1);
        transform.localScale = Scale;

    }
}
