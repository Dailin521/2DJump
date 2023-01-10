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
        xOffest = Mathf.Abs(mRigidbody2D.velocity.x / mPlayerMovement.horizontalMovementSpeed);
        yOffest = Mathf.Abs(mRigidbody2D.velocity.y / mPlayerMovement.jumptSpeed);
        Scale = new Vector3(0.7f + 0.4f * xOffest, 0.7f + 0.3f * yOffest / 2, 1);
        transform.localScale = Scale;
    }
}
