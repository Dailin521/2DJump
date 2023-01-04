using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D mRigidbody;
    float xMove;
    public float horizontalMovementSpeed = 5;
    public float jumptSpeed = 5;
    public float jumpGravity = 3;
    public float fallGravity = 6;
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    private void FixedUpdate()
    {

    }
    void PlayerMove()
    {
        xMove = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.K) && collisionObjectCount > 0)
        {
            mRigidbody.velocity = new Vector2(mRigidbody.velocity.x, jumptSpeed);
        }
        mRigidbody.velocity = new Vector2(xMove * horizontalMovementSpeed, mRigidbody.velocity.y);
        if (mRigidbody.velocity.y > 0)
        {
            mRigidbody.gravityScale = jumpGravity;
        }
        else
        {
            mRigidbody.gravityScale = fallGravity;
        }
    }
    public int collisionObjectCount = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionObjectCount++;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionObjectCount--;
    }

}
