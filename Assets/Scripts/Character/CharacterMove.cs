using UnityEngine;
using UniRx;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private GroundCheaker ground;
    [SerializeField]
    private GroundCheaker wall;
    private Rigidbody2D rb;
    private float playerSize;

    void Start()
    {
        playerSize = 0.2f;
        rb = GetComponent<Rigidbody2D>();
        var xMoveUpdate = Observable.EveryUpdate()
                          .Subscribe(_ => XMove());
        var jumpUpdate = Observable.EveryUpdate()
                        .Where(_ => Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                        .Subscribe(_ => jump());
    }

    private void XMove()
    {
        float xForth = Input.GetAxisRaw("Horizontal");

        if (!wall.isGround)
        {
            rb.velocity = new Vector2(xForth * speed, rb.velocity.y);
        }

        if (xForth != 0.0f)
        {
            transform.localScale = new Vector2(xForth * playerSize, playerSize);
        }
    }

    private void jump()
    {
        if (ground.isGround)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
}
