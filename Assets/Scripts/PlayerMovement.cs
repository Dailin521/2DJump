using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D mRigidbody;
    float xMove;
    [Space(10)]
    public float horizontalMovementSpeed = 5;
    public float jumptSpeed = 5;
    [Space(10)]
    public float GravityMultiplier = 2;
    public float FallMultiplier = 1;

    [Space(10)]
    public float MinJumpTime = 0.2f;
    public float MaxJumpTime = 0.5f;
    private bool mJumpPressed = false;
    private float mCurrentJumpTime = 0;
    public enum JumpStates
    {
        NotJump, ControlJump, MinJump
    }
    public JumpStates jumpState = JumpStates.NotJump;
    public UnityEvent onLand;
    public UnityEvent onJump;
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        onLand.AddListener(() =>
        {
            GameObject.Find("Sounds/land").GetComponent<AudioSource>().Play();
        });
        onJump.AddListener(() =>
        {
            GameObject.Find("Sounds/land").GetComponent<AudioSource>().Stop();
            GameObject.Find("Sounds/jump01").GetComponent<AudioSource>().Play();
        });
    }
    void Update()
    {
        PlayerMoveGet();
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        if (jumpState == JumpStates.MinJump)
        {
            mRigidbody.velocity = new Vector2(mRigidbody.velocity.x, jumptSpeed);
            if (mCurrentJumpTime >= MinJumpTime)
            {
                jumpState = JumpStates.ControlJump;
            }
        }
        else if (jumpState == JumpStates.ControlJump)
        {
            mRigidbody.velocity = new Vector2(mRigidbody.velocity.x, jumptSpeed);
            if (!mJumpPressed || mCurrentJumpTime >= MaxJumpTime)
            {
                jumpState = JumpStates.NotJump;
            }
        }
        mRigidbody.velocity = new Vector2(xMove * horizontalMovementSpeed, mRigidbody.velocity.y);
        if (mRigidbody.velocity.y > 0 && jumpState != JumpStates.NotJump)
        {
            var progress = mCurrentJumpTime / MaxJumpTime;
            float jumpGravityMultiplier = GravityMultiplier;
            if (progress > 0.5f)
            {
                jumpGravityMultiplier = GravityMultiplier * (1 - progress);
            }
            mRigidbody.velocity += jumpGravityMultiplier * Time.deltaTime * Physics2D.gravity;
        }
        else if (mRigidbody.velocity.y <= 0)
        {
            mRigidbody.velocity += FallMultiplier * Time.deltaTime * Physics2D.gravity;
        }
    }
    void PlayerMoveGet()
    {
        xMove = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.K) && collisionObjectCount > 0)
        {
            onJump?.Invoke();
            mJumpPressed = true;
            if (jumpState == JumpStates.NotJump)
            {
                mCurrentJumpTime = 0;
                jumpState = JumpStates.MinJump;
            }
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            mJumpPressed = false;
        }
        mCurrentJumpTime += Time.deltaTime;
    }
    public int collisionObjectCount = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            collisionObjectCount++;
            onLand?.Invoke();

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
            collisionObjectCount--;
    }

}
